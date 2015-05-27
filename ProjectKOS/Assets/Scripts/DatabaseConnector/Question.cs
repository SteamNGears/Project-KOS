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

    /**
     * Represents a question, is a data class CURRENTLY with a list of properties that can be accessed
     * The class is mostly for intuitive access to questions.
     * @author Aryk Anderson
     */ 

	public abstract class Question {

        /**
         * Readonly access to the ID property
         * @returns string
         */
        
        public string ID 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Subject property
         * @returns string
         */
        
		public string Subject 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Type
         * @returns string
         */
        
        public string Type 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Difficutly
         * @returns int
         */
        
        public int Difficulty 
		{
			get;

			protected set; 
        }


        /**
         * Readonly access to the question string
         * @returns string
         */
        
        public string QuestionString 
		{
			get;

			protected set;
        }


        /**
         * Access to the pool of answers
         * @returns AnswerPool
         */
        
        public AnswerPool Answers 
		{
			get;

			set;
        }


        /**
         * Default Constructor
         * @returns Question
         */
        
        public Question()
        {
            this.Answers = new AnswerPool();
        }


        /**
         * Constructor that returns usable object
         * @param string subject
         * @param string type
         * @param int difficutly
         * @param string qString
         * @param string id
         * @returns Question
         */
        
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
