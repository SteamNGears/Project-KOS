using UnityEngine;
using System.Collections;

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
}
