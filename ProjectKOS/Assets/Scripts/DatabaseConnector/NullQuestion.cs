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
    /**
     * Null Object pattern for Questions
     */ 

    public class NullQuestion : Question
    {
        /**
         * Default Constructor
         */ 

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
