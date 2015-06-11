/**
 * Filename: DatabaseConnector.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 5
 * Rev. Date: 5/27/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

namespace Database {

    /**
     * This class is solely responsible for all the connections and transactions with the database.
     * It uses Singleton pattern as it is useful to provide a global access point to a single connector
     * as well as ensuring that all the transactions that are performed in the database are not
     * conflicting with each other. Though synchronization issues are not yet a problem, they can be
     * easily dealt with within this single class.
     * 
     * @author Aryk Anderson
     */
 
	public class DatabaseConnector {

        private static string ConnectionString = "Data Source=Database/Questions.db;Version=3;";
        private static DatabaseConnector _instance = null;
        

        /**
         * This is the static property that enforces singleton access. 
         * Done through a property to make it look cleaner
         * 
         * @returns DatabaseConnector - the private instance that is maintained by this class
         */
 
		public static DatabaseConnector Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DatabaseConnector();

                return _instance;
            }

            protected set
            {
                _instance = value;
            }
        }
        

        /**
         * Default constructor. Does not need any information to create this object, made private to
         * enforce access requirements
         * 
         * @returns DatabaseConnector
         */ 

        private DatabaseConnector() 
        {   }


        /**
         * Main piece of functionality for the class, returns pre-constructed questions from the database
         * 
         * @param QuestionQuery query - the list of filters on the questions to return
         * @returns QuestionPool questions - a wrapped list of constructed questions
         * @see QuestionPool
         * @see QuestionQuery
         */ 

        public QuestionPool GetQuestions(QuestionQuery query)
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(ConnectionString)) 
                { 
                    conn.Open();

                    using (SqliteCommand cmd = new SqliteCommand(conn))
                    {
                        cmd.CommandText = GenerateQueryString(query);
                        SqliteDataReader reader = cmd.ExecuteReader();
                        QuestionPool questions = CreateQuestions(reader, conn);
                        ApplyAdditionalQueries(questions, query);

                        return questions;
                    }
                }
            }

            catch (SqliteException e)
            {
                Debug.Log("Error occurred accessing database.");
                Debug.Log(e.Message);
            }

            catch (Exception e)
            {
                Debug.Log("NonSQL error occurred.");
                Debug.Log(e.Message);
            }
            
            return new QuestionPool(); //Returns an empty Question Pool if error occurs
        }


        /** 
         * Template method for adding addition filters to the QuestionPool called inside GetQuestions.
         * Can only check against already created questions and filter those out. Use this for things
         * such as randomization
         * 
         * @param QuestionPool pool - questions to apply query against
         * @param QuestionQuery query - list of filters to apply against pool. 
         * Method should ignore Difficulty, Subject and Type restraints
         * 
         * @returns QuestionPool pool - the modified list of questions
         */ 

        protected QuestionPool ApplyAdditionalQueries(QuestionPool pool, QuestionQuery query)
        {
            return pool;
        }


        /**
         * This method generates the SQL string to query against the database. Only looks at Type, Difficulty and Subject
         * restraints withing the query.
         * 
         * @param QuestionQuery query - list of filters to apply
         * @returns string queryString - generated SQL string
         */ 

        public string GenerateQueryString(QuestionQuery query)
        {
            string queryString = "SELECT * FROM Meta NATURAL JOIN Questions";
            string subject = "";
            string difficulty = "";
            string type = "";

			if (query == null)
				return queryString;

            List<Restraint> restraints = query.Restraints;

            if (restraints.Count == 0)
                return queryString;

            /* The idea of the algorithm is to go through and for every restraint type, create a stand alone logical
             * statement that will capture the data from those restraints. This logic can handle any amount of
             * restraints including multiple of the same type. All the restraints are essentially filters, we don't need
             * anything more complicated, but if we did, we would need a much more complicated setup
             */ 

            for (int i = 0; i < restraints.Count; i++)
            {
                if (restraints[i].RetraintType.Equals("DIFFICULTY"))
                {
                    if (restraints[i].NumArgs() == 1)
                    {
                        if (difficulty.Equals(""))
                        {
                            difficulty += " (Difficulty = " + restraints[i].Value;
                        }

                        else
                        {
                            difficulty += " or Difficulty = " + restraints[i].Value;
                        }
                    }

                    else
                    {
                        string[] values = restraints[i].GetRange();

                        if (difficulty.Equals(""))
                        {
                            difficulty += " ((Difficulty > " + values[0] + " and Difficulty < " + values[1] + ")"; 
                        }

                        else
                        {
                            difficulty += " or (Difficulty > " + values[0] + " and Difficulty < " + values[1] + ")"; 
                        }
                    }
                }

                else if (restraints[i].RetraintType.Equals("SUBJECT"))
                {
                    if (subject.Equals(""))
                    {
                        subject += " (Subject = \"" + restraints[i].Value + "\"";
                    }

                    else
                    {
                        subject += " or Subject = \"" + restraints[i].Value + "\"";
                    }
                }

                else if (restraints[i].RetraintType.Equals("TYPE"))
                {
                    if (type.Equals(""))
                    {
                        type += " (Type = \"" + restraints[i].Value + "\"";
                    }

                    else
                    {
                        type += " or Type = \"" + restraints[i].Value + "\"";
                    }
                }

                else
                    continue;
            }

            /* Below is a very very naiive implementation of how restraints should be cleaned up to create a proper string
             * Much more thought needs to go into this if we need to be able to add many restraints
             */ 

            if (!difficulty.Equals("") || !subject.Equals("") || !type.Equals(""))
                queryString += " WHERE";

            if (!difficulty.Equals(""))
                difficulty += ")";

            if (!subject.Equals(""))
                subject += ")";

            if (!type.Equals(""))
                type += ")";

            if ((!difficulty.Equals("") || !subject.Equals("")) && !type.Equals(""))
                type = " AND" + type;

            if (!difficulty.Equals("") && !subject.Equals(""))
                subject = " AND" + subject;

			queryString = queryString + difficulty + subject  + type;

            return queryString;
        }


        /**
         * Takes a pre-constructed question and then inserts that question properly into the database
         * 
         * @param Question question - the question to insert into the database
         * @returns bool success
         */ 

        public bool InsertQuestion(Question question)
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(ConnectionString))
                {
                    using (SqliteCommand cmd = new SqliteCommand(conn))
                    {
                        int id;

                        conn.Open();

                        cmd.CommandText = "Select MAX(ID) AS ID From Meta;";

                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            id = Int32.Parse(reader["ID"].ToString()) + 1;
                        }

                        InsertIntoMeta(cmd, question, id);
                        InsertIntoQuestions(cmd, question, id);
                        InsertIntoAnswers(cmd, question, id);

                        return true;
                    }
                }
            }

            catch (SqliteException e)
            {
                Debug.Log(e.Message);
            }

            return false;

        }


        /**
         * Private helper method to InsertQuestion to insert into one of the database tables
         * 
         * @param SqliteCommand cmd - a Sqlite command object keyed to an already open connection in the database
         * @param Question question - the question to insert
         * @param int id - the new id of the question to insert
         */ 

        private void InsertIntoMeta(SqliteCommand cmd, Question question, int id)
        {
            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Meta VALUES (@param1,@param2,@param3,@param4);";

            int Difficulty = question.Difficulty;
            string Subject = question.Subject;
            string Type = question.Type;
            
            cmd.Parameters.Add(new SqliteParameter("@param1", id));
            cmd.Parameters.Add(new SqliteParameter("@param2", Difficulty));
            cmd.Parameters.Add(new SqliteParameter("@param3", Subject));
            cmd.Parameters.Add(new SqliteParameter("@param4", Type));

            cmd.Prepare();
            Debug.Log(cmd.CommandText);

            //uncomment these after debugging is finished
            Debug.Log(cmd.ExecuteNonQuery());
            cmd.Parameters.Clear();
        }


        /**
         * Private helper method to InsertQuestion to insert into one of the database tables
         * 
         * @param SqliteCommand cmd - a Sqlite command object keyed to an already open connection in the database
         * @param Question question - the question to insert
         * @param int id - the new id of the question to insert
         */ 

        private void InsertIntoAnswers(SqliteCommand cmd, Question question, int id)
        {
            //Debug.Log("Inside InsertIntoAnswers");

            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Answers VALUES (@param1,@param2,@param3);";
            AnswerPool answers = question.Answers;

            //Debug.Log(answers.Size);

            foreach(Answer temp in answers)
            {
                string aString = temp.AnswerString;
                bool correct = temp.Correct;

                cmd.Parameters.Add(new SqliteParameter("@param1", id));
                cmd.Parameters.Add(new SqliteParameter("@param2", aString));
                cmd.Parameters.Add(new SqliteParameter("@param3", correct));

                //Debug.Log("Before command prep");
                cmd.Prepare();
                Debug.Log(cmd.CommandText);

                //uncomment these after debugging is finished
                Debug.Log(cmd.ExecuteNonQuery());
                cmd.Parameters.Clear();
            }   
        }


        /**
         * Private helper method to InsertQuestion to insert into one of the database tables
         * 
         * @param SqliteCommand cmd - a Sqlite command object keyed to an already open connection in the database
         * @param Question question - the question to insert
         * @param int id - the new id of the question to insert
         */ 

        private void InsertIntoQuestions(SqliteCommand cmd, Question question, int id)
        {
            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Questions VALUES (@param1,@param2);";

            string qString = question.QuestionString;

            cmd.Parameters.Add(new SqliteParameter("@param1", id));
            cmd.Parameters.Add(new SqliteParameter("@param2", qString));

            cmd.Prepare();
            Debug.Log(cmd.CommandText);

            //uncomment these after debugging is finished
            Debug.Log(cmd.ExecuteNonQuery());
            cmd.Parameters.Clear();
        }


        /**
         * Helper method to GetQuestions that takes in the already executed reader and generates questions
         * based on the contents inside its fields
         * 
         * @param SqliteDataReader reader - opened reader of the questions to retrieve
         * @param Sqliteconnection conn - opened connection to the database
         */ 

        private QuestionPool CreateQuestions(SqliteDataReader reader, SqliteConnection conn)
        {
            List<Question> questions = new List<Question>();
            Dictionary<String, AnswerPool> answers = new Dictionary<string, AnswerPool>();
            string answersQuery = "";

            /* While loop reads through all the records returned. It grabs the type first and from there creates the
             * right type of question using the other information in the records. IF the type of the question is not recognizeable
             * then a NullQuestion is created and reader continues to read through records. Every question read in adds a SQL
             * query to grab the answers to the question from the Answers table. Those will all be executed at once.
             */ 
            while (reader.Read())
            {
                string type = reader["Type"].ToString();

                if (type.Equals("TRUE_FALSE"))
                {
                    questions.Add(new TrueFalseQuestion(reader["Subject"].ToString(), 
                                                        Int32.Parse(reader["Difficulty"].ToString()), 
                                                        reader["QString"].ToString(), 
                                                        reader["ID"].ToString()));

                    answersQuery += "SELECT * From Answers WHERE ID = " + reader["ID"].ToString() + ";";
                }

                else if (type.Equals("MULTIPLE_CHOICE"))
                {
                    questions.Add(new MultiChoiceQuestion(reader["Subject"].ToString(), 
                                                          Int32.Parse(reader["Difficulty"].ToString()), 
                                                          reader["QString"].ToString(), 
                                                          reader["ID"].ToString()));

					answersQuery += "SELECT * From Answers WHERE ID = " + reader["ID"] + ";";
                }

                else if (type.Equals("SHORT_ANSWER"))
                {
                    questions.Add(new ShortAnswerQuestion(reader["Subject"].ToString(), 
                                                          Int32.Parse(reader["Difficulty"].ToString()), 
                                                          reader["QString"].ToString(), 
                                                          reader["ID"].ToString()));

					answersQuery += "SELECT * From Answers WHERE ID = " + reader["ID"] + ";";
                }

                else
                {
                    questions.Add(new NullQuestion());
                }
            }

            using (SqliteCommand cmd = new SqliteCommand(conn))
            {
                cmd.CommandText = answersQuery;
                reader = cmd.ExecuteReader();

                /* Do while loop makes sure to iterate through at least once, but still checks to
                 * make sure that valid data is read in. If a query returns nothing, then it is skipped, otherwise
                 * a new AnswerPool is added to the answers dictionary keyed to the ID of the question, then all the answers
                 * associated with that question are added to that AnswerPool
                 */ 
                do
                {
                    AnswerPool workPool = new AnswerPool();

                    if (!reader.Read())
                        continue;

					string id = reader["ID"].ToString();

                    answers.Add(id, workPool);

                    do
                    {
						string aString = reader["AString"].ToString();
						string correct = reader["Correct"].ToString();
                        workPool.AddAnswer(new Answer(aString, correct));

                    } while (reader.Read()); //end do while
                } while (reader.NextResult()); //end do while
            }

            for (int i = 0; i < questions.Count; i++)
            {
                AnswerPool temp;
                answers.TryGetValue(questions[i].ID, out temp);
                questions[i].Answers = temp;
            } //end loop i

            return new QuestionPool(questions);
        }

        public Question GetQuestionByID(int id)
        {
            using (SqliteConnection conn = new SqliteConnection(ConnectionString))
            {
                using (SqliteCommand cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "SELECT * FROM META NATURAL JOIN QUESTIONS WHERE ID = @id;";

                    cmd.Parameters.Add(new SqliteParameter("@id", id));
                    cmd.Prepare();

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        QuestionPool temp = CreateQuestions(reader, conn);

                        if (temp.Count == 1)
                            return temp.Questions[0];

                        else
                            return new NullQuestion();
                    }
                }
            }
        }
	}
}
