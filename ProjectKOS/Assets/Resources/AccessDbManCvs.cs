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
		
		private Canvas _DbManCvs;//   db screen canvas

		private Button _mainMenu;//   button to return to main menu
		private Button _typeMC;//   button to enter mult choice question
		private Button _typeSA;//   button to enter short answer question
		private Button _typeTF;//   button to enter true false question

		private bool _chkState;//   bool to tell system to check state

		public enum nextDbManState {DATABASE, MAIN_MENU};//   enums to represent states
		public enum questType {MC, SA, TF, NULL};//   enums to represent question types
		public questType qt;//   enum to select question type
		public nextDbManState nxtState;//   enum to switch states

		// Use this for initialization
		void Start () {
			this._DbManCvs = this.GetComponentInChildren<Canvas> ();

			this._mainMenu = this._DbManCvs.GetComponentsInChildren<Button> () [0];
			this._mainMenu.onClick.AddListener (mainMenu);//   listener for main menu
			this._typeMC = this._DbManCvs.GetComponentsInChildren<Button> () [1];
			this._typeMC.onClick.AddListener (typeMc);//   listener for mult choice input
			this._typeSA = this._DbManCvs.GetComponentsInChildren<Button> () [2];
			this._typeSA.onClick.AddListener (typeSa);//   listener for short answer input
			this._typeTF = this._DbManCvs.GetComponentsInChildren<Button> () [3];
			this._typeTF.onClick.AddListener (typeTf);//   listener for true false input

		}
	
		/**
		 * listener to request main menu screen
		 * */
		void mainMenu ()
		{
			this.nxtState = nextDbManState.MAIN_MENU;
			this._chkState = true;
		}

		/**
		 * listener to request mc input screen
		 * */
		void typeMc ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.MC;
			this._chkState = true;
		}

		/**
		 * listener to request sa input screen
		 * */
		void typeSa ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.SA;
			this._chkState = true;
		}

		/**
		 * listener to request tf input screen
		 * */
		void typeTf ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.TF;
			this._chkState = true;
		}

		/**
		 * cleans up all listeners
		 * */
		void removeListeners()
		{
			this._mainMenu.onClick.RemoveListener (mainMenu);
			this._typeMC.onClick.RemoveListener (typeMc);
			this._typeSA.onClick.RemoveListener (typeSa);
			this._typeTF.onClick.RemoveListener (typeTf);
		}


		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{

				switch(this.nxtState)
				{
				case nextDbManState.DATABASE:
					this._DbManCvs.enabled = false;//disables dbMan canvas
					switch(this.qt)
					{
					case questType.MC://   calls mcinput screen
						GameObject.Instantiate (Resources.Load ("MCInputCvs") as GameObject);
						break;
					case questType.SA://   calls sainput screen
						GameObject.Instantiate (Resources.Load ("SAInputCvs") as GameObject);
						break;
					case questType.TF://   calls tfinput screen
						GameObject.Instantiate (Resources.Load ("TFInputCvs") as GameObject);
						break;
					}
					this._chkState = false;
					this.qt = questType.NULL;
					break;
				case nextDbManState.MAIN_MENU:
					this._DbManCvs.enabled = false;//disables dbMan canvas
					removeListeners ();//cleans up listeners on request for return to main menu only
					this._chkState = false;
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				}
			}
		}
	}
	
}
