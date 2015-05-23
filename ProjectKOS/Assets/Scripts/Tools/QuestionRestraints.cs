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
			QuestionQuery query = new QuestionQuery ();
			query.addRestraint(new DifficultyRestraint(Min_Difficulty, Max_Difficulty));

			if(Question_Type == type.MULTIPLE_CHOICE)
					query.addRestraint (new TypeRestraint ("MULTIPLE_CHOICE"));
			if(Question_Type == type.SHORT_ANSWER)
					query.addRestraint (new TypeRestraint ("SHORT_ANSWER"));
			if(Question_Type == type.TRUE_FALSE)
					query.addRestraint (new TypeRestraint ("TRUE_FALSE"));

			foreach(string s in subjects)
			{
				query.addRestraint (new SubjectRestraint (s));
			}
			return query;
		}
	}
}
