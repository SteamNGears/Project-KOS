/**
 * Filename: QuestionPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;

namespace Database {

	public class QuestionPool : IEnumerable<Question> {

        public List<Question> Questions
        {
            get;

            protected set;
        }

        public int Count
        {
            get
            {
                return Questions.Count;
            }

            private set
            {

            }
        }

        public QuestionPool()
        {
            this.Questions = new List<Question>();
        }

        public QuestionPool(List<Question> questionsList)
        {
            this.Questions = questionsList;
        }

        public Question this[int index]
        {
            get { return Questions[index]; }
            set { Questions[index] = value; }
        }

        public IEnumerator<Question> GetEnumerator()
        {
            return Questions.GetEnumerator();
        }

        public Question GetQuestion(int index)
        {
            if (index > 0 && index < Questions.Count)
                return Questions[index];

            return new NullQuestion();
        }
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
	}
}
