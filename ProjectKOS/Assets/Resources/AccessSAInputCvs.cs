/**
 * Filename: AccessMCInputCvs.cs
 * Author: Chris Hatch
 * Created: 6/05/2015
 * Revision: 0
 * Rev. Date: 6/05/2015
 * Rev. Author: Chris Hatch
 * */
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Database;
namespace AssemblyCSharp
{
	public class AccessSAInputCvs : MonoBehaviour {
		
		private Canvas _SAInputCvs;
		
		private Button _submit;
		private Button _settings;
		
		private InputField[] _mcFields;
		
		public bool chkSet;
		public bool submitQuest;
		
		private string _question;
		private string _subject;
		private string _correctAns;
		private int _difficulty;
		
		
		private DatabaseConnector _dbConn;
		
		private Question _sa;
		
		// Use this for initialization
		void Start () {
			this._SAInputCvs = this.GetComponentInChildren<Canvas> ();
			
			this._mcFields = this._SAInputCvs.GetComponentsInChildren<InputField> ();
			this._submit = this._SAInputCvs.GetComponentsInChildren<Button> () [0];
			this._submit.onClick.AddListener (submitQ);
			this._settings = this._SAInputCvs.GetComponentsInChildren<Button> () [1];
			this._settings.onClick.AddListener (settings);		
		}
		
		void resetInputFields ()
		{
			this._mcFields [0].GetComponentsInChildren<Text> () [1].text = "";
			this._mcFields [1].GetComponentsInChildren<Text> () [1].text = "";
			this._mcFields [2].GetComponentsInChildren<Text> () [1].text = "";
			this._mcFields [3].GetComponentsInChildren<Text> () [1].text = "";
		}
		
		void settings ()
		{
			this._settings.onClick.RemoveListener (settings);
			this.chkSet = true;
		}
		
		void submitQ ()
		{
			this.submitQuest = true;
			this._question = this._mcFields [0].GetComponentsInChildren<Text> () [1].text;
			this._subject = this._mcFields [1].GetComponentsInChildren<Text> () [1].text;
			Int32.TryParse (this._mcFields [2].GetComponentsInChildren<Text> () [1].text, out this._difficulty);
			this._correctAns = this._mcFields [3].GetComponentsInChildren<Text> () [1].text;
		}
		
		AnswerPool buildAnswers ()
		{
			AnswerPool tmpPool = new AnswerPool ();
			
			tmpPool.AddAnswer (new Answer (this._correctAns, true));
			
			return tmpPool;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) 
			{
				this._SAInputCvs.enabled = false;
				this.chkSet = false;
				GameObject.Instantiate (Resources.Load ("DatabaseCvs") as GameObject);//return to Database Manager
			}
			else if (submitQuest)
			{
				this._dbConn = DatabaseConnector.Instance;
				
				this._sa = new ShortAnswerQuestion(this._subject, this._difficulty, this._question, "1");
				this._sa.Answers = buildAnswers();
				
				this._dbConn.InsertQuestion (this._sa);
				resetInputFields();
				this._sa = null;
				this.submitQuest = false;
			}
		}
	}
	
}
