/**
 * Filename: AnswerPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;

namespace Database {

	public class AnswerPool : IEnumerable<Answer> {

        public List<Answer> Answers
        {
            get
            {
                return this.Answers;
            }

            protected set
            {
                this.Answers = value;
            }
        }

        public int Size
        {
            get
            {
                return Answers.Count;
            }

            private set { }
        }
        public AnswerPool()
        {
            this.Answers = new List<Answer>();
        }

        public void AddAnswer(Answer answer)
        {
            this.Answers.Add(answer);
        }

        public Answer Get(int index)
        {
            if (index > 0 && index < Answers.Count)
                return Answers[index];

            return new NullAnswer();
        }

        public IEnumerator<Answer> GetEnumerator()
        {
            return Answers.GetEnumerator();
        }
	}
}
