/**
 * Filename: AnswerPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;
using System.Collections;

namespace Database {

	public class AnswerPool : System.Collections.Generic.IEnumerable<Answer> {

        public List<Answer> Answers
        {
            get;

            protected set;
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

        public Answer this[int index] 
        {
            get { return Answers[index]; }
            set { Answers[index] = value; }
        }

        public IEnumerator<Answer> GetEnumerator()
        {
            return Answers.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

	}
}
