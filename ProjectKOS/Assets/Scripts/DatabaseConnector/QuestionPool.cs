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

    /**
     * Wraps around a list of questions and provides an interface to access and remove those questions.
     * Could have just used a List<Question>, but this allows us to extend functionality later
     * @author Aryk Anderson
     */
        
	public class QuestionPool : IEnumerable<Question> {

        private List<Question> _questions;

        /**
         * Read only access to the list of questions in the pool
         * @returns List<Question>
         */
 
        public List<Question> Questions
        {
            get
            {
                return new List<Question>(_questions);
            }

            protected set
            {
                _questions = value;
            }
        }


        /**
         * Read only access to the number of questions contained
         * @returns int
         */
        
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


        /**
         * Default Constructor
         * @returns QuestionPool
         */
        
        public QuestionPool()
        {
            this.Questions = new List<Question>();
        }


        /**
         * Creates a new question pool with the list of questions being assigned a
         * previously constructed list
         * @returns QuestionPool
         */
        
        public QuestionPool(List<Question> questionsList)
        {
            this.Questions = questionsList;
        }


        /**
         * Indexing function
         * @throws ArrayIndexOutOfBoundsException
         * @returns Question
         */
        
        public Question this[int index]
        {
            get { return Questions[index]; }
            set { Questions[index] = value; }
        }


        /**
         * Implementation of the IEnumerable interface
         * @returns IEnumerator<Question>
         */
        
        public IEnumerator<Question> GetEnumerator()
        {
            return Questions.GetEnumerator();
        }


        /**
         * Implementation of non-generic IEnumerable interface needed for compliling reasons
         * @returns IEnumerator
         */
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
	}
}
