/**
 * Filename: DatabaseConnector.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;

namespace Database {

	public class DatabaseConnector {

        public static DatabaseConnector Instance
        {
            get
            {
                if (Instance == null)
                    return (Instance = new DatabaseConnector());

                return Instance;
            }

            protected set
            {
                Instance = value;
            }
        }

        public DatabaseConnector() { }

        public QuestionPool GetQuestions(QuestionQuery query)
        {
            return new QuestionPool(); //TODO
        }

	}
}
