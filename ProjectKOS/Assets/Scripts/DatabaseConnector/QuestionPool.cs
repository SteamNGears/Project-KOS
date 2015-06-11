/**
 * Filename: QuestionPool.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections.Generic;
using SaveLoad;

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
         * Adds a question to the pool
         * @param Question newQuestion
         */

        public void AddQuestion(Question newQuestion)
        {
            _questions.Add(newQuestion);
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


        /**
         * Method that will be registered with SaveLoadManager in order to write data to disk.
         * Internals should look something like:
         * SaveLoadManager.Instance.AddSaveData(this.ObjectID(), this.Save());
         */

        public void LoadObject() 
        {
            this.Load(SaveLoadManager.Instance.GetSaveData(this.ObjectID()));
        }


        /**
         * Method that will be registered with SaveLoadManager in order to load data from disk.
         * Internals should look something like:
         * this.Load(SaveLoadManager.Instance.GetSaveData(this.ObjectID()));
         */

        public void SaveObject()
        {
            SaveLoadManager.Instance.AddSaveData(this.ObjectID(), this.Save());
        }


        /**
         * Method should return a unique object ID for the object to be saved
         * @returns string ID
         */ 

        public string ObjectID() 
        {
            if (Count > 0)
                return "QuestionPool" + _questions[0].ID;

            else
                return "QuestionPool" + this;
        }


        /**
         * Method should save the relevant data to be saved in a SaveData object that
         * can have all of its fields serialized.
         * @returns SaveData
         */

        public SaveData Save()
        {
            return new QuestionPoolSaveData(this);
        }


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */

        public void Load(SaveData data)
        {
            _questions.Clear();

            try
            {
                QuestionPoolSaveData poolData = (QuestionPoolSaveData) data;
                QuestionSaveData[] questionData = (QuestionSaveData[]) poolData.Questions;

                for (int i = 0; i < questionData.Length; i++)
                {

                    Question temp = new Question();
                    temp.Load(questionData[i]);

                    this.AddQuestion(temp);
                }
            }

            catch (System.InvalidCastException e)
            {
                UnityEngine.Debug.Log(e.Message);
            }

            catch (System.Exception e)
            {
                UnityEngine.Debug.Log(e.Message);
            }
        }
	}
}
