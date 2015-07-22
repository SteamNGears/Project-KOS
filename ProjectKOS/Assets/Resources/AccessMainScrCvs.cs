/**
 * Filename: AccessMainScrCvs.cs
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
	public class AccessMainScrCvs : MonoBehaviour {

		public Canvas msCvs;//   main screen canvas

		private Button _play;//   button to start new game
		private Button _load;//   button to move to load screen
		private Button _settings;//   button to move to settings screen
		private Button _dbManager;//   button to move to database manager
		private Button _exit;//   button to exit game

		public bool chkState;//   bool to check for state change

		public enum nextState {NEW_GAME, LOAD_GAME, SETTINGS, DB_MANAGER, EXIT_GAME};//   enums to move to new states
		public nextState nxtState;//   user selected next state

		// Use this for initialization
		void Start () {
			this.msCvs = this.GetComponentInChildren<Canvas> ();

			this._play = this.msCvs.GetComponentsInChildren<Button> () [0];
			this._play.onClick.AddListener (playNewListener);//   listener to request new game
			this._load = this.msCvs.GetComponentsInChildren<Button> () [1];
			this._load.onClick.AddListener (loadGameListener);//   listener to request load screen
			this._settings = this.msCvs.GetComponentsInChildren<Button> () [2];
			this._settings.onClick.AddListener (settingsListener);//   listener to request settings screen
			this._dbManager = this.msCvs.GetComponentsInChildren<Button> () [3];
			this._dbManager.onClick.AddListener (dbManListener);//   listener to request database manager
			this._exit = this.msCvs.GetComponentsInChildren<Button> () [4];
			this._exit.onClick.AddListener (exitGameListener);//   listener to request exit
		}

		/**
		 * listener to request database manager screen
		 * */
		void dbManListener ()
		{
			this.nxtState = nextState.DB_MANAGER;
			chkState = true;

		}

		/**
		 * listener to request for exit from the game
		 * */
		void exitGameListener ()
		{
			this.nxtState = nextState.EXIT_GAME;
			chkState = true;
		}

		/**
		 * listener to request for load game screen
		 * */
		void loadGameListener ()
		{
			this.nxtState = nextState.LOAD_GAME;
			chkState = true;
		}

		/**
		 * listener to request a new game instance
		 * */
		void playNewListener ()
		{
			this.nxtState = nextState.NEW_GAME;
			chkState = true;
		}

		/**
		 * listener to request for settings screen
		 * */
		void settingsListener ()
		{
			this.nxtState = nextState.SETTINGS;
			chkState = true;
		}

		/**
		 * clean up listeners only called after new game or exit
		 * */
		void removeListeners()
		{
			this._dbManager.onClick.RemoveListener (dbManListener);
			this._exit.onClick.RemoveListener (exitGameListener);
			this._load.onClick.RemoveListener (loadGameListener);
			this._play.onClick.RemoveListener (playNewListener);
			this._settings.onClick.RemoveListener (settingsListener);
		}

		// Update is called once per frame
		void Update () {

			if (this.chkState) {
				//this.msCvs.enabled = false;

				switch(this.nxtState)
				{
					case nextState.NEW_GAME:
						removeListeners ();//   clean up listeners
						Application.LoadLevel("RecruitArea");//   load fresh game instance
						break;
					case nextState.LOAD_GAME:
						GameObject.Instantiate(Resources.Load ("LoadCvs") as GameObject);
						break;
					case nextState.SETTINGS:
						GameObject.Instantiate(Resources.Load ("SettingsCvs") as GameObject);
						break;
					case nextState.DB_MANAGER:
						GameObject.Instantiate(Resources.Load ("DatabaseCvs") as GameObject);
						break;
					case nextState.EXIT_GAME:
						removeListeners ();//   clean up listeners
						Application.Quit ();//   exit game
						break;
				}
				this.chkState = false;
				GameObject.Destroy(this.gameObject);
			}

		}
	}

}
