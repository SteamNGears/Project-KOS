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

	public class MultiChoiceQuestion : Question
    {
        public MultiChoiceQuestion()
        {
            this.Type = "MULTIPLE_CHOICE";
        }

        public MultiChoiceQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "MULTIPLE_CHOICE", difficulty, qString, id)
        { }
	}
}
