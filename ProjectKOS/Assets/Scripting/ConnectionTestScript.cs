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
