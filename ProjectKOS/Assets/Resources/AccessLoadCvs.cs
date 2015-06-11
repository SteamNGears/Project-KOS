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
		
		private Canvas _loadCvs;//   load screen canvas

		private Button _checkFiles;//   button to request file path checking
		private Button _loadFile;//   button to request a file to be loaded
		private Button _mainMenu;//   button to request return to main menu

		private Text _fileSelections;//   text panel to add file paths

		private InputField _fileName;//   InputField for user selected file path

		private bool _chkState;//   bool to check for next state
		private bool _fileNameEntered;//   bool to represent user has selected a file

		public enum nextLoadState {CHECK_FILES, LOAD_FILE, MAIN_MENU};//   enums to represent possible states
		public nextLoadState nxtLState;//   user selected state
		private SaveLoadManager slm;//   Object to enabled loading a saved file and find file paths
		public string fileName;

		// Use this for initialization
		void Start () {
			this._loadCvs = this.GetComponentInChildren<Canvas> ();

			this._checkFiles = this.GetComponentsInChildren<Button> () [0];
			this._checkFiles.onClick.AddListener (chkFiles);//   listener to request file paths
			this._loadFile = this.GetComponentsInChildren<Button> () [1];
			this._loadFile.onClick.AddListener (loadFile);//   listener to request a file to be loaded
			this._mainMenu = this.GetComponentsInChildren<Button> () [2];
			this._mainMenu.onClick.AddListener (mainMenu);//   listener to return to main menu

			this._fileSelections = this._loadCvs.GetComponentInChildren<Text> ();
			this._fileName = this._loadCvs.GetComponentInChildren<InputField> ();

		}

		/**
		 * listener to request a search for available files to load
		 * */
		void chkFiles ()
		{
			this.nxtLState = nextLoadState.CHECK_FILES;
			this._chkState = true;
		}

		/**
		 * listener to request for a user specified file path to be loaded
		 * */
		void loadFile ()
		{
			this.nxtLState = nextLoadState.LOAD_FILE;
			this._chkState = true;
			this.fileName = this._fileName.text;
		}

		/**
		 * listener to return to the main menu screen
		 * */
		void mainMenu ()
		{
			this.nxtLState = nextLoadState.MAIN_MENU;
			this._chkState = true;
		}

		/**
		 * clean up all listeners
		 * */
		void removeListeners()
		{
			this._checkFiles.onClick.RemoveListener (chkFiles);
			this._loadFile.onClick.RemoveListener (loadFile);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}

		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{
				slm = SaveLoadManager.Instance;
				switch(this.nxtLState)
				{
				case nextLoadState.CHECK_FILES:
					if(slm.GetFilePaths().Length == 0)
					{
						this._fileSelections.text = "No files present";//   update text panel
					}
					else
					{
						foreach (string s in slm.GetFilePaths())
						{
							this._fileSelections.text += (s + "\n");//   update text panel
						}
					}
					break;
				case nextLoadState.LOAD_FILE:
					this._loadCvs.enabled = false;//   disable load prefab
					removeListeners();//   Clean up listeners
					this._chkState = false;
					slm.LoadGame (this.fileName);

					break;
				case nextLoadState.MAIN_MENU:
					this._loadCvs.enabled = false;//   disable load prefab
					removeListeners();//   clean up listeners
					this._chkState = false;
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);//   reload main scr
					break;
				}

			}
		}
	}
	
}
