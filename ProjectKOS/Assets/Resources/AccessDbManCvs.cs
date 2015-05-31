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
namespace AssemblyCSharp
{
	public class AccessDbManCvs : MonoBehaviour {
		
		private Canvas _DbManCvs;
		
		private InputField _questionType;
		private InputField _questionString;
		private InputField _answerString;
		private InputField _correctAnswer;
		private InputField _difficulty;

		private int _diff;

		private Button _addToDB;
		private Button _mainMenu;

		public bool checkState;

		public enum nextDbManState {DATABASE, MAIN_MENU};
		public nextDbManState nxtState;

		// Use this for initialization
		void Start () {
			this._DbManCvs = this.GetComponentInChildren<Canvas> ();

			this._questionType = this._DbManCvs.GetComponentsInChildren<InputField> () [0];
			this._questionString = this._DbManCvs.GetComponentsInChildren<InputField> () [1];
			this._answerString = this._DbManCvs.GetComponentsInChildren<InputField> () [2];
			this._correctAnswer = this._DbManCvs.GetComponentsInChildren<InputField> () [3];
			this._difficulty = this._DbManCvs.GetComponentsInChildren<InputField> () [4];

			this._addToDB = this._DbManCvs.GetComponentsInChildren<Button> () [0];
			this._addToDB.onClick.AddListener (databaseAdd);
			this._mainMenu = this._DbManCvs.GetComponentsInChildren<Button> () [1];
			this._mainMenu.onClick.AddListener (returnToMain);
		}

		void databaseAdd ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.checkState = true;
			this.answers = this._answerString.GetComponentsInChildren<Text> () [1].text;
			this.correct = this._correctAnswer.GetComponentsInChildren<Text> () [1].text;
			this.qType = this._questionType.GetComponentsInChildren<Text> () [1].text;
			this.question = this._questionString.GetComponentsInChildren<Text> () [1].text;
			Int32.TryParse(this._difficulty.GetComponentsInChildren<Text> () [1].text, out this._diff);
			this._addToDB.onClick.RemoveListener (databaseAdd);
		}

		void returnToMain ()
		{
			this.nxtState = nextDbManState.MAIN_MENU;
			this.checkState = true;
			this._mainMenu.onClick.RemoveListener (returnToMain);
		}

		public string answers{
			get{
				if(this.answers != null)
					return this.answers;
				else
					return "";
			}
			private set{
				this.answers = value;
			}
		}

		public string correct{
			get{
				if(this.correct != null)
					return this.correct;
				else
					return "";
			}
			private set{
				this.correct = value;
			}
		}

		public int diff{
			get{
					return this.diff;
			}
			private set{
				this.diff = value;
			}
		}

		public string qType{
			get{
				if(this.qType != null)
					return this.qType;
				else
					return "";
			}
			private set{
				this.qType = value;
			}
		}

		public string question{
			get{
				if(this.question != null)
					return this.question;
				else
					return "";
			}
			private set{
				this.question = value;
			}
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
	
}
