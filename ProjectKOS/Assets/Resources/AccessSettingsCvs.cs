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
		
		private Canvas _settingsCvs;

		private Button _credits;
		private Button _mainMenu;
		private Button _keyboardLayout;
		
		public bool chkSet;
		
		public enum nextSetting {CREDITS, MAIN_MENU, KEYBOARD};
		public nextSetting nxtSet;
		
		// Use this for initialization
		void Start () {
			this._settingsCvs = this.GetComponentInChildren<Canvas> ();

			this._credits = this._settingsCvs.GetComponentsInChildren<Button> () [0];
			this._credits.onClick.AddListener (rollCredits);
			this._mainMenu = this._settingsCvs.GetComponentsInChildren<Button> () [1];
			this._mainMenu.onClick.AddListener (mainMenu);
			this._keyboardLayout = this._settingsCvs.GetComponentsInChildren<Button> () [2];
			this._keyboardLayout.onClick.AddListener (keyLayout);
			
		}
		
		void mainMenu ()
		{
			this.nxtSet = nextSetting.MAIN_MENU;
			this.chkSet = true;
		}

		void keyLayout ()
		{
			this.nxtSet = nextSetting.KEYBOARD;
			this.chkSet = true;
		}

		void removeListeners ()
		{
			this._credits.onClick.RemoveListener (rollCredits);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}
		
		void rollCredits ()
		{
			this.nxtSet = nextSetting.CREDITS;
			this.chkSet = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) {
				this._settingsCvs.enabled = false;
				removeListeners ();
				switch (this.nxtSet) {
				case nextSetting.CREDITS:
					GameObject.Instantiate (Resources.Load ("CreditsCvs") as GameObject);
					break;
				case nextSetting.MAIN_MENU:
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				case nextSetting.KEYBOARD:
					GameObject.Instantiate (Resources.Load ("KeyCvs") as GameObject);
					break;
				}
				this.chkSet = false;
			}
		}
	}
	
}
