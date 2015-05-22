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
        QuestionPool questions = DatabaseConnector.Instance.GetQuestions(null);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
