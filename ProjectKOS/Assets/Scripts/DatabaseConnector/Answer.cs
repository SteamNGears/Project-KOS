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

    /**
     * Data class that contains an answer string and a boolean indicating correctness. Not strictly necessary,
     * but makes referencing intuitive. Also gives more control if we want to do more later
     * 
     * @author Aryk Anderson
     */ 

	public class Answer {

        /**
         * Default property for a string defining the actual text of the answer
         * @returns string
         */ 

        public string AnswerString
        {
            get;

            protected set;
        }


        /**
         * Default property indicating correctness of answer
         * @returns bool
         */ 

        public bool Correct
        {
            get;

            protected set;
        }


        /**
         * Default constructor for Answer. Creates Answer with null string that is a false answer
         * @returns Answer
         */ 

        protected Answer()
        {
            this.AnswerString = "";
            this.Correct = false;
        }


        /**
         * Constructor for answer that actually returns a useful answer
         * @returns Answer
         */ 

        public Answer(string answerString, bool correct)
        {
            this.AnswerString = answerString;
            this.Correct = correct;
        }


        /**
         * Constructor for answer that actually returns a useful answer. Takes a string
         * as a 1 or 0 indicating true/false and can throw an error. Don't let it throw an error
         * 
         * @returns Answer
         * @throws System.ArgumentNullException
         * @throws System.FormatException
         * @throws System.OverflowException
         */

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
