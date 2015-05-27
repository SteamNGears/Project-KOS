/**
 * Filename: TrueFalseQuestion.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

    /**
     * Encapsulation of a true-false question, does not have additional functionality beyond question currently,
     * but easily implemented later when we do want it.
     * @author Aryk Anderson
     */ 

	public class TrueFalseQuestion : Question
    {
        /**
         * Default constructor
         * @returns TrueFalseQuestion
         */ 

        public TrueFalseQuestion() 
        {
            this.Type = "TRUE_FALSE";
        }


        /**
         * Constructor returns a useful question
         * @param string subject
         * @param int difficulty
         * @param string qString
         * @param string id
         * @returns TrueFalseQuestion
         */
        
        public TrueFalseQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "TRUE_FALSE", difficulty, qString, id)
        { }

	}
}
