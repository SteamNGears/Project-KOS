/**
 * Filename: accessMCCvs.cs
 * Author: Chris Hatch
 * Created: 5/15/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Chris Hatch
 * */
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Database;
public class accessMCCvs : MonoBehaviour {

	public Canvas textPanel;//panel with question
	public Canvas buttonsPanel;//panel with answer selections
	
	private Button _btnOne;//answer a
	private Button _btnTwo;//answer b
	private Button _btnThree;//answer c
	private Button _btnFour;//answer d
	public Button btnSelected;//returns user answer

	/* bools to assign true or false dependent on user input*/
	private bool _oneClicked;
	private bool _twoClicked;
	private bool _threeClicked;
	private bool _fourClicked;

	public bool btnClicked;//tells system user has selected an answer
	
	
	
	// Use this for initialization
	void Start () {
		this.buttonsPanel = this.GetComponentsInParent<Canvas> () [0];
		this.textPanel = this.GetComponentsInParent<Canvas> () [1];
	}
		
	void oneClicked ()//listener for answer a
	{
		this.btnClicked = true;
		this.btnSelected = this._btnOne;
	}
	
	void twoClicked ()//listener for answer b
	{
		this.btnClicked = true;
		this.btnSelected = this._btnTwo;
	}
	
	void threeClicked ()//listener for answer c
	{
		this.btnClicked = true;
		this.btnSelected = this._btnThree;
	}
	
	void fourClicked ()//listener for answer d
	{
		this.btnClicked = true;
		this.btnSelected = this._btnFour;
	}

	public void cleanListeners()//removes all listeners
	{
		this._btnOne.onClick.RemoveListener (oneClicked);
		this._btnTwo.onClick.RemoveListener (twoClicked);
		this._btnThree.onClick.RemoveListener (threeClicked);
		this._btnFour.onClick.RemoveListener (fourClicked);
	}

	public void setQuestion(string quest)//sets question from Question.getQuestion[n]
	{
		//ensures system is not trying to assign to null canvas component
		if (this.textPanel != null) 
		{
			if(this.textPanel.GetComponentInChildren<Text> () != null)
				this.textPanel.GetComponentInChildren<Text> ().text = quest;
		}
	}
	
	public void setAnswers(AnswerPool ans)
	{
		if (this.buttonsPanel != null) {
			//gets buttons 0-3 from answer panel, adds listeners for click events to each
			this._btnOne = this.buttonsPanel.GetComponentsInChildren<Button> () [0];
			this._btnOne.onClick.AddListener (oneClicked);
			
			this._btnTwo = this.buttonsPanel.GetComponentsInChildren<Button> () [1];
			this._btnTwo.onClick.AddListener (twoClicked);
			
			this._btnThree = this.buttonsPanel.GetComponentsInChildren<Button> () [2];
			this._btnThree.onClick.AddListener (threeClicked);
			
			this._btnFour = this.buttonsPanel.GetComponentsInChildren<Button> () [3];
			this._btnFour.onClick.AddListener (fourClicked);

			if(ans.Size == 4)
			{
				//ensures system is not trying to assign to null canvas component
				if(this._btnOne != null)
				{
					this._btnOne.GetComponentInChildren<Text>().text = ans[0].AnswerString;
				}
				//ensures system is not trying to assign to null canvas component
				if(this._btnTwo != null)
				{
					this._btnTwo.GetComponentInChildren<Text>().text = ans[1].AnswerString;
				}
				//ensures system is not trying to assign to null canvas component
				if(this._btnThree != null)
				{
					this._btnThree.GetComponentInChildren<Text>().text = ans[2].AnswerString;
				}
				//ensures system is not trying to assign to null canvas component
				if(this._btnFour != null)
				{
					this._btnFour.GetComponentInChildren<Text>().text = ans[3].AnswerString;
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
