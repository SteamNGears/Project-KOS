/**
 * Filename: QuestionRestraint.cs
 * Author: Jakob Wilson
 * Created: 5/20/2015
 * Revision: 
 * Rev. Date: 
 * Rev. Author: 
 * */

using UnityEngine;
using System.Collections;
using Database;


/**
 * This class is to be attached to a door to specify question restraints on that door
 * The question select state uses this script to create restrainst for it's query
 * */
public class QuestionRestraints : MonoBehaviour 
{
	public const int INFINITY = 2147483647;	/**Int Infinity*/

	public int Min_Difficulty = 0;			/**The minimum question difficulty*/
	public int Max_Difficulty = INFINITY;	/**The maximum question difficulty*/

	public string[] subjects;				/**All the allowable subjects*/
		
	public enum type{ALL, MULTIPLE_CHOICE, TRUE_FALSE, SHORT_ANSWER};	/**An enum for the question types*/
	public type Question_Type = type.ALL;				/**The question types we want for this door*/

	/**
	 * does nothing
	 * */
	void Start () {
	
	}
	
	/**
	 * Does nothing
	 * */
	void Update () {
	
	}

	/**
	 * A queryobject property that creates a query objecy from the constraint
	 * @return - QuestionQuery - a query that with the appropriate restraints specified by the scripts data
	 * */
	public QuestionQuery QueryObject
	{
		get
		{
			QuestionQuery query = new QuestionQuery ();										//create a query
			query.AddRestraint(new DifficultyRestraint(Min_Difficulty, Max_Difficulty));	//add the difficulty restraint

			if(Question_Type == type.MULTIPLE_CHOICE)										//add the correct restrainr based o the Question_Type
					query.AddRestraint (new TypeRestraint ("MULTIPLE_CHOICE"));				// selected by the user
			if(Question_Type == type.SHORT_ANSWER)
					query.AddRestraint (new TypeRestraint ("SHORT_ANSWER"));
			if(Question_Type == type.TRUE_FALSE)
					query.AddRestraint (new TypeRestraint ("TRUE_FALSE"));

			foreach(string s in subjects)													//add any subject restraints that the user wanted
			{
				query.AddRestraint (new SubjectRestraint (s));
			}
			return query;
		}
	}
}
