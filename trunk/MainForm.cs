/*
 *HamExamHelper, the little helper to help you pass your ham exams!
 *Copyright (C) 2006 Markus Schulz
 * 
 *This program is free software; you can redistribute it and/or
 *modify it under the terms of the GNU General Public License
 *as published by the Free Software Foundation; either version 2
 *of the License, or (at your option) any later version.
 *
 *This program is distributed in the hope that it will be useful,
 *but WITHOUT ANY WARRANTY; without even the implied warranty of
 *MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *GNU General Public License for more details.
 *
 *You should have received a copy of the GNU General Public License
 *along with this program; if not, write to the Free Software
 *Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 *
 *
 * Created by Markus Schulz with the help of SharpDevelop and Visual C# express.
 * User: $Author$
 * Date: $LastChangedDate$
 * Rev : $Rev$
 * 
 * ID: $Id$
 */

using System;
using System.Threading;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Text;
using System.IO;
using SpeechLib;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Formatters.Binary;



namespace HamExamHelper
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm
	{
		private List<QAobj>myQAdb;
		private List<QAobj>myQAdb_backup;
		private List<QAobj>myQuiz;
		private Thread MyThread;
		
		
		private static void MyCallbackFunction(object s1)
		{
			SpVoice objSpeech = new SpVoice();
			objSpeech.Speak(s1.ToString(),SpeechVoiceSpeakFlags.SVSFlagsAsync);
			objSpeech.WaitUntilDone(-1);
		}
		[STAThread]
		public static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		}
		
		void FileToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			//SpVoice objSpeech = new SpVoice();
			//objSpeech.Speak("Please select the exam you want to learn.",SpeechVoiceSpeakFlags.SVSFlagsAsync);
			//objSpeech.WaitUntilDone(-1);
		}
		
		void pars(TextReader tr, string regEx, object sender, System.EventArgs e)
		{
			string line;
			Match mc;
			myQAdb = new List<QAobj>();
			myQAdb_backup = myQAdb;
			Regex startRegEx = new Regex(regEx);
			Regex aRegEx = new Regex(@"A\..*");
			Regex bRegEx = new Regex(@"B\..*");
			Regex cRegEx = new Regex(@"C\..*");
			Regex dRegEx = new Regex(@"D\..*");
			Regex pictureRegEx = new Regex(@"((G|E)\d-\d)");
			Regex tRegEx = new Regex(@"~~");
			
			while ((line = tr.ReadLine()) != null)
			{
				if(line=="") continue;
				mc = startRegEx.Match(line);
				if (mc.Success){
					QAobj myObj = new QAobj();
					myObj.QuestionNumber = mc.Groups[1].Value;
					myObj.RightAnswer = mc.Groups[2].Value;
					bool flag=true;
					do
					{
						line=tr.ReadLine();
						if(line=="") continue;
						flag = false;
					}while(flag);
					myObj.Question = line;
					do{
						flag=true;
						do
						{
							line=tr.ReadLine();
							if(line=="") continue;
							flag = false;
						}while(flag);
						if (aRegEx.Match(line).Success) myObj.AnswerA = line;
						else myObj.Question = myObj.Question.Trim() + " " + line.Trim();
					}while(!(aRegEx.Match(line).Success));
					
					do{
						flag=true;
						do
						{
							line=tr.ReadLine();
							if(line=="") continue;
							flag = false;
						}while(flag);
						if (bRegEx.Match(line).Success)myObj.AnswerB=line;
						else myObj.AnswerA = myObj.AnswerA.Trim() + " " + line.Trim();
					}while(!(bRegEx.Match(line).Success));
					
					do{
						flag=true;
						do
						{
							line=tr.ReadLine();
							if(line=="") continue;
							flag = false;
						}while(flag);
						if (cRegEx.Match(line).Success)myObj.AnswerC=line;
						else myObj.AnswerB = myObj.AnswerB.Trim() + " " + line.Trim();
					}while(!(cRegEx.Match(line).Success));
					
					do{
						flag=true;
						do
						{
							line=tr.ReadLine();
							if(line=="") continue;
							flag = false;
						}while(flag);
						if (dRegEx.Match(line).Success)myObj.AnswerD=line;
						else myObj.AnswerC = myObj.AnswerC.Trim() + " " + line.Trim();
					}while(!(dRegEx.Match(line).Success));
					
					do{
						flag=true;
						do
						{
							line=tr.ReadLine();
							if(line=="") continue;
							flag = false;
						}while(flag);
						if (!tRegEx.Match(line).Success) myObj.AnswerD = myObj.AnswerD.Trim() + " " + line.Trim();
					}while(!(tRegEx.Match(line).Success));
					myObj.AnswerA = myObj.AnswerA+".";
					myObj.AnswerB = myObj.AnswerB+".";
					myObj.AnswerC = myObj.AnswerC+".";
					myObj.AnswerD = myObj.AnswerD+".";
					if(pictureRegEx.Match(myObj.Question).Success) myObj.Picture = pictureRegEx.Match(myObj.Question).ToString();
					myQAdb.Add(myObj);
				}
			}
			ButtonReplayClick(sender,e);
		}
		
		void CWToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			MessageBox.Show("Element 1 was disconntiued by the FCC on Feb 23 2007","Info");
		}
		
		void createMenues()
		{
			string buf = myQAdb[0].QuestionGroup2;
			string buf2 = myQAdb[0].QuestionGroup3;
			int index = 0, bindex=0;
			
			myQAdb.ForEach(delegate(QAobj o)
			               {
			               	if (buf != o.QuestionGroup2)
			               	{
			               		buf = o.QuestionGroup2;
			               		index++;
			               	}
			               	
			               });
			
			bindex = index+1;
			string[] buffer = new string[bindex];
			int[] numbuf = new int[bindex];
			for (int i = 0; i != bindex; i++) numbuf[i] = 0;
			buf = myQAdb[0].QuestionGroup2;
			index = 0;
			myQAdb.ForEach(delegate(QAobj o)
			               {
			               	if (buf2 != o.QuestionGroup3)
			               	{
			               		buf2 = o.QuestionGroup3;
			               		numbuf[index]++;
			               	}
			               	if (buf != o.QuestionGroup2)
			               	{
			               		buffer[index] = buf;
			               		buf = o.QuestionGroup2;
			               		index++;
			               	}
			               });
			numbuf[index]++;
			buffer[index] = buf;
			mitemsa = new ToolStripMenuItem[bindex];
			mitemsq = new ToolStripMenuItem[bindex];
			for (int i=0; i != bindex; i++)
			{
				mitemsa[i] = new System.Windows.Forms.ToolStripMenuItem();
				mitemsa[i].Checked = false;
				mitemsa[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
				mitemsa[i].Name = buffer[i];
				mitemsa[i].Size = new System.Drawing.Size(152, 22);
				mitemsa[i].Text = "Subelement " + buffer[i] + " " + numbuf[i] + " exam questions";
				mitemsa[i].Click += new System.EventHandler(this.tA1ToolStripMenuItem_Click);
				mitemsq[i] = new System.Windows.Forms.ToolStripMenuItem();
				mitemsq[i].Checked = false;
				mitemsq[i].CheckState = System.Windows.Forms.CheckState.Unchecked;
				mitemsq[i].Name = buffer[i];
				mitemsq[i].Size = new System.Drawing.Size(152, 22);
				mitemsq[i].Text = "Subelement " + buffer[i] + " " + numbuf[i] + " exam questions";
				mitemsq[i].Click += new System.EventHandler(this.tA1ToolStripMenuItem1_Click);
				
			}
			this.showAnswersByGroupToolStripMenuItem.DropDownItems.Clear();
			this.showAnswersByGroupToolStripMenuItem.DropDownItems.AddRange(mitemsa);
			this.quizByGroupToolStripMenuItem.DropDownItems.Clear();
			this.quizByGroupToolStripMenuItem.DropDownItems.AddRange(mitemsq);


		}
		private System.Windows.Forms.ToolStripMenuItem[] mitemsa;
		private System.Windows.Forms.ToolStripMenuItem[] mitemsq;
		private void tA1ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//answers
			ToolStripMenuItem myitem = (ToolStripMenuItem)sender;
			if (myitem.Checked) myitem.Checked = false;
			else myitem.Checked = true;
			myQAdb = new List<QAobj>();
			for (int i = 0; i != myQAdb_backup.Count; i++)
			{
				for (int ii = 0; ii != mitemsa.Length; ii++) if (mitemsa[ii].Name == myQAdb_backup[i].QuestionGroup2 && mitemsa[ii].Checked) myQAdb.Add(myQAdb_backup[i]);
			}
			if (myQAdb.Count == 0) myQAdb.Add(myQAdb_backup[0]);
			textBoxGo.Text = "0";
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = true;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled = true;
			buttonGo.Enabled = true;
			checkBoxAM.Enabled = true;
			checkBoxVoice.Enabled = true;
			buttonPrevious.Enabled = true;
			buttonReplay.Enabled = true;
			buttonNext.Enabled = true;
			ButtonReplayClick(sender, e);
		}

		private void tA1ToolStripMenuItem1_Click(object sender, EventArgs e)
		{
			//quiz
			ToolStripMenuItem myitem = (ToolStripMenuItem)sender;
			if (myitem.Checked) myitem.Checked = false;
			else myitem.Checked = true;
			myQAdb = new List<QAobj>();
			for (int i = 0; i != myQAdb_backup.Count; i++)
			{
				for (int ii = 0; ii != mitemsq.Length; ii++) if (mitemsq[ii].Name == myQAdb_backup[i].QuestionGroup2 && mitemsq[ii].Checked) myQAdb.Add(myQAdb_backup[i]);
			}
			if (myQAdb.Count == 0) myQAdb.Add(myQAdb_backup[0]);
			textBoxGo.Text = "0";
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = true;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled = true;
			buttonGo.Enabled = true;
			checkBoxAM.Enabled = false;
			checkBoxAM.Checked = false;
			checkBoxVoice.Enabled = true;
			buttonPrevious.Enabled = true;
			buttonReplay.Enabled = true;
			buttonNext.Enabled = true;
			ButtonReplayClick(sender, e);

		}

		void TechToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			textBoxGo.Text = "0";
			pictureBoxE.Visible = false;
			labelA.Width = 606;
			labelB.Width = 606;
			labelC.Width = 606;
			labelD.Width = 606;
			TextReader tr;
			try
			{
				tr = new StreamReader("2006Tech.txt");
				pars(tr, @"(^T\d[a-zA-Z]\d\d)\s\(([A-D])\)", sender, e);
				createMenues();
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show(ex.FileName, "File not found");
				Application.Exit();
				tr = null;
			}
			cWToolStripMenuItem.Checked = false;
			techToolStripMenuItem.Checked=true;
			generalToolStripMenuItem.Checked=false;
			generalToolStripMenuItem1.Checked=false;
			extraToolStripMenuItem.Checked=false;
			
		}
		
		void GeneralToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			textBoxGo.Text = "0";
			pictureBoxE.Visible = false;
			labelA.Width = 606;
			labelB.Width = 606;
			labelC.Width = 606;
			labelD.Width = 606;
			TextReader tr;
			try
			{
				tr = new StreamReader("2004General.txt");
				pars(tr, @"(^G\d[a-zA-Z]\d\d)\s\(([A-D])\)", sender, e);
				createMenues();
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show(ex.FileName, "File not found");
				Application.Exit();
				tr = null;
			}
			cWToolStripMenuItem.Checked = false;
			techToolStripMenuItem.Checked=false;
			generalToolStripMenuItem.Checked=true;
			generalToolStripMenuItem1.Checked=false;
			extraToolStripMenuItem.Checked=false;
			
		}
		
		void GeneralToolStripMenuItem1Click(object sender, EventArgs e)
		{
			textBoxGo.Text = "0";
			pictureBoxE.Visible = false;
			labelA.Width = 606;
			labelB.Width = 606;
			labelC.Width = 606;
			labelD.Width = 606;
			TextReader tr;
			try
			{
				tr = new StreamReader("2007General.txt");
				pars(tr, @"(^G\d[a-zA-Z]\d\d)\s\(([A-D])\)", sender, e);
				createMenues();
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show(ex.FileName, "File not found");
				Application.Exit();
				tr = null;
			}
			cWToolStripMenuItem.Checked = false;
			techToolStripMenuItem.Checked=false;
			generalToolStripMenuItem.Checked=false;
			generalToolStripMenuItem1.Checked=true;
			extraToolStripMenuItem.Checked=false;
		}
		
		void ExtraToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			textBoxGo.Text = "0";
			pictureBoxE.Visible = false;
			labelA.Width = 606;
			labelB.Width = 606;
			labelC.Width = 606;
			labelD.Width = 606;
			TextReader tr;
			try
			{
				tr = new StreamReader("2002Extra.txt");
				pars(tr, @"(^E\d[a-zA-Z]\d\d)\s\(([A-D])\)", sender, e);
				createMenues();
			}
			catch (FileNotFoundException ex)
			{
				MessageBox.Show(ex.FileName, "File not found");
				Application.Exit();
				tr = null;
			}
			cWToolStripMenuItem.Checked = false;
			techToolStripMenuItem.Checked=false;
			generalToolStripMenuItem.Checked=false;
			generalToolStripMenuItem1.Checked=false;
			extraToolStripMenuItem.Checked=true;
			
		}
		
		void ExitToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		
		private string lastKnowenGoodGO="0";
		
		void ButtonReplayClick(object sender, System.EventArgs e)
		{
			// general section
			int testVal;
			try
			{
				testVal = Convert.ToInt32(textBoxGo.Text);
				if (testVal < 0 || testVal > myQAdb.Count - 1) textBoxGo.Text = lastKnowenGoodGO;
			}
			catch (Exception ex)
			{
				textBoxGo.Text = lastKnowenGoodGO;
				string buf;
				buf = ex.ToString();
				toolStripStatusLabel1.Text = buf.Substring(0, 15);


			}
			//pictures
			
			if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Picture!=null)
			{
				pictureBoxE.Visible = true;
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
				string mypicture =myQAdb[Convert.ToInt32(textBoxGo.Text)].Picture;
				this.pictureBoxE.Image = ((System.Drawing.Image)resources.GetObject((mypicture)));
				labelA.Width = 300;
				labelB.Width = 300;
				labelC.Width = 300;
				labelD.Width = 300;
			}
			else
			{
				pictureBoxE.Visible = false;
				labelA.Width = 606;
				labelB.Width = 606;
				labelC.Width = 606;
				labelD.Width = 606;
			}
			lastKnowenGoodGO=textBoxGo.Text;
			int myDBCount = myQAdb.Count;
			myDBCount--;
			toolStripProgressBar1.Maximum=myDBCount;
			toolStripProgressBar1.Value = Convert.ToInt32(textBoxGo.Text);
			labelNo.Text = textBoxGo.Text+@"/"+myDBCount.ToString();
			LabelQnum.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].QuestionNumber;
			labelQuestion.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].Question;
			labelA.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].AnswerA;
			labelB.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].AnswerB;
			labelC.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].AnswerC;
			labelD.Text = myQAdb[Convert.ToInt32(textBoxGo.Text)].AnswerD;
			string rsbuf1 = labelQuestion.Text;
			string rsbuf2 ="";

			if (showAnswersToolStripMenuItem.Checked || showAnswersByGroupToolStripMenuItem.Checked || showExamAnswersToolStripMenuItem.Checked)
			{
				labelA.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				labelB.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				labelC.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				labelD.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="A")
				{
					labelA.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.Enabled = true;
					labelB.Enabled = false;
					labelC.Enabled = false;
					labelD.Enabled = false;
					rsbuf2=labelA.Text;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="B")
				{
					labelA.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.Enabled = false;
					labelB.Enabled = true;
					labelC.Enabled = false;
					labelD.Enabled = false;
					rsbuf2=labelB.Text;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="C")
				{
					labelA.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.Enabled = false;
					labelB.Enabled = false;
					labelC.Enabled = true;
					labelD.Enabled = false;
					rsbuf2=labelC.Text;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="D")
				{
					labelA.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.Enabled = false;
					labelB.Enabled = false;
					labelC.Enabled = false;
					labelD.Enabled = true;
					rsbuf2=labelD.Text;
				}
				
				rsbuf2=rsbuf2.Insert(1,"! : ");
				String strbuf = "Question: "+rsbuf1+" Answer:.,; "+" "+rsbuf2;
				if (checkBoxVoice.Checked){
					if(MyThread==null){
						MyThread = new Thread(new ParameterizedThreadStart(MyCallbackFunction));
						MyThread.Start(strbuf);
					}
					else{
						if(!MyThread.IsAlive){
							MyThread = new Thread(new ParameterizedThreadStart(MyCallbackFunction));
							MyThread.Start(strbuf);
						}
					}
				}
			}
			else
			{
				labelA.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
				labelB.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
				labelC.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
				labelD.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
				labelA.Enabled = true;
				labelB.Enabled = true;
				labelC.Enabled = true;
				labelD.Enabled = true;
				labelA.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
				labelB.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
				labelC.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
				labelD.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
				
			}
			if (testToolStripMenuItem.Checked)
			{
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="A")labelA.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="B")labelB.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="C")labelC.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="D")labelD.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
				if(scoreToolStripMenuItem.Checked)
				{
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="A")labelA.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="B")labelB.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="C")labelC.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer=="D")labelD.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="A")labelA.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="B")labelB.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="C")labelC.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="D")labelD.ForeColor= System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					
				}
			}
		}
		
		void score()
		{
			int right=0,wrong=0;
			myQAdb.ForEach(delegate(QAobj o){
			               	if(o.Quiz){
			               		if(o.Right) right++;
			               		else wrong++;
			               	}
			               });
			toolStripTextBoxRight.Text = "Right: "+right.ToString();
			toolStripTextBoxWrong.Text = "Wrong: "+wrong.ToString();
			double per= (100/(double)(right+wrong))*(double)right;
			toolStripTextBoxTime.Text=per.ToString()+"%";
		}
		
		
		void ButtonNextClick(object sender, System.EventArgs e)
		{
			int buf = Convert.ToInt32(textBoxGo.Text);
			if(buf<myQAdb.Count-1)buf++;
			else buf = 0;
			textBoxGo.Text=buf.ToString();
			ButtonReplayClick(sender,e);
		}
		
		
		void ButtonPreviousClick(object sender, System.EventArgs e)
		{
			int buf = Convert.ToInt32(textBoxGo.Text);
			if(buf>0)buf--;
			else buf = myQAdb.Count-1;
			textBoxGo.Text=buf.ToString();
			ButtonReplayClick(sender,e);
		}
		
		void ButtonGoClick(object sender, System.EventArgs e)
		{
			int buf = Convert.ToInt32(textBoxGo.Text);
			if(buf<0)buf =0;
			if(buf>myQAdb.Count) buf=myQAdb.Count;
			ButtonReplayClick(sender,e);
		}
		
		void MainFormLoad(object sender, System.EventArgs e)
		{
			TechToolStripMenuItemClick(sender,e);
			//CWToolStripMenuItemClick(sender,e);
		}
		private bool color;
		private bool scount;
		private int countup=0;
		void TimerFlashTick(object sender, System.EventArgs e)
		{
			if (showAnswersToolStripMenuItem.Checked || showAnswersByGroupToolStripMenuItem.Checked || showExamAnswersToolStripMenuItem.Checked)
			{
				if(MyThread!=null){
					if(!MyThread.IsAlive&&checkBoxAM.Checked) ButtonNextClick(sender,e);
				}
				else{
					if(checkBoxAM.Checked){
						countup++;
						if (countup==24){
							countup=0;
							ButtonNextClick(sender,e);
						}
					}
				}
				if(color){
					labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					color=false;
				}
				else{
					labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					color=true;
				}
			}
			if ((quizToolStripMenuItem.Checked || quizByGroupToolStripMenuItem.Checked || quizExamToolStripMenuItem.Checked && scount == true) && checkBoxAM.Checked == true)
			{
				countup++;
				if (countup==3){
					countup=0;
					scount=false;
					ButtonNextClick(sender,e);
				}
				double testval = 0.25*(double)countup;
				testval = System.Math.Round(testval,0);
				toolStripTextBoxTime.Text = testval.ToString();
			}
			
		}
		
		void CheckBoxVoiceCheckedChanged(object sender, System.EventArgs e)
		{
			if (!checkBoxVoice.Checked){
				MyThread = null;
			}
		}
		
		void TextBoxGoTextChanged(object sender, System.EventArgs e)
		{
			
		}
		
		void StatusStrip1ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{
			
		}
		
		void ShowAnswersToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			showAnswersToolStripMenuItem.Checked = true;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled=true;
			buttonGo.Enabled=true;
			checkBoxAM.Enabled=true;
			checkBoxVoice.Enabled=true;
			buttonPrevious.Enabled=true;
			buttonReplay.Enabled=true;
			buttonNext.Enabled=true;
			myQAdb = myQAdb_backup;
			ButtonReplayClick(sender,e);
		}
		
		void ShowExamAnswersToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			TestToolStripMenuItemClick(sender,e);
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = true;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled=true;
			buttonGo.Enabled=true;
			checkBoxAM.Enabled=true;
			checkBoxVoice.Enabled=true;
			buttonPrevious.Enabled=true;
			buttonReplay.Enabled=true;
			buttonNext.Enabled=true;
			ButtonReplayClick(sender,e);
		}
		
		void QuizToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = true;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled=true;
			buttonGo.Enabled=true;
			checkBoxAM.Enabled=false;
			checkBoxAM.Checked = false;
			checkBoxVoice.Enabled=true;
			buttonPrevious.Enabled=true;
			buttonReplay.Enabled=true;
			buttonNext.Enabled=true;
			myQAdb = myQAdb_backup;
			ButtonReplayClick(sender,e);
		}
		
		void QuizExamToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			TestToolStripMenuItemClick(sender,e);
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = true;
			testToolStripMenuItem.Checked = false;
			textBoxGo.Enabled=true;
			buttonGo.Enabled=true;
			checkBoxAM.Enabled = false;
			checkBoxAM.Checked = false;
			checkBoxVoice.Enabled=true;
			buttonPrevious.Enabled=true;
			buttonReplay.Enabled=true;
			buttonNext.Enabled=true;
			ButtonReplayClick(sender,e);
		}
		
		void TestToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			showAnswersToolStripMenuItem.Checked = false;
			showAnswersByGroupToolStripMenuItem.Checked = false;
			showExamAnswersToolStripMenuItem.Checked = false;
			quizToolStripMenuItem.Checked = false;
			quizByGroupToolStripMenuItem.Checked = false;
			quizExamToolStripMenuItem.Checked = false;
			testToolStripMenuItem.Checked = true;
			textBoxGo.Enabled=true;
			buttonGo.Enabled=true;
			checkBoxAM.Enabled=false;
			checkBoxAM.Checked=false;
			checkBoxVoice.Enabled=false;
			buttonPrevious.Enabled=true;
			buttonReplay.Enabled=true;
			buttonNext.Enabled=true;
			ButtonReplayClick(sender,e);
			
			if(techToolStripMenuItem.Checked==true)TechToolStripMenuItemClick(sender,e);
			if(generalToolStripMenuItem.Checked==true)GeneralToolStripMenuItemClick(sender,e);
			if(extraToolStripMenuItem.Checked==true)ExtraToolStripMenuItemClick(sender,e);
			
			MyList<QAobj>minilist= new MyList<QAobj>();
			myQuiz = new List<QAobj>();
			String group=myQAdb[0].QuestionGroup;
			
			myQAdb.ForEach(delegate(QAobj o){
			               	if(o.QuestionGroup==group) minilist.Add(o);
			               	else{
			               		group=o.QuestionGroup;
			               		myQuiz.Add(minilist.ReturnRandom());
			               		minilist.Clear();
			               		minilist.Add(o);
			               	}
			               });
			myQuiz.Add(minilist.ReturnRandom());
			myQAdb = myQuiz;
			textBoxGo.Text="0";
			ButtonReplayClick(sender,e);
		}
		
		
		void LabelAClick(object sender, System.EventArgs e)
		{
			if (quizToolStripMenuItem.Checked || quizByGroupToolStripMenuItem.Checked || quizExamToolStripMenuItem.Checked)
			{
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="A"){
					labelA.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=true;
					scount=true;
				}
				else
				{
					labelA.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=false;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false) myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="A";
				myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz=true;
				score();
			}
			if(testToolStripMenuItem.Checked)
			{
				myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="A";
				ButtonReplayClick(sender,e);
			}
			
		}
		
		void LabelBClick(object sender, System.EventArgs e)
		{
			if (quizToolStripMenuItem.Checked || quizByGroupToolStripMenuItem.Checked || quizExamToolStripMenuItem.Checked)
			{
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="B"){
					labelB.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=true;
					scount=true;
				}
				else
				{
					labelB.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=false;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false) myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="B";
				myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz=true;
				score();
			}
			if(testToolStripMenuItem.Checked)
			{
				myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="B";
				ButtonReplayClick(sender,e);
			}
		}
		
		void LabelCClick(object sender, System.EventArgs e)
		{
			if (quizToolStripMenuItem.Checked || quizByGroupToolStripMenuItem.Checked || quizExamToolStripMenuItem.Checked)
			{
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="C"){
					labelC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=true;
					scount=true;
				}
				else
				{
					labelC.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=false;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false) myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="C";
				myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz=true;
				score();
			}
			if(testToolStripMenuItem.Checked)
			{
				myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="C";
				ButtonReplayClick(sender,e);
			}
		}
		
		void LabelDClick(object sender, System.EventArgs e)
		{
			if (quizToolStripMenuItem.Checked || quizByGroupToolStripMenuItem.Checked || quizExamToolStripMenuItem.Checked)
			{
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].RightAnswer=="D"){
					labelD.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=true;
					scount=true;
				}
				else
				{
					labelD.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
					labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
					if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false)myQAdb[Convert.ToInt32(textBoxGo.Text)].Right=false;
				}
				if(myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz==false) myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="D";
				myQAdb[Convert.ToInt32(textBoxGo.Text)].Quiz=true;
				score();
			}
			if(testToolStripMenuItem.Checked)
			{
				myQAdb[Convert.ToInt32(textBoxGo.Text)].SelectedAnswer="D";
				ButtonReplayClick(sender,e);
			}
		}
		
		void MenuStrip1ItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
		{
			
		}
		
		void ResetToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			if(techToolStripMenuItem.Checked==true)TechToolStripMenuItemClick(sender,e);
			if(generalToolStripMenuItem.Checked==true)GeneralToolStripMenuItemClick(sender,e);
			if(extraToolStripMenuItem.Checked==true)ExtraToolStripMenuItemClick(sender,e);
		}
		
		void ScoreToolStripMenuItemClick(object sender, System.EventArgs e)
		{
			scoreToolStripMenuItem.Checked=!scoreToolStripMenuItem.Checked;
			if(testToolStripMenuItem.Checked) myQAdb.ForEach(delegate(QAobj o){
			                                                 	if(o.RightAnswer==o.SelectedAnswer){
			                                                 		o.Right=true;
			                                                 		o.Quiz = true;
			                                                 	}
			                                                 	else o.Quiz = true;
			                                                 });
			score();
			
		}
		
		void ToolStripTextBox1Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("V1.0.0.3", "Version");
		}

		private void setupToolStripMenuItem_Click(object sender, EventArgs e)
		{

			
		}
		

		private void textBoxGo_KeyDown(object sender, KeyEventArgs e)
		{

		}

		private void textBoxGo_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == 13) ButtonGoClick(sender, e);
			if (char.IsControl(e.KeyChar))
			{

			}
			else if (!char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}
		
		void HttphamexamwikidotcomToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		System.Diagnostics.Process.Start("http://hamexamhelper.sourceforge.net/");


		}
	}
}
