/**
 * Filename: Answer.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class Answer {

        public string AnswerString
        {
            get
            {
                return this.AnswerString;
            }

            set
            {
                this.AnswerString = value;
            }
        }

        public bool Correct
        {
            get
            {
                return this.Correct;
            }

            set
            {
                this.Correct = value;
            }
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
	}
}
