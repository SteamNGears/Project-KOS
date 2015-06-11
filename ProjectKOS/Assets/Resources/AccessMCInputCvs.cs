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
	public class AccessMCInputCvs : MonoBehaviour {
		
		private Canvas _MCInputCvs;//   multi choice canvas for db entry

		private Button _submit;//   Button for user to submit question
		private Button _settings;//   Button for user to return to settings pane

		private InputField[] _mcFields;//   input fields from mult choice input pane
		
		public bool chkSet;//   bool indicating to go back to the settings pane
		public bool submitQuest;//   bool indicating question is ready to submit to db

		private string _question;
		private string _subject;
		private string _correctAns;
		private string[] _answers;//   for populating answers to db
		private int _difficulty;

		
		private DatabaseConnector _dbConn;//   connector for db access

		private Question _mc;//   Question to be inserted
		
		// Use this for initialization
		void Start () {
			this._MCInputCvs = this.GetComponentInChildren<Canvas> ();

			this._mcFields = this._MCInputCvs.GetComponentsInChildren<InputField> ();
			this._submit = this._MCInputCvs.GetComponentsInChildren<Button> () [0];
			this._submit.onClick.AddListener (submitQ);//   listener to add question to db
			this._settings = this._MCInputCvs.GetComponentsInChildren<Button> () [1];
			this._settings.onClick.AddListener (settings);//   listener to return to settings pane	
			this._answers = new string[4];
		}

		/**
		 * method to reset InputField.text for the entire panel
		 * */
		void resetInputFields ()
		{
			foreach (InputField iF in this._mcFields)
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
			this._question = this._mcFields [0].text;
			this._subject = this._mcFields [1].text.ToUpper;
			Int32.TryParse (this._mcFields [2].text, out this._difficulty);
			this._correctAns = this._mcFields [3].text;

			this._answers [0] = this._mcFields [4].text;
			this._answers [1] = this._mcFields [5].text;
			this._answers [2] = this._mcFields [6].text;
			this._answers [3] = this._mcFields [7].text;
		}

		/**
		 * method to build multiple choice answer pool for user question
		 * */
		AnswerPool buildAnswers ()
		{
			AnswerPool tmpPool = new AnswerPool ();

			foreach (string s in this._answers) 
			{
				if(s.Equals (this._correctAns, StringComparison.OrdinalIgnoreCase))
				{
					tmpPool.AddAnswer (new Answer(s, true));//marks answer as correct
				}
				else
				{
					tmpPool.AddAnswer (new Answer(s, false));//marks answer as incorrect
				}
			}

			return tmpPool;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) 
			{
				this._MCInputCvs.enabled = false;
				this.chkSet = false;
				GameObject.Instantiate (Resources.Load ("DatabaseCvs") as GameObject);//return to Database Manager
			}
			else if (submitQuest)
			{
				this._dbConn = DatabaseConnector.Instance;//   instance of connector for accessing the db

				this._mc = new MultiChoiceQuestion(this._subject, this._difficulty, this._question, "1");
				this._mc.Answers = buildAnswers();//   build answer pool 

				this._dbConn.InsertQuestion (this._mc);//   add new mc question to db
				resetInputFields();//   resets input fields to placeholders
				this._mc = null;
				this.submitQuest = false;
			}
		}
	}
	
}
