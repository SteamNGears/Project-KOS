using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class accessSACvs : MonoBehaviour {

	public Canvas textPanel;
	public Canvas answerPanel;

	private InputField _input;
	private Button _chkAns;

	public bool ansTyped;

	public string userAnswer;

	// Use this for initialization
	void Start () {
		this.answerPanel = this.GetComponentsInParent<Canvas> () [0];
		this.textPanel = this.GetComponentsInParent<Canvas> () [1];

		this._input = this.answerPanel.GetComponentsInChildren<InputField> () [0];
		this._chkAns = this.answerPanel.GetComponentsInChildren<Button> () [0];
		this._chkAns.onClick.AddListener (checkAnswer);
	}

	void checkAnswer ()
	{
		this.ansTyped = true;
		this.userAnswer = this._input.GetComponentsInChildren<Text> () [1].text;
		this._chkAns.onClick.RemoveListener (checkAnswer);
	}

	public void setQuestion(string quest)
	{
		if (this.textPanel != null) 
		{
			this.textPanel.GetComponentInChildren<Text> ().text = quest;
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
