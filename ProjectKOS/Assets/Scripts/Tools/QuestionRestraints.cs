using UnityEngine;
using System.Collections;
using Database;

public class QuestionRestraints : MonoBehaviour 
{
	public const int INFINITY = 2147483647;

	public int Min_Difficulty = 0;
	public int Max_Difficulty = INFINITY;

	public string[] subjects;

	public enum type{ALL, MULTIPLE_CHOICE, TRUE_FALSE, SHORT_ANSWER};
	public type Question_Type = type.ALL;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * A queryobject property thet creates a query objecy from the constraint
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
