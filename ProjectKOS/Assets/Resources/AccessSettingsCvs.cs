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
			this._mainMenu.onClick.AddListener (returnToMain);
			
		}
		
		void returnToMain ()
		{
			this.nxtSet = nextSetting.MAIN_MENU;
			this.checkSet = true;
			this._mainMenu.onClick.RemoveListener (returnToMain);
		}
		
		void rollCredits ()
		{
			this.nxtSet = nextSetting.CREDITS;
			this.checkSet = true;
			this._credits.onClick.RemoveListener (rollCredits);
		}
		
		// Update is called once per frame
		void Update () {
			
		}
	}
	
}
