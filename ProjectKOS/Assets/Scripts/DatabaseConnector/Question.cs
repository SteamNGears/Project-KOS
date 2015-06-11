/**
 * Filename: Question.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 2
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */


using System.Collections;
using SaveLoad;

namespace Database {

    /**
     * Represents a question, is a data class CURRENTLY with a list of properties that can be accessed
     * The class is mostly for intuitive access to questions.
     * @author Aryk Anderson
     */ 

	public abstract class Question : ISaveable{

        /**
         * Readonly access to the ID property
         * @returns string
         */
        
        public string ID 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Subject property
         * @returns string
         */
        
		public string Subject 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Type
         * @returns string
         */
        
        public string Type 
		{
			get;

			protected set;
        }


        /**
         * Readonly access to Difficutly
         * @returns int
         */
        
        public int Difficulty 
		{
			get;

			protected set; 
        }


        /**
         * Readonly access to the question string
         * @returns string
         */
        
        public string QuestionString 
		{
			get;

			protected set;
        }


        /**
         * Access to the pool of answers
         * @returns AnswerPool
         */
        
        public AnswerPool Answers 
		{
			get;

			set;
        }


        /**
         * Default Constructor
         * @returns Question
         */
        
        public Question()
        {
            this.Answers = new AnswerPool();
        }


        /**
         * Constructor that returns usable object
         * @param string subject
         * @param string type
         * @param int difficutly
         * @param string qString
         * @param string id
         * @returns Question
         */
        
        public Question(string subject, string type, int difficulty, string qString, string id)
        {
            this.Subject = subject;
            this.Type = type;
            this.Difficulty = difficulty;
            this.QuestionString = qString;
			this.ID = id;
        }

        /**
         * Method that will be registered with SaveLoadManager in order to write data to disk.
         * Internals should look something like:
         * SaveLoadManager.Instance.AddSaveData(this.ObjectID(), this.Save());
         */

        public void LoadObject()
        {
            //NotImplemented!
        }


        /**
         * Method that will be registered with SaveLoadManager in order to load data from disk.
         * Internals should look something like:
         * this.Load(SaveLoadManager.Instance.GetSaveData(this.ObjectID()));
         */

        public void SaveObject()
        {
            //Not implemented!
        }


        /**
         * Method should return a unique object ID for the object to be saved
         * @returns string ID
         */

        public string ObjectID()
        {
            return "Question" + ID;
        }


        /**
         * Method should save the relevant data to be saved in a SaveData object that
         * can have all of its fields serialized.
         * @returns SaveData
         */

        public SaveData Save()
        {
            return null;
        }


        /**
         * Method should take an unserialized object and then load all of the previously saved fields into
         * memory.
         * @params SaveData
         */

        public void Load(SaveData data)
        {
            //TODO
        }
	}
}
