/**
 * Filename: Question.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 2
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */


using System.Collections;

namespace Database {

	public abstract class Question {

        public string ID 
		{
			get;

			protected set;
        }
        
		public string Subject 
		{
			get;

			protected set;
        }

        public string Type 
		{
			get;

			protected set;
        }

        public int Difficulty 
		{
			get;

			protected set; 
        }

        public string QuestionString 
		{
			get;

			protected set;
        }

        public AnswerPool Answers 
		{
			get;

			set;
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

        public Question(string subject, string type, int difficulty, string qString, string id)
        {
            this.Subject = subject;
            this.Type = type;
            this.Difficulty = difficulty;
            this.QuestionString = qString;
			this.ID = id;
        }
	}
}
