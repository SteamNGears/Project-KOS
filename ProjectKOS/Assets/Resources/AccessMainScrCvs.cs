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

		public Canvas msCvs;

		private Button _play;
		private Button _load;
		private Button _settings;
		private Button _dbManager;
		private Button _exit;

		public bool checkState;

		public enum nextState {NEW_GAME, LOAD_GAME, SETTINGS, DB_MANAGER, EXIT_GAME};
		public nextState nxtState;

		// Use this for initialization
		void Start () {
			this.msCvs = this.GetComponentInChildren<Canvas> ();

			this._play = this.msCvs.GetComponentsInChildren<Button> () [0];
			this._play.onClick.AddListener (playNewListener);
			this._load = this.msCvs.GetComponentsInChildren<Button> () [1];
			this._load.onClick.AddListener (loadGameListener);
			this._settings = this.msCvs.GetComponentsInChildren<Button> () [2];
			this._settings.onClick.AddListener (settingsListener);
			this._dbManager = this.msCvs.GetComponentsInChildren<Button> () [3];
			this._dbManager.onClick.AddListener (dbManListener);
			this._exit = this.msCvs.GetComponentsInChildren<Button> () [4];
			this._exit.onClick.AddListener (exitGameListener);
		}

		void dbManListener ()
		{
			this.nxtState = nextState.DB_MANAGER;
			checkState = true;

		}

		void exitGameListener ()
		{
			this.nxtState = nextState.EXIT_GAME;
			checkState = true;
		}

		void loadGameListener ()
		{
			this.nxtState = nextState.LOAD_GAME;
			checkState = true;
		}

		void playNewListener ()
		{
			this.nxtState = nextState.NEW_GAME;
			checkState = true;
		}

		void settingsListener ()
		{
			this.nxtState = nextState.SETTINGS;
			checkState = true;
		}

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

			if (checkState) {
				this.msCvs.enabled = false;
				removeListeners ();
				switch(this.nxtState)
				{
					case nextState.NEW_GAME:
						Application.LoadLevel("TrainingRoom");
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
						Application.Quit ();
						break;
				}
				this.checkState = false;
			}

		}
	}

}
