/**
 * Filename: Answer.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;
using System;

namespace Database {

	public class Answer {

        public string AnswerString
        {
            get;

            set;
        }

        public bool Correct
        {
            get;

            set;
        }

        protected Answer()
        {
            this.AnswerString = "";
            this.Correct = false;
        }

        public Answer(string answerString, bool correct)
        {
            this.AnswerString = answerString;
            this.Correct = correct;
        }

        public Answer(string answerString, string correct)
        {
            this.AnswerString = answerString;

            if (Int32.Parse(correct) == 0)
                this.Correct = false;
            else
                this.Correct = true;
        }
	}
}
