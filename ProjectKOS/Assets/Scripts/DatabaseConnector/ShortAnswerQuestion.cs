/**
 * Filename: ShortAnswerQuestion.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

    /**
     * Class that represents a Short Answer Question. Currently isn't more than a wrapper around question
     * @see Question
     * @author Aryk Anderson
     */
        
	public class ShortAnswerQuestion : Question
    {
        /**
         * Default Constructor
         * @returns ShortAnswerquestion
         */
        
        public ShortAnswerQuestion()
        {
            this.Type = "SHORT_ANSWER";
        }


        /**
         * Constructor to get a useful question
         * @param string subject
         * @param int difficulty
         * @param string qString
         * @param string id
         * @returns ShortAnswerQuestion
         */
        
        public ShortAnswerQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "SHORT_ANSWER", difficulty, qString, id)
        { }

	}
}
