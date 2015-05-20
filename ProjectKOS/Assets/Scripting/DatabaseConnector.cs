/**
 * Filename: DatabaseConnector.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 0
 * Rev. Date: 5/4/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

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
            try
            {

            }

            catch (SqliteException e)
            {
                Console.WriteLine("Error occurred accessing database.");
            }
            
            
            return new QuestionPool(); //TODO
        }

        private string GenerateQuery(QuestionQuery query)
        {
            return "SELECT * FROM Meta NATURAL JOIN Questions";
            //TODO, change this to actually select the correct questions as per the query
        }


	}
}
