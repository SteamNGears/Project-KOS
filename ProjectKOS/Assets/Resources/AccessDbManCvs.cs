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

		private int _diff;

		private Button _addToDB;
		private Button _mainMenu;
		private Button _typeMC;
		private Button _typeSA;
		private Button _typeTF;

		private bool _chkState;

		public enum nextDbManState {DATABASE, MAIN_MENU};
		public enum questType {MC, SA, TF, NULL};
		public questType qt;
		public nextDbManState nxtState;

		private DatabaseConnector _dbConn;
		private Question _toInsert;

		// Use this for initialization
		void Start () {
			this._DbManCvs = this.GetComponentInChildren<Canvas> ();

			this._questionString = this._DbManCvs.GetComponentsInChildren<InputField> () [0];
			this._answerString = this._DbManCvs.GetComponentsInChildren<InputField> () [1];
			this._correctAnswer = this._DbManCvs.GetComponentsInChildren<InputField> () [2];
			this._difficulty = this._DbManCvs.GetComponentsInChildren<InputField> () [3];

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
		}

		void databaseAdd ()
		{
			this.nxtState = nextDbManState.DATABASE;
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

		public string answers{
			get{
				if(this.answers != "")
					return this.answers;
				else
					return "";
			}
			private set{
				if(value != "")
					this.answers = value;
				else
				{
					this._answerString.GetComponentsInChildren<Text> () [0].text = "Answers blank";
				}
			}
		}

		public string correct{
			get{
				if(this.correct != "")
					return this.correct;
				else
					return "";
			}
			private set{
				if(value != "")
					this.correct = value;
				else
				{
					this._correctAnswer.GetComponentsInChildren<Text> () [0].text = "Correct answer blank";
				}
			}
		}

		public string question{
			get{
				if(this.question != "")
					return this.question;
				else
					return "";
			}
			private set{
				if(value != "")
					this.question = value;
				else
				{
					this._questionString.GetComponentsInChildren<Text> () [0].text = "Question blank";
				}
			}
		}

		void removeListeners()
		{
			this._addToDB.onClick.RemoveListener (databaseAdd);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}

		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{

				switch(this.nxtState)
				{
				case nextDbManState.DATABASE:
					this._dbConn = DatabaseConnector.Instance;
					this.answers = this._answerString.GetComponentsInChildren<Text> () [1].text;
					this.correct = this._correctAnswer.GetComponentsInChildren<Text> () [1].text;
					this.question = this._questionString.GetComponentsInChildren<Text> () [1].text;
					Int32.TryParse(this._difficulty.GetComponentsInChildren<Text> () [1].text, out this._diff);
					switch(this.qt)
					{
					case questType.MC:
						_toInsert = new MultiChoiceQuestion();
						break;
					case questType.SA:
						_toInsert = new ShortAnswerQuestion();
						break;
					case questType.TF:
						_toInsert = new TrueFalseQuestion();
						break;
					}
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
