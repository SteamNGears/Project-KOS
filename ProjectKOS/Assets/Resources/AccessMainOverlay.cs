/**
 * Filename: AccessMainOverlay.cs
 * Author: Chris Hatch
 * Created: 6/11/2015
 * Revision: 0
 * Rev. Date: 6/11/2015
 * Rev. Author: Chris Hatch
 * */

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using SaveLoad;
namespace AssemblyCSharp{
	public class AccessMainOverlay : MonoBehaviour {

		private Canvas _mainOverlay;//   main overlay canvas

		private Button _mainMenu;//   button to return to main menu
		private Button _saveGame;//   button to save game state

		public enum nxtState {MAIN_MENU, SAVE_GAME};//   enum to represent next state
		private nxtState _state;//   user selected state

		private bool _chkState;//   bool to represent needed state change
		private SaveLoadManager _slm;

		// Use this for initialization
		void Start () {

			this._mainOverlay = this.GetComponentInParent<Canvas> ();

			this._mainMenu = this._mainOverlay.GetComponentsInChildren<Button> () [0];
			this._mainMenu.onClick.AddListener (mainMenu);//   listener to request main menu
			this._saveGame = this._mainOverlay.GetComponentsInChildren<Button> () [1];
			this._saveGame.onClick.AddListener (saveGame);//   listener to request save game
		}

		/**
		 * listener for user requesting to return to main menu
		 * */
		void mainMenu ()
		{
			this._state = nxtState.MAIN_MENU;
			this._chkState = true;
		}

		/**
		 * listener requesting system to save data
		 * */
		void saveGame ()
		{
			this._state = nxtState.SAVE_GAME;
			this._chkState = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{
				this._slm = SaveLoadManager.Instance;
				switch(this._state)
				{
				case nxtState.MAIN_MENU:
					Application.LoadLevel ("mainScene");
					this._chkState = false;
					break;
				case nxtState.SAVE_GAME:
					this._slm.SaveGame ();
					this._chkState = false;
					break;
				}
			}
		}
	}

}
