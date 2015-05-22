/**
 * Filename: AnswerPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;

namespace Database
{
    public class NullQuestion : Question
    {

        public NullQuestion()
        {
            this.Answers = new AnswerPool();
            this.Difficulty = 0;
            this.QuestionString = "";
            this.Subject = "";
            this.Type = "NULL";
        }
    }
}
