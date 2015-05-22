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

	public class ShortAnswerQuestion : Question
    {
        public ShortAnswerQuestion()
        {
            this.Type = "SHORT_ANSWER";
        }

        public ShortAnswerQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "MULTIPLE_CHOICE", difficulty, qString, id)
        { }

	}
}
