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
            this.Type = "";
        }

        public int DisplayForm()
        {
            return 0;
            //TODO change this to GUI stuff
        }
    }
}
