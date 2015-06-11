/**
 * Filename: AccessLoadCvs.cs
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
using SaveLoad;
namespace AssemblyCSharp
{
	public class AccessLoadCvs : MonoBehaviour {
		
		private Canvas _loadCvs;

		private Button _checkFiles;
		private Button _loadFile;
		private Button _mainMenu;

		private Text _fileSelections;

		private InputField _fileName;

		private bool _chkState;
		private bool _fileNameEntered;

		public enum nextLoadState {CHECK_FILES, LOAD_FILE, MAIN_MENU};
		public nextLoadState nxtLState;

		// Use this for initialization
		void Start () {
			this._loadCvs = this.GetComponentInChildren<Canvas> ();

			this._checkFiles = this.GetComponentsInChildren<Button> () [0];
			this._checkFiles.onClick.AddListener (chkFiles);
			this._loadFile = this.GetComponentsInChildren<Button> () [1];
			this._loadFile.onClick.AddListener (loadFile);
			this._mainMenu = this.GetComponentsInChildren<Button> () [2];
			this._mainMenu.onClick.AddListener (mainMenu);

			this._fileSelections = this._loadCvs.GetComponentInChildren<Text> ();
			this._fileName = this._loadCvs.GetComponentInChildren<InputField> ();

		}

		void chkFiles ()
		{
			this.nxtLState = nextLoadState.CHECK_FILES;
			this._chkState = true;
		}

		void loadFile ()
		{
			this.nxtLState = nextLoadState.LOAD_FILE;
			this._chkState = true;
			this.fileName = this._fileName.GetComponentsInChildren<Text> () [1].text;
		}

		void mainMenu ()
		{
			this.nxtLState = nextLoadState.MAIN_MENU;
			this._chkState = true;
		}

		void removeListeners()
		{
			this._checkFiles.onClick.RemoveListener (chkFiles);
			this._loadFile.onClick.RemoveListener (loadFile);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}

		public string fileName{
			get{
					return this._fileName.text;
			}
			private set{
				if(value != null)
					this._fileName.text = value;
				else
					this._fileName.GetComponentsInChildren<Text> () [0].text = "No filename entered";
			}
		}
		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{
				this._loadCvs.enabled = false;
				switch(this.nxtLState)
				{
				case nextLoadState.CHECK_FILES:
					//checkFiles();
					break;
				case nextLoadState.LOAD_FILE:
					SaveLoadManager.Instance.LoadGame(this.fileName);
					this._chkState = false;
					Application.LoadLevel("RecruitArea");
					break;
				case nextLoadState.MAIN_MENU:
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				}
				removeListeners();
				this._chkState = false;
			}
		}
	}
	
}
