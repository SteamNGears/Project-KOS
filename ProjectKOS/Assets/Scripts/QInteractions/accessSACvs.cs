using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class accessSACvs : MonoBehaviour {

	public Canvas textPanel;//panel with question
	public Canvas answerPanel;//panel with answer input field

	private InputField _input;
	private Button _chkAns;//button that user selects to check answer

	public bool ansTyped;//tells system user has typed an answer

	public string userAnswer;//answer to test against Answer

	// Use this for initialization
	void Start () {
		this.answerPanel = this.GetComponentsInParent<Canvas> () [0];//child canvas[0] from SACvs.prefab
		this.textPanel = this.GetComponentsInParent<Canvas> () [1];//child canvas[1] from SACvs.prefab

		this._input = this.answerPanel.GetComponentsInChildren<InputField> () [0];//inputField from child canvas[0] from SACvs.prefab
		this._chkAns = this.answerPanel.GetComponentsInChildren<Button> () [0];//check answer button from child canvas[0] from SACvs.prefab
		this._chkAns.onClick.AddListener (checkAnswer);//listener to tell system click event has occurred
	}

	void checkAnswer ()
	{
		this.ansTyped = true;
		//ensures system is not trying to assign from null canvas component
		if (this.answerPanel != null) 
		{
			if(this._input.GetComponentsInChildren<Text> () [1] != null)
				this.userAnswer = this._input.GetComponentsInChildren<Text> () [1].text;
		}
		this._chkAns.onClick.RemoveListener (checkAnswer);
	}

	public void setQuestion(string quest)//sets question from Question.getQuestion[n]
	{
		//ensures system is not trying to assign to null canvas component
		if (this.textPanel != null) 
		{
			if(this.textPanel.GetComponentsInChildren<Text> () != null)
				this.textPanel.GetComponentInChildren<Text> ().text = quest;//set question text in textPanel
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
