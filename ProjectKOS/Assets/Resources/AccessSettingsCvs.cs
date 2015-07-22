/**
 * Filename: AccessSettingsCvs.cs
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
	public class AccessSettingsCvs : MonoBehaviour {
		
		private Canvas _settingsCvs;//   settings canvas

		private Button _credits;//   button to request game credits to be shown
		private Button _mainMenu;//  button to return to main menu
		private Button _keyboardLayout;//   button to request keyboard layout panel
		
		public bool chkSet;//   bool to enable a transition
		
		public enum nextSetting {CREDITS, MAIN_MENU, KEYBOARD};//   enums representing new states
		public nextSetting nxtSet;//   user chosen state
		
		// Use this for initialization
		void Start () {
			this._settingsCvs = this.GetComponentInChildren<Canvas> ();

			this._credits = this._settingsCvs.GetComponentsInChildren<Button> () [0];
			this._credits.onClick.AddListener (rollCredits);//   listener request credits
			this._mainMenu = this._settingsCvs.GetComponentsInChildren<Button> () [1];
			this._mainMenu.onClick.AddListener (mainMenu);//   listener to request main menu
			this._keyboardLayout = this._settingsCvs.GetComponentsInChildren<Button> () [2];
			this._keyboardLayout.onClick.AddListener (keyLayout);//   listener to request keyboard layout
			
		}

		/**
		 * listener to request for return to main menu panel
		 * */
		void mainMenu ()
		{
			this.nxtSet = nextSetting.MAIN_MENU;
			this.chkSet = true;
		}

		/**
		 * listener to request keyboard layout panel
		 * */
		void keyLayout ()
		{
			this.nxtSet = nextSetting.KEYBOARD;
			this.chkSet = true;
		}

		/**
		 * method to clean up all listeners
		 * */
		void removeListeners ()
		{
			this._credits.onClick.RemoveListener (rollCredits);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}

		/**
		 * listener to request credit panel
		 * */
		void rollCredits ()
		{
			this.nxtSet = nextSetting.CREDITS;
			this.chkSet = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) {
				//this._settingsCvs.enabled = false;
				removeListeners ();//   clean up listeners
				switch (this.nxtSet) {
				case nextSetting.CREDITS:
					GameObject.Instantiate (Resources.Load ("CreditsCvs") as GameObject);//   load credits
					break;
				case nextSetting.MAIN_MENU:
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);//   load main menu
					break;
				case nextSetting.KEYBOARD:
					GameObject.Instantiate (Resources.Load ("KeyCvs") as GameObject);//   load keyboard layout
					break;
				}
				this.chkSet = false;
				GameObject.Destroy(this.gameObject);
			}
		}
	}
	
}
