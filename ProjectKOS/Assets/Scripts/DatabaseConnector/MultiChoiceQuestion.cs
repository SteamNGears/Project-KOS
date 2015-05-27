/**
 * Filename: MultiChoiceQuestion.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/20/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

    /**
     * Class represents a multi-choice question. As it stands currently is only a wrapper for creating a
     * question and then representing it abstractly, can have added functionality later
     * @see Question
     * @author Aryk Anderson
     */ 
	public class MultiChoiceQuestion : Question
    {
        /**
         * Default Constructor sets question Type to MULTIPLE_CHOICE
         * @returns MultiChoiceQuestion
         */
        
        public MultiChoiceQuestion()
        {
            this.Type = "MULTIPLE_CHOICE";
        }


        /**
         * Constructor to create a MultiChoice Question using all the needed variables
         * @returns MultiChoiceQuestion
         */
        
        public MultiChoiceQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "MULTIPLE_CHOICE", difficulty, qString, id)
        { }
	}
}
