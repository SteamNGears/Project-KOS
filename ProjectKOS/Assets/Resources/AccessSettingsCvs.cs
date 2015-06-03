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
		
		private Slider _volume;
		private Button _credits;
		private Button _mainMenu;
		
		public bool checkSet;
		
		public enum nextSetting {CREDITS, MAIN_MENU};
		public nextSetting nxtSet;
		
		// Use this for initialization
		void Start () {
			this._settingsCvs = this.GetComponentInChildren<Canvas> ();
			
			this._volume = this._settingsCvs.GetComponentInChildren<Slider> ();
			
			this._credits = this._settingsCvs.GetComponentsInChildren<Button> () [0];
			this._credits.onClick.AddListener (rollCredits);
			this._mainMenu = this._settingsCvs.GetComponentsInChildren<Button> () [1];
			this._mainMenu.onClick.AddListener (mainMenu);
			
		}
		
		void mainMenu ()
		{
			this.nxtSet = nextSetting.MAIN_MENU;
			this.checkSet = true;
		}

		void removeListeners ()
		{
			this._credits.onClick.RemoveListener (rollCredits);
			this._mainMenu.onClick.RemoveListener (mainMenu);
		}
		
		void rollCredits ()
		{
			this.nxtSet = nextSetting.CREDITS;
			this.checkSet = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.checkSet) 
			{
				this._settingsCvs.enabled = false;
				removeListeners();
				switch(this.nxtSet)
				{
				case nextSetting.CREDITS:
					//load credits
					break;
				case nextSetting.MAIN_MENU:
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				}
				this.checkSet = false;
			}
		}
	}
	
}
