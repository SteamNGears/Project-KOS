/**
 * Filename: QuestionPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;

namespace Database {

	public class QuestionPool : IEnumerable<Question> {

        public List<Question> Questions
        {
            get
            {
                return this.Questions;
            }

            protected set
            {
                this.Questions = value;
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

        public IEnumerator<Question> GetEnumerator()
        {
            return Questions.GetEnumerator();
        }

        public int Size()
        {
            return Questions.Count;
        }

        public Question GetQuestion(int index)
        {
            if (index > 0 && index < Questions.Count)
                return Questions[index];

            return new NullQuestion();
        }
	}
}
