using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class accessTFCvs : MonoBehaviour {
	
	public Canvas _togglePanel;
	public Canvas _textPanel;

	private Button _chkAns;

	private Toggle _true;
	private Toggle _false;

	public bool toggleTF;
	public bool ansSelected;

	// Use this for initialization
	void Start () {
		this._textPanel = this.GetComponentsInParent<Canvas> () [0];
		this._togglePanel = this.GetComponentsInParent<Canvas> () [1];

		this._chkAns = this._togglePanel.GetComponentInChildren<Button> ();
		this._chkAns.onClick.AddListener (checkAnswer);
	}

	public void setQuestion(string quest)
	{
		if (this._textPanel != null)
		{
			this._textPanel.GetComponentInChildren<Text>().text = quest;
		}
	}

	void checkAnswer ()
	{
		this.ansSelected = true;
		this._chkAns.onClick.RemoveListener (checkAnswer);
	}

	// Update is called once per frame
	void Update () {

		if (this.ansSelected) 
		{
			this._true = this._togglePanel.GetComponentsInChildren<Toggle> () [0];
			this._false = this._togglePanel.GetComponentsInChildren<Toggle> () [1];
			if (this._true.isOn && !this._false.isOn) {
				this.toggleTF = true;
			} else if (this._false.isOn && !this._true.isOn) {
				this.toggleTF = false;
			}
			else {
				//Yell at the user for having both selected...
			}
		}
	}
}
