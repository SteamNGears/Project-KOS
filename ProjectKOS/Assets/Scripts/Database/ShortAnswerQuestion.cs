/**
 * Filename: ShortAnswerQuestion.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
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

        public ShortAnswerQuestion(string subject, int difficulty, string qString) :
            base(subject, "MULTIPLE_CHOICE", difficulty, qString)
        { }

	}
}
