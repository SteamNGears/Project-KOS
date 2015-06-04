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

    /**
     */
 
	public class AnswerPool : System.Collections.Generic.IEnumerable<Answer> {

        /**
         * Readonly property to grab a copy of the list of answers
         * @returns List<Answer>
         */

        private List<Answer> _answers;
        public List<Answer> Answers
        {
            get
            {
                return new List<Answer>(_answers);
            }

            protected set
            {
                _answers = value;
            }
        }


        /**
         * Property that returns the count of Answers
         * @returns int
         */

        public int Size
        {
            get
            {
                return _answers.Count;
            }

            protected set
            {
                return;
            }
        }


        /**
         * Default constructor for an AnswerPool, constructs a new List to hold answers
         * @returns AnswerPool
         */
        
        public AnswerPool()
        {
            this.Answers = new List<Answer>();
        }


        /**
         * Method to add an answer to the pool
         * @param Answer answer - the answer to insert
         */
        
        public void AddAnswer(Answer answer)
        {
            this._answers.Add(answer);
        }


        /**
         * Accessor to get the value inside the list at the specified index
         * @throws ArrayIndexOutOfBoundsException
         */
        
        public Answer this[int index] 
        {
            get { return _answers[index]; }
            set { _answers[index] = value; }
        }


        /**
         * Implementation of IEnumerable interface for generics
         * @returns IEnumerator<Answer>
         */
        
        public IEnumerator<Answer> GetEnumerator()
        {
            return _answers.GetEnumerator();
        }


        /**
         * Implementation of IEnumerable interface for non-generics
         * @returns IEnumerator
         */
        
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
	}
}
