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
