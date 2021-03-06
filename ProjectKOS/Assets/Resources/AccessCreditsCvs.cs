﻿/**
 * Filename: AccessCreditsCvs.cs
 * Author: Chris Hatch
 * Created: 6/05/2015
 * Revision: 0
 * Rev. Date: 6/05/2015
 * Rev. Author: Chris Hatch
 * */
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
namespace AssemblyCSharp
{
	public class AccessCreditsCvs : MonoBehaviour {
		
		private Canvas _creditsCvs;//   credits screen canvas
		
		private Button _settings;//   button to return to settings screen
		
		public bool chkSet;//   bool to tell system to return to settings
		
		
		
		// Use this for initialization
		void Start () {
			this._creditsCvs = this.GetComponentInChildren<Canvas> ();
			
			this._settings = this._creditsCvs.GetComponentsInChildren<Button> () [0];
			this._settings.onClick.AddListener (settings);	//   listener to request settings screen		
		}

		/**
		 * listener to request return to settings screen
		 * */
		void settings ()
		{
			this._settings.onClick.RemoveListener (settings);
			this.chkSet = true;
		}
		
		// Update is called once per frame
		void Update () {
			if (this.chkSet) 
			{
				this._creditsCvs.enabled = false;
				this.chkSet = false;
				GameObject.Instantiate (Resources.Load ("SettingsCvs") as GameObject);
			}
		}
	}
	
}
