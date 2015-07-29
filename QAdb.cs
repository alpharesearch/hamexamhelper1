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
 * User: $Author: alpharesearch $
 * Date: $LastChangedDate: 2007-04-21 00:38:35 -0400 (Sat, 21 Apr 2007) $
 * Rev : $Rev: 19 $
 * 
 * ID: $Id: QAdb.cs 19 2007-04-21 04:38:35Z alpharesearch $
 */
using System;

namespace HamExamHelper
{
	/// <summary>
	/// Description of QAdb.
	/// </summary>
	public class QAobj
	{
		public string QuestionNumber {
			get {
				return questionNumber;
			}
			set {
				questionNumber = value;
			}
		}
		
		public string RightAnswer {
			get {
				return rightAnswer;
			}
			set {
				rightAnswer = value;
			}
		}
		
		public string Question {
			get {
				return question;
			}
			set {
				question = value;
			}
		}
		public string AnswerA {
			get {
				return answerA;
			}
			set {
				answerA = value;
			}
		}
		
		public string AnswerB {
			get {
				return answerB;
			}
			set {
				answerB = value;
			}
		}
		
		public string AnswerC {
			get {
				return answerC;
			}
			set {
				answerC = value;
			}
		}
		
		public string AnswerD {
			get {
				return answerD;
			}
			set {
				answerD = value;
			}
		}
		public bool Quiz {
			get {
				return quiz;
			}
			set {
				quiz = value;
			}
		}
		
		public bool Right {
			get {
				return right;
			}
			set {
				right = value;
			}
		}
		
		public string QuestionGroup {
			get {
				return questionNumber.Substring(1, 2);
			}
			
		}

        public string QuestionGroup1
        {
            get
            {
                return questionNumber.Substring(1, 1);
            }

        }

        public string QuestionGroup2
        {
            get
            {
                return questionNumber.Substring(0, 2);
            }

        }

        public string QuestionGroup3
        {
            get
            {
                return questionNumber.Substring(0, 3);
            }

        }
		public string SelectedAnswer {
			get {
				return selectedAnswer;
			}
			set {
				selectedAnswer = value;
			}
		}
		public string Picture {
			get {
				return picture;
			}
			set {
				picture = value;
			}
		}
		
		private string questionNumber;
		private string rightAnswer;
		private string question;
		private string answerA;
		private string answerB;
		private string answerC;
		private string answerD;
		private bool quiz=false;
		private bool right=false;
		private string selectedAnswer;
		private string picture;
		
		public QAobj()
		{
		}
		
		public QAobj(string n, string a, string q, string anA, string anB, string anC, string anD)
		{
		questionNumber=n;
		rightAnswer=a;
		Question=q;
		answerA=anA;
		answerB=anB;
		answerC=anC;
		answerD=anD;
		}
	}
}
