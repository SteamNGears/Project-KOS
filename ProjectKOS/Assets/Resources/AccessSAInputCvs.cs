/**
 * Filename: AccessSAInputCvs.cs
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
		
		private Canvas _SAInputCvs;//   short answer canvas for db entry
		
		private Button _submit;//   Button for user to submit question
		private Button _settings;//   Button for user to return to settings pane
		
		private InputField[] _saFields;//   input fields from short answer input pane
		
		public bool chkSet;//   bool indicating to go back to the settings pane
		public bool submitQuest;//   bool indicating question is ready to submit to db
		
		private string _question;
		private string _subject;
		private string _correctAns;
		private int _difficulty;
		
		
		private DatabaseConnector _dbConn;//   connector for db access
		
		private Question _sa;//   Question to be inserted
		
		// Use this for initialization
		void Start () {
			this._SAInputCvs = this.GetComponentInChildren<Canvas> ();
			
			this._saFields = this._SAInputCvs.GetComponentsInChildren<InputField> ();
			this._submit = this._SAInputCvs.GetComponentsInChildren<Button> () [0];
			this._submit.onClick.AddListener (submitQ);
			this._settings = this._SAInputCvs.GetComponentsInChildren<Button> () [1];
			this._settings.onClick.AddListener (settings);		
		}

		/**
		 * method to reset InputField.text for the entire panel
		 * */
		void resetInputFields ()
		{
			foreach (InputField iF in this._saFields)
			{
				iF.text = "";//   resets input field for next entry
			}
		}

		/**
		 * listener for user requesting to return to the settings panel
		 * */
		void settings ()
		{
			this._settings.onClick.RemoveListener (settings);
			this.chkSet = true;
		}

		/**
		 * listener to grab data from user input for adding question to db
		 * */
		void submitQ ()
		{
			this.submitQuest = true;
			this._question = this._saFields [0].text;
			this._subject = this._saFields [1].text.ToUpper;
			Int32.TryParse (this._saFields [2].text, out this._difficulty);
			this._correctAns = this._saFields [3].text;
		}

		/**
		 * method to build multiple choice answer pool for user question
		 * */
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
				this._dbConn = DatabaseConnector.Instance;//   connector for db access
				
				this._sa = new ShortAnswerQuestion(this._subject, this._difficulty, this._question, "1");
				this._sa.Answers = buildAnswers();//   build answer pool
				
				this._dbConn.InsertQuestion (this._sa);//   add new sa question to db
				resetInputFields();//   reset input fields to placeholders
				this._sa = null;
				this.submitQuest = false;
			}
		}
	}
	
}
