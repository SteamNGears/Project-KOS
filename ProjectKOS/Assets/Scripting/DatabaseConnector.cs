/**
 * Filename: DatabaseConnector.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 3
 * Rev. Date: 5/22/2015
 * Rev. Author: Aryk Anderson
 * */

using System.Collections;
using System.Collections.Generic;
using Mono.Data.Sqlite;
using System;

namespace Database {

	public class DatabaseConnector {

        private static string ConnectionString = "Data Source=Assets/Database/Questions.db;Version=3;";
        private static DatabaseConnector _instance = null;
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
        public DatabaseConnector() { }

        public QuestionPool GetQuestions(QuestionQuery query)
        {
            try
            {
                SqliteConnection conn = new SqliteConnection(ConnectionString);

                conn.Open();

                using (SqliteCommand cmd = new SqliteCommand(conn))
                {
                    cmd.CommandText = GenerateQueryString(query);
                    SqliteDataReader reader = cmd.ExecuteReader();
                    return CreateQuestions(reader, conn);
                }
            }

            catch (SqliteException e)
            {
                Console.WriteLine("Error occurred accessing database.");
            }

            catch (Exception e)
            {
                Console.WriteLine("NonSQL error occurred.");
            }
            
            
            return new QuestionPool(); //TODO
        }

        public string GenerateQueryString(QuestionQuery query)
        {
            string queryString = "SELECT * FROM Meta NATURAL JOIN Questions";
            string subject = "";
            string difficulty = "";
            string type = "";

            /* ALGORITHM
             * 
             * if query empty, select everything
             * 
             * if query not empty, then for each restraint check type
             *      different types will use and
             *      same types will use or
             *      there can only be one difficulty restraint
             *      
             * each restraint type has a string to concat on it results
             * 
             * allows for easy expansion into more restraints in the future
             * 
             * can change default behavior easily to randomize if we want --later though--
             */

            List<Restraint> restraints = query.Restraints;

            for (int i = 0; i < restraints.Count; i++)
            {
                if (restraints[i].RetraintType.Equals("DIFFICULTY"))
                {

                }

                else if (restraints[i].RetraintType.Equals("SUBJECT"))
                {

                }

                else if (restraints[i].RetraintType.Equals("TYPE"))
                {

                }

                else
                    continue;
            }

                return queryString + subject + difficulty + type;
        }

        private void Strip(string queryString)
        {
            queryString.Replace(";", "");
            queryString.Replace("`", "");
        }

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

                    answersQuery += "Select * from answers were ID = " + reader["ID"] + ";";
                }

                else if (type.Equals("MULTIPLE_CHOICE"))
                {
                    questions.Add(new MultiChoiceQuestion(reader["Subject"].ToString(), 
                                                          Int32.Parse(reader["Difficulty"].ToString()), 
                                                          reader["QString"].ToString(), 
                                                          reader["ID"].ToString()));

                    answersQuery += "Select * from answers were ID = " + reader["ID"] + ";";
                }

                else if (type.Equals("SHORT_ANSWER"))
                {
                    questions.Add(new ShortAnswerQuestion(reader["Subject"].ToString(), 
                                                          Int32.Parse(reader["Difficulty"].ToString()), 
                                                          reader["QString"].ToString(), 
                                                          reader["ID"].ToString()));

                    answersQuery += "Select * from answers were ID = " + reader["ID"] + ";";
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

                    answers.Add(reader["ID"].ToString(), workPool);

                    do
                    {
                        workPool.AddAnswer(new Answer(reader["AString"].ToString(), reader["Correct"].ToString()));

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
	}
}
