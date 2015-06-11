/**
 * Filename: AccessTFInputCvs.cs
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
	public class AccessTFInputCvs : MonoBehaviour {
		
		private Canvas _TFInputCvs;//   true false canvas for db entry
		
		private Button _submit;//   Button for user to submit question
		private Button _settings;//   Button for user to return to settings pane
		
		private InputField[] _tfFields;//   input fields from true false input pane
		
		public bool chkSet;//   bool indicating to go back to the settings pane
		public bool submitQuest;//   bool indicating question is ready to submit to db
		
		private string _question;
		private string _subject;
		private string _correctAns;
		private int _difficulty;
		
		
		private DatabaseConnector _dbConn;//   connector for db access
		
		private Question _tf;//   Question to be inserted
		
		// Use this for initialization
		void Start () {
			this._TFInputCvs = this.GetComponentInChildren<Canvas> ();
			
			this._tfFields = this._TFInputCvs.GetComponentsInChildren<InputField> ();
			this._submit = this._TFInputCvs.GetComponentsInChildren<Button> () [0];
			this._submit.onClick.AddListener (submitQ);//   listener to add question to db
			this._settings = this._TFInputCvs.GetComponentsInChildren<Button> () [1];
			this._settings.onClick.AddListener (settings);//   listener to return to settings panel	
		}

		/**
		 * method to reset InputField.text for the entire panel
		 * */
		void resetInputFields ()
		{
			foreach (InputField iF in this._tfFields)
			{
				iF.text = "";//   resets input field for next entry
			}
		}

		/**
		 * listener for user requesting to return to the settings panel
		 * */
		void settings ()
		{
			this._settings.onClick.RemoveListener (settings);//   clean up listener
			this.chkSet = true;
		}

		/**
		 * listener to grab data from user input for adding question to db
		 * */
		void submitQ ()
		{
			this.submitQuest = true;
			this._question = this._tfFields [0].text;
			this._subject = this._tfFields [1].text.ToUpper;
			Int32.TryParse (this._tfFields [2].text, out this._difficulty);
			this._correctAns = this._tfFields [3].text;
		}

		/**
		 * method to build multiple choice answer pool for user question
		 * */
		AnswerPool buildAnswers ()
		{
			AnswerPool tmpPool = new AnswerPool ();

			if(this._correctAns.Equals ("TRUE", StringComparison.OrdinalIgnoreCase))
			{
				tmpPool.AddAnswer (new Answer ("TRUE", true));
				tmpPool.AddAnswer (new Answer ("FALSE", false));
			}
			else
			{
				tmpPool.AddAnswer (new Answer ("TRUE", false));
				tmpPool.AddAnswer (new Answer ("FALSE", true));
			}

			
			return tmpPool;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) 
			{
				this._TFInputCvs.enabled = false;
				this.chkSet = false;
				GameObject.Instantiate (Resources.Load ("DatabaseCvs") as GameObject);//return to Database Manager
			}
			else if (submitQuest)
			{
				this._dbConn = DatabaseConnector.Instance;//   connector for db access
				
				this._tf = new TrueFalseQuestion(this._subject, this._difficulty, this._question, "1");
				this._tf.Answers = buildAnswers();//   build answer pool 
				
				this._dbConn.InsertQuestion (this._tf);//   add new tf question to db
				resetInputFields();//   reset input fields to placeholders
				this._tf = null;
				this.submitQuest = false;
			}
		}
	}
	
}
