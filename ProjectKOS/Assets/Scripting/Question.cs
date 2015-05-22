/**
 * Filename: Question.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */


using System.Collections;

namespace Database {

	public abstract class Question {

        public string Subject
        {
            get
            {
                return Subject;
            }

            protected set
            {
                this.Subject = value;
            }
        }

        public string Type
        {
            get
            {
                return Type;
            }

            protected set
            {
                this.Type = value;
            }
        }

        public int Difficulty
        {
            get
            {
                return Difficulty;
            }

            protected set
            {
                this.Difficulty = value;
            }
        }

        public string QuestionString
        {
            get
            {
                return QuestionString;
            }

            protected set
            {
                this.QuestionString = value;
            }
        }

        public AnswerPool Answers
        {
            get
            {
                return Answers;
            }

            set
            {
                this.Answers = value;
            }
        }

        /**
         * This method's return type needs to change to whatever we end up using for the GUI.
         * The method should return it's GUI display to be embedded in whatever document we
         * want to display it in. This will be moved to an interface when we define it.
         */

        public Question()
        {
            this.Answers = new AnswerPool();
        }

        public Question(string subject, string type, int difficulty, string qString)
        {
            this.Subject = subject;
            this.Type = type;
            this.Difficulty = difficulty;
            this.QuestionString = qString;
        }
	}
}
