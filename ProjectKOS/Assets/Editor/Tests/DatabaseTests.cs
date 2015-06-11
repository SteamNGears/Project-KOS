/**
 * Filename: DatabaseTests.cs
 * Author: Jakob Wilson
 * Created: 5/11/2015
 * Revision:
 * Rev. Date: 
 * Rev. Author: 
 * */


using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using Database;

namespace KOSTests
{
	/**
	 * Tests 
	 * */
	[TestFixture]
	[Category("Project KOS Tests")]
	internal class DatabaseTests
	{
		[Datapoint]
		DatabaseConnector c = DatabaseConnector.Instance;

		[TestFixtureSetUp]
		public void Init()
		{
			c = DatabaseConnector.Instance;
		}
		
		[TestFixtureTearDown]
		public void Dispose()
		{
			c = null;
		}

		/**
		 * Ensure that the connection object was created
		 * */
		[Test]
		public void CreateConnectionObject()
		{



			if (c != null)
				Assert.Pass ();
			else
				Assert.Fail ("Could not access Connection object");
		}

		/**
		 * Check that we can retreve something from the database
		 * */
		[Test]
		public void RetreveFromDatabase()
		{
			
			QuestionQuery q = new QuestionQuery ();
			QuestionPool p = c.GetQuestions (q);

			if(p.Count > 0)
				Assert.Pass ();
			else
				Assert.Fail ("No questions were retrevied from the database");
		}


		/**----------------------Test difficulty restraints--------------------------------**/
		[Test]
		public void DifficultyRestraints()
		{
			/**Check max difficulty case*/
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new DifficultyRestraint (3));
			QuestionPool p = c.GetQuestions (q);

			foreach (Question x in p) {
				if(x.Difficulty > 3)
					Assert.Fail("Single difficulty failed");

			}
		
			/*Difficulty range case*/
			q = new QuestionQuery ();
			q.AddRestraint (new DifficultyRestraint (2,3));
			p = c.GetQuestions (q);
			
			foreach (Question x in p) {
				if(x.Difficulty > 3 || x.Difficulty < 2)
					Assert.Fail("Range difficulty failed");
				
			}

			/**Impossible Case*/
			q = new QuestionQuery ();
			q.AddRestraint (new DifficultyRestraint (4,5));
			q.AddRestraint (new DifficultyRestraint (1,2));
			p = c.GetQuestions (q);

			if (p.Count > 0)
				Assert.Fail ("Should not be returnign questions");

			Assert.Pass ();
		}

		/**----------------------Test type restraints--------------------------------**/
		/**
		 * Tests Multiple choice type restraint
		 * */

		[Test]
		public void MCTypeRestraints()
		{
			/**Test Multiple Choice*/
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint ("MULTIPLE_CHOICE"));
			QuestionPool p = c.GetQuestions (q);

			if (p.Count < 1)
				Assert.Fail ("No qestions returned by Multiple Choice restraint");
			
			foreach (Question x in p) {
				if (x.Type != "MULTIPLE_CHOICE")
					Assert.Fail ("Multiple choice restraint failed. Type is " + x.Type);
			}
			Assert.Pass ();
		}

		/**
		 * Tests True false type restraint
		 * */
		[Test]
		public void TFTypeRestraints()
		{
			/**Test True False*/
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint ("TRUE_FALSE"));
			QuestionPool p = c.GetQuestions (q);

			if (p.Count < 1)
				Assert.Fail ("No qestions returned by True False restraint");

			foreach (Question x in p) {
				if (x.Type != "TRUE_FALSE")
					Assert.Fail ("True False reastrint failed. Type is " + x.Type);
			}
			Assert.Pass ();

		}

		/**
		 * Tests short answer type restraint
		 * */
		[Test]
		public void SATypeRestraints()
		{
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint("SHORT_ANSWER"));
			QuestionPool p = c.GetQuestions (q);

			if (p.Count < 1)
				Assert.Fail ("No qestions returned by Short Answer restraint");

			foreach (Question x in p) {
				if(x.Type != "SHORT_ANSWER")
					Assert.Fail("Short answer reastrint failed. Type is " + x.Type);
			}
				
			Assert.Pass ();
		}



		/*-----------------------Test Subject Restraints--------------------*/

		/**
		 * Tests for "MATH" subject restraint
		 * */
		[Test]
		public void SubjectRestraints()
		{
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new SubjectRestraint("MATH"));
			QuestionPool p = c.GetQuestions (q);

			if (p.Count < 1)
				Assert.Fail ("No qestions returned by the subject restraint");
			
			foreach (Question x in p) {
				if(x.Subject != "MATH")
					Assert.Fail("Subject reastrint failed. Subject is " + x.Subject);
			}
			
			Assert.Pass ();
		}


		/**-------------Test that answers match--------------*/

		/**
		 * Multiple choice
		 * Test that there are 4 answers and one is right
		 * */
		[Test]
		public void MCAnswerMatches()
		{
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint("MULTIPLE_CHOICE"));
			QuestionPool p = c.GetQuestions (q);

			bool oneAnswerMatches = false;
			
			foreach (Question x in p) {
				if(x.Answers.Size != 4)
					Assert.Fail("Not enough answers for multiple choice");

				foreach(Answer a in x.Answers)
					if(a.Correct)
						oneAnswerMatches = true;

				if(!oneAnswerMatches)
					Assert.Fail("No correct answers");


			}
			Assert.Pass ();
		}


		/**
		 * True False
		 * Test that there are 2 answers(true of false) and one is right
		 * */
		[Test]
		public void TFAnswerMatches()
		{
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint("TRUE_FALSE"));
			QuestionPool p = c.GetQuestions (q);
			
			bool oneAnswerMatches = false;
			
			foreach (Question x in p) {
				if(x.Answers.Size != 2)
					Assert.Fail("Not enough answers for true false");
				
				foreach(Answer a in x.Answers)
					if(a.Correct)
						oneAnswerMatches = true;
				
				if(!oneAnswerMatches)
					Assert.Fail("No correct answers");
				
			}
			Assert.Pass ();
		}

		/**
		 * Multiple choice
		 * Test that there is 1 answer and it is right
		 * */
		[Test]
		public void SAAnswerMatches()
		{
			QuestionQuery q = new QuestionQuery ();
			q.AddRestraint (new TypeRestraint("SHORT_ANSWER"));
			QuestionPool p = c.GetQuestions (q);
			
			bool oneAnswerMatches = false;
			
			foreach (Question x in p) {
				if(x.Answers.Size != 1)
					Assert.Fail("Not enough answers for short answer");
				
				foreach(Answer a in x.Answers)
					if(a.Correct)
						oneAnswerMatches = true;
				
				if(!oneAnswerMatches)
					Assert.Fail("No correct answer");
				
			}
			Assert.Pass ();
		}

		
	}
}

