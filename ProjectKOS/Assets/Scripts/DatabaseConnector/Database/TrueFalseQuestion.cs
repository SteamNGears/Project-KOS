﻿/**
 * Filename: TrueFalseQuestion.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion() 
        {
            this.Type = "TRUE_FALSE";
        }
        public TrueFalseQuestion(string subject, int difficulty, string qString, string id) :
            base(subject, "TRUE_FALSE", difficulty, qString, id)
        { }

	}
}