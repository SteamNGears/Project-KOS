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
		
		private Canvas _MCInputCvs;

		private Button _submit;
		private Button _settings;

		private InputField[] _mcFields;
		
		public bool chkSet;
		public bool submitQuest;

		private string _question;
		private string _subject;
		private string _correctAns;
		private string[] _answers;
		private int _difficulty;

		
		private DatabaseConnector _dbConn;

		private Question _mc;
		
		// Use this for initialization
		void Start () {
			this._MCInputCvs = this.GetComponentInChildren<Canvas> ();

			this._mcFields = this._MCInputCvs.GetComponentsInChildren<InputField> ();
			this._submit = this._MCInputCvs.GetComponentsInChildren<Button> () [0];
			this._submit.onClick.AddListener (submitQ);
			this._settings = this._MCInputCvs.GetComponentsInChildren<Button> () [1];
			this._settings.onClick.AddListener (settings);		
			this._answers = new string[4];
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

			this._answers [0] = this._mcFields [4].GetComponentsInChildren<Text> () [1].text;
			this._answers [1] = this._mcFields [5].GetComponentsInChildren<Text> () [1].text;
			this._answers [2] = this._mcFields [6].GetComponentsInChildren<Text> () [1].text;
			this._answers [3] = this._mcFields [7].GetComponentsInChildren<Text> () [1].text;
		}

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
				this._dbConn = DatabaseConnector.Instance;

				this._mc = new MultiChoiceQuestion(this._subject, this._difficulty, this._question, "1");
				this._mc.Answers = buildAnswers();

				this._dbConn.InsertQuestion (this._mc);
				resetInputFields();
				this._mc = null;
				this.submitQuest = false;
			}
		}
	}
	
}
