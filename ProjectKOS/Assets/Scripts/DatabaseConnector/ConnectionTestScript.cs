/**
 * Filename: AnswerPool.cs
 * Author: Aryk Anderson
 * Created: 5/21/2015
 * Revision: 0
 * Rev. Date: 5/21/2015
 * Rev. Author: Aryk Anderson
 * */

using UnityEngine;
using System.Collections;
using Database;

public class ConnectionTestScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
		QuestionQuery query = new QuestionQuery ();
		query.AddRestraint(new DifficultyRestraint(1, 3));
		query.AddRestraint (new SubjectRestraint ("MATH"));
		query.AddRestraint (new TypeRestraint ("MULTIPLE_CHOICE"));
		query.AddRestraint (new TypeRestraint ("SHORT_ANSWER"));

		string queryString = DatabaseConnector.Instance.GenerateQueryString(query);
		Debug.Log (queryString);

//        QuestionPool questions = DatabaseConnector.Instance.GetQuestions(null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
