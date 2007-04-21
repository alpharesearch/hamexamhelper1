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
namespace HamExamHelper
{
	partial class MainForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.techToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.generalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.modeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showAnswersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showAnswersByGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tA1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showExamAnswersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quizByGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tA1ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.quizExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.scoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.httphamexamwikidotcomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBoxTime = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripTextBoxRight = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripTextBoxWrong = new System.Windows.Forms.ToolStripTextBox();
			this.labelQuestion = new System.Windows.Forms.Label();
			this.labelA = new System.Windows.Forms.Label();
			this.labelB = new System.Windows.Forms.Label();
			this.labelC = new System.Windows.Forms.Label();
			this.labelD = new System.Windows.Forms.Label();
			this.buttonNext = new System.Windows.Forms.Button();
			this.buttonReplay = new System.Windows.Forms.Button();
			this.buttonPrevious = new System.Windows.Forms.Button();
			this.textBoxGo = new System.Windows.Forms.TextBox();
			this.buttonGo = new System.Windows.Forms.Button();
			this.timerFlash = new System.Windows.Forms.Timer(this.components);
			this.checkBoxAM = new System.Windows.Forms.CheckBox();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.LabelQnum = new System.Windows.Forms.ToolStripStatusLabel();
			this.labelNo = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			this.checkBoxVoice = new System.Windows.Forms.CheckBox();
			this.pictureBoxE = new System.Windows.Forms.PictureBox();
			this.menuStrip1.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxE)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.modeToolStripMenuItem,
									this.aboutToolStripMenuItem,
									this.toolStripTextBoxTime,
									this.toolStripTextBoxRight,
									this.toolStripTextBoxWrong});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(632, 25);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MenuStrip1ItemClicked);
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.cWToolStripMenuItem,
									this.techToolStripMenuItem,
									this.generalToolStripMenuItem,
									this.generalToolStripMenuItem1,
									this.extraToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 21);
			this.fileToolStripMenuItem.Text = "Element";
			this.fileToolStripMenuItem.Click += new System.EventHandler(this.FileToolStripMenuItemClick);
			// 
			// cWToolStripMenuItem
			// 
			this.cWToolStripMenuItem.Name = "cWToolStripMenuItem";
			this.cWToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.cWToolStripMenuItem.Text = "Morse Code";
			this.cWToolStripMenuItem.Click += new System.EventHandler(this.CWToolStripMenuItemClick);
			// 
			// techToolStripMenuItem
			// 
			this.techToolStripMenuItem.Name = "techToolStripMenuItem";
			this.techToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.techToolStripMenuItem.Text = "2006 Technician";
			this.techToolStripMenuItem.Click += new System.EventHandler(this.TechToolStripMenuItemClick);
			// 
			// generalToolStripMenuItem
			// 
			this.generalToolStripMenuItem.Name = "generalToolStripMenuItem";
			this.generalToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.generalToolStripMenuItem.Text = "2004 General";
			this.generalToolStripMenuItem.Click += new System.EventHandler(this.GeneralToolStripMenuItemClick);
			// 
			// generalToolStripMenuItem1
			// 
			this.generalToolStripMenuItem1.Name = "generalToolStripMenuItem1";
			this.generalToolStripMenuItem1.Size = new System.Drawing.Size(162, 22);
			this.generalToolStripMenuItem1.Text = "2007 General";
			this.generalToolStripMenuItem1.Click += new System.EventHandler(this.GeneralToolStripMenuItem1Click);
			// 
			// extraToolStripMenuItem
			// 
			this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
			this.extraToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.extraToolStripMenuItem.Text = "2006 Extra ";
			this.extraToolStripMenuItem.Click += new System.EventHandler(this.ExtraToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// modeToolStripMenuItem
			// 
			this.modeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.showAnswersToolStripMenuItem,
									this.showAnswersByGroupToolStripMenuItem,
									this.showExamAnswersToolStripMenuItem,
									this.quizToolStripMenuItem,
									this.quizByGroupToolStripMenuItem,
									this.quizExamToolStripMenuItem,
									this.testToolStripMenuItem,
									this.toolStripSeparator2,
									this.scoreToolStripMenuItem});
			this.modeToolStripMenuItem.Name = "modeToolStripMenuItem";
			this.modeToolStripMenuItem.Size = new System.Drawing.Size(45, 21);
			this.modeToolStripMenuItem.Text = "Mode";
			// 
			// showAnswersToolStripMenuItem
			// 
			this.showAnswersToolStripMenuItem.Checked = true;
			this.showAnswersToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showAnswersToolStripMenuItem.Name = "showAnswersToolStripMenuItem";
			this.showAnswersToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.showAnswersToolStripMenuItem.Text = "Show Answers";
			this.showAnswersToolStripMenuItem.Click += new System.EventHandler(this.ShowAnswersToolStripMenuItemClick);
			// 
			// showAnswersByGroupToolStripMenuItem
			// 
			this.showAnswersByGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tA1ToolStripMenuItem});
			this.showAnswersByGroupToolStripMenuItem.Name = "showAnswersByGroupToolStripMenuItem";
			this.showAnswersByGroupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.showAnswersByGroupToolStripMenuItem.Text = "Show Answers by Group";
			// 
			// tA1ToolStripMenuItem
			// 
			this.tA1ToolStripMenuItem.Checked = true;
			this.tA1ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tA1ToolStripMenuItem.Name = "tA1ToolStripMenuItem";
			this.tA1ToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
			this.tA1ToolStripMenuItem.Text = "TA1";
			this.tA1ToolStripMenuItem.Click += new System.EventHandler(this.tA1ToolStripMenuItem_Click);
			// 
			// showExamAnswersToolStripMenuItem
			// 
			this.showExamAnswersToolStripMenuItem.Name = "showExamAnswersToolStripMenuItem";
			this.showExamAnswersToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.showExamAnswersToolStripMenuItem.Text = "Show Exam Answers";
			this.showExamAnswersToolStripMenuItem.Click += new System.EventHandler(this.ShowExamAnswersToolStripMenuItemClick);
			// 
			// quizToolStripMenuItem
			// 
			this.quizToolStripMenuItem.Name = "quizToolStripMenuItem";
			this.quizToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.quizToolStripMenuItem.Text = "Quiz";
			this.quizToolStripMenuItem.Click += new System.EventHandler(this.QuizToolStripMenuItemClick);
			// 
			// quizByGroupToolStripMenuItem
			// 
			this.quizByGroupToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tA1ToolStripMenuItem1});
			this.quizByGroupToolStripMenuItem.Name = "quizByGroupToolStripMenuItem";
			this.quizByGroupToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.quizByGroupToolStripMenuItem.Text = "Quiz by Group";
			// 
			// tA1ToolStripMenuItem1
			// 
			this.tA1ToolStripMenuItem1.Checked = true;
			this.tA1ToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.tA1ToolStripMenuItem1.Name = "tA1ToolStripMenuItem1";
			this.tA1ToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
			this.tA1ToolStripMenuItem1.Text = "TA1";
			this.tA1ToolStripMenuItem1.Click += new System.EventHandler(this.tA1ToolStripMenuItem1_Click);
			// 
			// quizExamToolStripMenuItem
			// 
			this.quizExamToolStripMenuItem.Name = "quizExamToolStripMenuItem";
			this.quizExamToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.quizExamToolStripMenuItem.Text = "Quiz Exam";
			this.quizExamToolStripMenuItem.Click += new System.EventHandler(this.QuizExamToolStripMenuItemClick);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.testToolStripMenuItem.Text = "Simulated Exam";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.TestToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(199, 6);
			// 
			// scoreToolStripMenuItem
			// 
			this.scoreToolStripMenuItem.Name = "scoreToolStripMenuItem";
			this.scoreToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
			this.scoreToolStripMenuItem.Text = "Score";
			this.scoreToolStripMenuItem.Click += new System.EventHandler(this.ScoreToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolStripTextBox1,
									this.httphamexamwikidotcomToolStripMenuItem});
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
			this.aboutToolStripMenuItem.Text = "About";
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(130, 21);
			this.toolStripTextBox1.Text = "(C) 2006 Markus Schulz";
			this.toolStripTextBox1.Click += new System.EventHandler(this.ToolStripTextBox1Click);
			// 
			// httphamexamwikidotcomToolStripMenuItem
			// 
			this.httphamexamwikidotcomToolStripMenuItem.Name = "httphamexamwikidotcomToolStripMenuItem";
			this.httphamexamwikidotcomToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
			this.httphamexamwikidotcomToolStripMenuItem.Text = "http://hamexamhelper.sourceforge.net/";
			this.httphamexamwikidotcomToolStripMenuItem.Click += new System.EventHandler(this.HttphamexamwikidotcomToolStripMenuItemClick);
			// 
			// toolStripTextBoxTime
			// 
			this.toolStripTextBoxTime.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripTextBoxTime.Name = "toolStripTextBoxTime";
			this.toolStripTextBoxTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.toolStripTextBoxTime.Size = new System.Drawing.Size(160, 21);
			// 
			// toolStripTextBoxRight
			// 
			this.toolStripTextBoxRight.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripTextBoxRight.Name = "toolStripTextBoxRight";
			this.toolStripTextBoxRight.Size = new System.Drawing.Size(100, 21);
			// 
			// toolStripTextBoxWrong
			// 
			this.toolStripTextBoxWrong.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripTextBoxWrong.Name = "toolStripTextBoxWrong";
			this.toolStripTextBoxWrong.Size = new System.Drawing.Size(100, 21);
			// 
			// labelQuestion
			// 
			this.labelQuestion.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.World, ((byte)(0)));
			this.labelQuestion.Location = new System.Drawing.Point(12, 24);
			this.labelQuestion.Name = "labelQuestion";
			this.labelQuestion.Size = new System.Drawing.Size(608, 88);
			this.labelQuestion.TabIndex = 1;
			this.labelQuestion.Text = "Question:";
			// 
			// labelA
			// 
			this.labelA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.labelA.Location = new System.Drawing.Point(12, 133);
			this.labelA.Name = "labelA";
			this.labelA.Size = new System.Drawing.Size(608, 66);
			this.labelA.TabIndex = 2;
			this.labelA.Text = "A";
			this.labelA.Click += new System.EventHandler(this.LabelAClick);
			// 
			// labelB
			// 
			this.labelB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.labelB.Location = new System.Drawing.Point(12, 199);
			this.labelB.Name = "labelB";
			this.labelB.Size = new System.Drawing.Size(608, 66);
			this.labelB.TabIndex = 3;
			this.labelB.Text = "B";
			this.labelB.Click += new System.EventHandler(this.LabelBClick);
			// 
			// labelC
			// 
			this.labelC.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.labelC.Location = new System.Drawing.Point(12, 265);
			this.labelC.Name = "labelC";
			this.labelC.Size = new System.Drawing.Size(608, 66);
			this.labelC.TabIndex = 4;
			this.labelC.Text = "C";
			this.labelC.Click += new System.EventHandler(this.LabelCClick);
			// 
			// labelD
			// 
			this.labelD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.labelD.Location = new System.Drawing.Point(12, 331);
			this.labelD.Name = "labelD";
			this.labelD.Size = new System.Drawing.Size(606, 66);
			this.labelD.TabIndex = 5;
			this.labelD.Text = "D";
			this.labelD.Click += new System.EventHandler(this.LabelDClick);
			// 
			// buttonNext
			// 
			this.buttonNext.Location = new System.Drawing.Point(545, 405);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(75, 23);
			this.buttonNext.TabIndex = 6;
			this.buttonNext.Text = "Next >>";
			this.buttonNext.UseVisualStyleBackColor = true;
			this.buttonNext.Click += new System.EventHandler(this.ButtonNextClick);
			// 
			// buttonReplay
			// 
			this.buttonReplay.Location = new System.Drawing.Point(464, 405);
			this.buttonReplay.Name = "buttonReplay";
			this.buttonReplay.Size = new System.Drawing.Size(75, 23);
			this.buttonReplay.TabIndex = 7;
			this.buttonReplay.Text = "Replay";
			this.buttonReplay.UseVisualStyleBackColor = true;
			this.buttonReplay.Click += new System.EventHandler(this.ButtonReplayClick);
			// 
			// buttonPrevious
			// 
			this.buttonPrevious.Location = new System.Drawing.Point(383, 405);
			this.buttonPrevious.Name = "buttonPrevious";
			this.buttonPrevious.Size = new System.Drawing.Size(75, 23);
			this.buttonPrevious.TabIndex = 8;
			this.buttonPrevious.Text = "<< Previous";
			this.buttonPrevious.UseVisualStyleBackColor = true;
			this.buttonPrevious.Click += new System.EventHandler(this.ButtonPreviousClick);
			// 
			// textBoxGo
			// 
			this.textBoxGo.Location = new System.Drawing.Point(12, 407);
			this.textBoxGo.Name = "textBoxGo";
			this.textBoxGo.Size = new System.Drawing.Size(35, 20);
			this.textBoxGo.TabIndex = 9;
			this.textBoxGo.Text = "0";
			this.textBoxGo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxGo_KeyPress);
			this.textBoxGo.TextChanged += new System.EventHandler(this.TextBoxGoTextChanged);
			this.textBoxGo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxGo_KeyDown);
			// 
			// buttonGo
			// 
			this.buttonGo.Location = new System.Drawing.Point(53, 407);
			this.buttonGo.Name = "buttonGo";
			this.buttonGo.Size = new System.Drawing.Size(39, 23);
			this.buttonGo.TabIndex = 10;
			this.buttonGo.Text = "Go";
			this.buttonGo.UseVisualStyleBackColor = true;
			this.buttonGo.Click += new System.EventHandler(this.ButtonGoClick);
			// 
			// timerFlash
			// 
			this.timerFlash.Enabled = true;
			this.timerFlash.Interval = 250;
			this.timerFlash.Tick += new System.EventHandler(this.TimerFlashTick);
			// 
			// checkBoxAM
			// 
			this.checkBoxAM.Location = new System.Drawing.Point(98, 406);
			this.checkBoxAM.Name = "checkBoxAM";
			this.checkBoxAM.Size = new System.Drawing.Size(79, 24);
			this.checkBoxAM.TabIndex = 12;
			this.checkBoxAM.Text = "Auto Next";
			this.checkBoxAM.UseVisualStyleBackColor = true;
			// 
			// statusStrip1
			// 
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.LabelQnum,
									this.labelNo,
									this.toolStripProgressBar1,
									this.toolStripStatusLabel1});
			this.statusStrip1.Location = new System.Drawing.Point(0, 431);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(632, 22);
			this.statusStrip1.TabIndex = 13;
			this.statusStrip1.Text = "statusStrip1";
			this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.StatusStrip1ItemClicked);
			// 
			// LabelQnum
			// 
			this.LabelQnum.Name = "LabelQnum";
			this.LabelQnum.Size = new System.Drawing.Size(38, 17);
			this.LabelQnum.Text = "T1A01";
			// 
			// labelNo
			// 
			this.labelNo.Name = "labelNo";
			this.labelNo.Size = new System.Drawing.Size(35, 17);
			this.labelNo.Text = "0/100";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(400, 16);
			this.toolStripProgressBar1.Step = 1;
			this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			// 
			// toolStripStatusLabel1
			// 
			this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
			this.toolStripStatusLabel1.Text = " ";
			// 
			// checkBoxVoice
			// 
			this.checkBoxVoice.Location = new System.Drawing.Point(183, 407);
			this.checkBoxVoice.Name = "checkBoxVoice";
			this.checkBoxVoice.Size = new System.Drawing.Size(61, 24);
			this.checkBoxVoice.TabIndex = 14;
			this.checkBoxVoice.Text = "Voice";
			this.checkBoxVoice.UseVisualStyleBackColor = true;
			this.checkBoxVoice.CheckedChanged += new System.EventHandler(this.CheckBoxVoiceCheckedChanged);
			// 
			// pictureBoxE
			// 
			this.pictureBoxE.Location = new System.Drawing.Point(315, 115);
			this.pictureBoxE.Name = "pictureBoxE";
			this.pictureBoxE.Size = new System.Drawing.Size(305, 286);
			this.pictureBoxE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxE.TabIndex = 28;
			this.pictureBoxE.TabStop = false;
			this.pictureBoxE.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 453);
			this.Controls.Add(this.checkBoxVoice);
			this.Controls.Add(this.checkBoxAM);
			this.Controls.Add(this.buttonGo);
			this.Controls.Add(this.textBoxGo);
			this.Controls.Add(this.pictureBoxE);
			this.Controls.Add(this.buttonNext);
			this.Controls.Add(this.buttonReplay);
			this.Controls.Add(this.buttonPrevious);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.labelD);
			this.Controls.Add(this.labelB);
			this.Controls.Add(this.labelA);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.labelQuestion);
			this.Controls.Add(this.labelC);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "HamExamHelper V1.1";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxE)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem httphamexamwikidotcomToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBoxE;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.ToolStripMenuItem cWToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quizExamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showExamAnswersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem scoreToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBoxTime;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBoxWrong;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBoxRight;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quizToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showAnswersToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem modeToolStripMenuItem;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripStatusLabel LabelQnum;
		private System.Windows.Forms.CheckBox checkBoxVoice;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.CheckBox checkBoxAM;
		private System.Windows.Forms.Timer timerFlash;
		private System.Windows.Forms.TextBox textBoxGo;
		private System.Windows.Forms.ToolStripStatusLabel labelNo;
		private System.Windows.Forms.Button buttonGo;
		private System.Windows.Forms.Button buttonPrevious;
		private System.Windows.Forms.Button buttonReplay;
		private System.Windows.Forms.Button buttonNext;
		private System.Windows.Forms.Label labelD;
		private System.Windows.Forms.Label labelC;
		private System.Windows.Forms.Label labelB;
		private System.Windows.Forms.Label labelA;
		private System.Windows.Forms.Label labelQuestion;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem generalToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem techToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showAnswersByGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tA1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quizByGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tA1ToolStripMenuItem1;
		

	}
}
