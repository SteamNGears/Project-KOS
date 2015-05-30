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
using System.Collections;
namespace AssemblyCSharp
{
	public class AccessMainScrCvs : MonoBehaviour {

		private Canvas _msCvs;

		private Button _play;
		private Button _load;
		private Button _settings;
		private Button _dbManager;


		public enum nextState {NEW_GAME, LOAD_GAME, SETTINGS, DB_MANAGER};
		public nextState nxtState;
		public bool checkState;

		// Use this for initialization
		void Start () {
			this._msCvs = this.GetComponentInParent<Canvas> ();

			this._play = this._msCvs.GetComponentsInChildren<Button> () [0];
			this._play.onClick.AddListener (playListener);
			this._load = this._msCvs.GetComponentsInChildren<Button> () [1];
			this._load.onClick.AddListener (loadListener);
			this._settings = this._msCvs.GetComponentsInChildren<Button> () [2];
			this._settings.onClick.AddListener (settingsListener);
			this._dbManager = this._msCvs.GetComponentsInChildren<Button> () [3];
			this._dbManager.onClick.AddListener (dbManListener);
		}

		void dbManListener ()
		{
			this.nxtState = nextState.DB_MANAGER;
			checkState = true;
			this._dbManager.onClick.RemoveListener (dbManListener);
		}

		void loadListener ()
		{
			this.nxtState = nextState.LOAD_GAME;
			checkState = true;
			this._load.onClick.RemoveListener (loadListener);
		}

		void playListener ()
		{
			this.nxtState = nextState.NEW_GAME;
			checkState = true;
			this._play.onClick.RemoveListener (playListener);
		}

		void settingsListener ()
		{
			this.nxtState = nextState.SETTINGS;
			checkState = true;
			this._settings.onClick.RemoveListener (settingsListener);
		}

		// Update is called once per frame
		void Update () {
			
		}
	}

}
