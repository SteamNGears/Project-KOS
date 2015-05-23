/**
 * Filename: DatabaseConnector.cs
 * Author: Aryk Anderson
 * Created: 5/4/2015
 * Revision: 4
 * Rev. Date: 5/22/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
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

        private System.Object IDLock = new System.Object();
        
        private int _maxID;
        
        public int MaxID
        {
            get 
            {
                lock(IDLock)
                {
                    return _maxID;
                }
            }

            private set
            {
                _maxID = value;
            }
        }
        
        public DatabaseConnector() 
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(ConnectionString))
                {
                    using (SqliteCommand cmd = new SqliteCommand())
                    {
                        cmd.CommandText = "Select MAX(ID) From Meta;";
                        using (SqliteDataReader reader = cmd.ExecuteReader())
                        {
                            reader.Read();
                            MaxID = Int32.Parse(reader["ID"].ToString());
                        }
                    }
                }
            }

            catch (SqliteException e)
            {
                Debug.Log(e.Message);
            }
        }

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

        public bool InsertQuestion(Question question)
        {
            try
            {
                using (SqliteConnection conn = new SqliteConnection(ConnectionString))
                {
                    using (SqliteCommand cmd = new SqliteCommand())
                    {
                        int id = MaxID++;

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

        private void InsertIntoMeta(SqliteCommand cmd, Question question, int id)
        {
            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Meta VALUES (?,?,?,?);";

            int Difficulty = question.Difficulty;
            string Subject = question.Subject;
            string Type = question.Type;

            cmd.Parameters.Add(id);
            cmd.Parameters.Add(Difficulty);
            cmd.Parameters.Add(Subject);
            cmd.Parameters.Add(Type);

            cmd.Prepare();
            Debug.Log(cmd.CommandText);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
        }

        private void InsertIntoAnswers(SqliteCommand cmd, Question question, int id)
        {
            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Answers VALUES (?,?,?);";
            AnswerPool answers = question.Answers;

            foreach(Answer temp in answers)
            {
                string aString = temp.AnswerString;
                bool correct = temp.Correct;

                cmd.Parameters.Add(id);
                cmd.Parameters.Add(aString);
                cmd.Parameters.Add(correct);
                
                cmd.Prepare();
                Debug.Log(cmd.CommandText);

                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }   
        }

        private void InsertIntoQuestions(SqliteCommand cmd, Question question, int id)
        {
            if (question == null)
                return;

            cmd.CommandText = "INSERT INTO Questions VALUES (?,?);";

            string qString = question.QuestionString;

            cmd.Parameters.Add(id);
            cmd.Parameters.Add(qString);

            cmd.Prepare();
            Debug.Log(cmd.CommandText);

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
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

                    answersQuery += "SELECT * From Answers WHERE ID = " + reader["ID"] + ";";
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
	}
}
