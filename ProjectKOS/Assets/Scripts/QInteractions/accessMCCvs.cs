using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class accessMCCvs : MonoBehaviour {
	
	public Canvas mCvs;
	public Canvas textPanel;
	public Canvas buttonsPanel;
	
	private Button _btnOne;
	private Button _btnTwo;
	private Button _btnThree;
	private Button _btnFour;
	public Button btnSelected;
	
	
	private Text _question;
	private string _value;
	
	private bool _oneClicked;
	private bool _twoClicked;
	private bool _threeClicked;
	private bool _fourClicked;
	public bool btnClicked;
	public bool destroyCvs = false;
	
	
	
	// Use this for initialization
	void Start () {
		this.buttonsPanel = this.GetComponentsInParent<Canvas> () [0];
		this.buttonsPanel.transform.SetParent (this.transform);
		this.textPanel = this.GetComponentsInParent<Canvas> () [1];
		this.textPanel.transform.SetParent (this.transform);
	}
		
	void oneClicked ()
	{
		this.btnClicked = true;
		this.btnSelected = this._btnOne;
	}
	
	void twoClicked ()
	{
		this.btnClicked = true;
		this.btnSelected = this._btnTwo;
	}
	
	void threeClicked ()
	{
		this.btnClicked = true;
		this.btnSelected = this._btnThree;
	}
	
	void fourClicked ()
	{
		this.btnClicked = true;
		this.btnSelected = this._btnFour;
	}

	public void cleanListeners()
	{
		this._btnOne.onClick.RemoveListener (oneClicked);
		this._btnTwo.onClick.RemoveListener (twoClicked);
		this._btnThree.onClick.RemoveListener (threeClicked);
		this._btnFour.onClick.RemoveListener (fourClicked);
	}

	public void setQuestion(string quest)
	{
		if (this.textPanel != null) 
		{
			this.textPanel.GetComponentInChildren<Text> ().text = quest;
		}
	}
	
	public void setAnswers(string[] ans)
	{
		if (this.buttonsPanel != null) {
			this._btnOne = this.buttonsPanel.GetComponentsInChildren<Button> () [0];
			this._btnOne.onClick.AddListener (oneClicked);
			
			this._btnTwo = this.buttonsPanel.GetComponentsInChildren<Button> () [1];
			this._btnTwo.onClick.AddListener (twoClicked);
			
			this._btnThree = this.buttonsPanel.GetComponentsInChildren<Button> () [2];
			this._btnThree.onClick.AddListener (threeClicked);
			
			this._btnFour = this.buttonsPanel.GetComponentsInChildren<Button> () [3];
			this._btnFour.onClick.AddListener (fourClicked);
			if(this._btnOne != null)
			{
				this._btnOne.GetComponentInChildren<Text>().text = ans[0];
			}
			if(this._btnTwo != null)
			{
				this._btnTwo.GetComponentInChildren<Text>().text = ans[1];
			}
			if(this._btnThree != null)
			{
				this._btnThree.GetComponentInChildren<Text>().text = ans[2];
			}
			if(this._btnFour != null)
			{
				this._btnFour.GetComponentInChildren<Text>().text = ans[3];
			}
		}
	}
	
	public string text
	{
		get{
			return _value;
		}
		set{
			this._value = value;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
