using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class accessTFCvs : MonoBehaviour {
	
	public Canvas togglePanel;//panel with answer selections
	public Canvas textPanel;//panel with question

	private Button _chkAns;//button that user selects to check answer

	private Toggle _true;//true toggle on togglePanel
	private Toggle _false;//false toggle on togglePanel

	public bool toggleTF;//set to true or false dependent on user input
	public bool ansSelected;//tells system user has selected answer

	// Use this for initialization
	void Start () {
		this.textPanel = this.GetComponentsInParent<Canvas> () [0];//child canvas[0] from TFCvs.prefab
		this.togglePanel = this.GetComponentsInParent<Canvas> () [1];//child canvas[1] from TFCvs.prefab

		this._chkAns = this.togglePanel.GetComponentInChildren<Button> ();//button from child canvas[1] of TFCvs.prefab
		this._chkAns.onClick.AddListener (checkAnswer);//function to add event listener to _chkAns
	}

	public void setQuestion(string quest)//sets question from Question.getQuestion[n]
	{
		if (this.textPanel != null)
		{
			this.textPanel.GetComponentInChildren<Text>().text = quest;//set question text in textPanel
		}
	}

	void checkAnswer ()
	{
		this.ansSelected = true;//user has selected an answer
		this._chkAns.onClick.RemoveListener (checkAnswer);//removes listener from _chkAns 
	}

	// Update is called once per frame
	void Update () {

		if (this.ansSelected) //blocks against random answer checking
		{
			this._true = this.togglePanel.GetComponentsInChildren<Toggle> () [0];//toggle[0] in togglePanel
			this._false = this.togglePanel.GetComponentsInChildren<Toggle> () [1];//toggle[1] in togglePanel
			if (this._true.isOn && !this._false.isOn) {//if true is selected and not false
				this.toggleTF = true;
			} else if (this._false.isOn && !this._true.isOn) {//if false is selected and not true
				this.toggleTF = false;
			}
			else {
				//Yell at the user for having both selected...
			}
		}
	}
}
