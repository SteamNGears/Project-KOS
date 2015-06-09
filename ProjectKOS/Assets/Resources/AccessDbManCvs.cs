/**
 * Filename: AccessDbManCvs.cs
 * Author: Chris Hatch
 * Created: 5/28/2015
 * Revision: 0
 * Rev. Date: 5/28/2015
 * Rev. Author: Chris Hatch
 * */

using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using Database;
namespace AssemblyCSharp
{
	public class AccessDbManCvs : MonoBehaviour {
		
		private Canvas _DbManCvs;

		private InputField _questionString;
		private InputField _answerString;
		private InputField _correctAnswer;
		private InputField _difficulty;
		private InputField _subject;

		private int _diff;

		private string _question;
		private string _answers;
		private string _correct;
		private string _subjectStr;

		private Button _addToDB;
		private Button _mainMenu;
		private Button _typeMC;
		private Button _typeSA;
		private Button _typeTF;
		private Button _howTo;

		private bool _chkState;
		private bool _submit;

		public enum nextDbManState {DATABASE, HOW_TO, MAIN_MENU};
		public enum questType {MC, SA, TF, NULL};
		public questType qt;
		public nextDbManState nxtState;

		private DatabaseConnector _dbConn;
		private Question _toInsert;
		private AnswerPool _newAnswers;

		// Use this for initialization
		void Start () {
			this._DbManCvs = this.GetComponentInChildren<Canvas> ();

			this._questionString = this._DbManCvs.GetComponentsInChildren<InputField> () [0];
			this._answerString = this._DbManCvs.GetComponentsInChildren<InputField> () [1];
			this._correctAnswer = this._DbManCvs.GetComponentsInChildren<InputField> () [2];
			this._difficulty = this._DbManCvs.GetComponentsInChildren<InputField> () [3];
			this._subject = this._DbManCvs.GetComponentsInChildren<InputField> () [4];

			this._addToDB = this._DbManCvs.GetComponentsInChildren<Button> () [0];
			this._addToDB.onClick.AddListener (databaseAdd);
			this._mainMenu = this._DbManCvs.GetComponentsInChildren<Button> () [1];
			this._mainMenu.onClick.AddListener (mainMenu);
			this._typeMC = this._DbManCvs.GetComponentsInChildren<Button> () [2];
			this._typeMC.onClick.AddListener (typeMc);
			this._typeSA = this._DbManCvs.GetComponentsInChildren<Button> () [3];
			this._typeSA.onClick.AddListener (typeSa);
			this._typeTF = this._DbManCvs.GetComponentsInChildren<Button> () [4];
			this._typeTF.onClick.AddListener (typeTf);
			this._howTo = this._DbManCvs.GetComponentsInChildren<Button> () [5];
			this._howTo.onClick.AddListener (howTo);

		}

		void databaseAdd ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this._chkState = true;
			this._submit = true;
		}

		void howTo ()
		{
			this.nxtState = nextDbManState.HOW_TO;
			this._chkState = true;
		}

		void mainMenu ()
		{
			this.nxtState = nextDbManState.MAIN_MENU;
			this._chkState = true;
		}

		void typeMc ()
		{
			this.qt = questType.MC;
		}

		void typeSa ()
		{
			this.qt = questType.SA;
		}

		void typeTf ()
		{
			this.qt = questType.TF;
		}

		void removeListeners()
		{
			this._addToDB.onClick.RemoveListener (databaseAdd);
			this._mainMenu.onClick.RemoveListener (mainMenu);
			this._howTo.onClick.RemoveListener (howTo);
		}

		AnswerPool buildAnswerPool (string answers, string correctAns)
		{
			AnswerPool tmpPool = new AnswerPool ();

			if (answers != null && correctAns != null) {
				string[] tmpArr = answers.Split (';');

				if (tmpArr.Length > 1) {
					if (this._toInsert.Type.Equals ("MULTIPLE_CHOICE", StringComparison.OrdinalIgnoreCase)) {
						foreach (string s in tmpArr) {
							if (s.Equals (correctAns, StringComparison.OrdinalIgnoreCase)) {
								tmpPool.AddAnswer (new Answer (s, true));
							} else {
								tmpPool.AddAnswer (new Answer (s, false));
							}
						}
					} else if (this._toInsert.Type.Equals ("TRUE_FALSE", StringComparison.OrdinalIgnoreCase)) {
						if (correctAns.Equals ("TRUE", StringComparison.OrdinalIgnoreCase)) {
							tmpPool.AddAnswer (new Answer ("TRUE", true));
							tmpPool.AddAnswer (new Answer ("FALSE", false));
						} else if (correctAns.Equals ("FALSE", StringComparison.OrdinalIgnoreCase)) {
							tmpPool.AddAnswer (new Answer ("FALSE", true));
							tmpPool.AddAnswer (new Answer ("TRUE", false));
						}
					}
				} else {
					tmpPool.AddAnswer (new Answer (correctAns, true));
				}
			}
			return tmpPool;
		}

		void clearInfo ()
		{
			this._questionString.GetComponentsInChildren<Text> () [1].text = "";
			this._answerString.GetComponentsInChildren<Text> () [1].text = "";
			this._correctAnswer.GetComponentsInChildren<Text> () [1].text = "";
			this._subject.GetComponentsInChildren<Text> () [1].text = "";
			this._difficulty.GetComponentsInChildren<Text> () [1].text = "";
		}

		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{

				switch(this.nxtState)
				{
				case nextDbManState.HOW_TO:
					this._DbManCvs.enabled = false;
					removeListeners ();
					this._chkState = false;
					GameObject.Instantiate (Resources.Load ("HowToCvs") as GameObject);
					break;
				case nextDbManState.DATABASE:
					this._dbConn = DatabaseConnector.Instance;
					this._answers = this._answerString.GetComponentsInChildren<Text> () [1].text;
					this._correct = this._correctAnswer.GetComponentsInChildren<Text> () [1].text;
					this._question = this._questionString.GetComponentsInChildren<Text> () [1].text;
					this._subjectStr = this._subject.GetComponentsInChildren<Text> () [1].text;
					Int32.TryParse(this._difficulty.GetComponentsInChildren<Text> () [1].text, out this._diff);

					switch(this.qt)
					{
					case questType.MC:
						_toInsert = new MultiChoiceQuestion(this._subjectStr, this._diff, this._question, "1");
						break;
					case questType.SA:
						_toInsert = new ShortAnswerQuestion(this._subjectStr, this._diff, this._question, "1");
						break;
					case questType.TF:
						_toInsert = new TrueFalseQuestion(this._subjectStr, this._diff, this._question, "1");
						break;
					}
					if(this._submit)
					{
						this._newAnswers = buildAnswerPool(this._answers, this._correct);
						this._toInsert.Answers = this._newAnswers;
						if(this._dbConn.InsertQuestion (this._toInsert))
							Debug.Log ("Success");
						clearInfo ();
						this._submit = false;
					}

					this.qt = questType.NULL;
					break;
				case nextDbManState.MAIN_MENU:
					this._DbManCvs.enabled = false;
					removeListeners ();
					this._chkState = false;
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				}
			}
		}
	}
	
}
