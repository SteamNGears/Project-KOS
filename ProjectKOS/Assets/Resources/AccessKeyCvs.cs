﻿/**
 * Filename: AccessKeyCvs.cs
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
	public class AccessKeyCvs : MonoBehaviour {
		
		private Canvas _keyCvs;//   keyboard layout canvas

		private Button _settings;//   button to return to settings screen
		
		public bool chkSet;//   bool to tell system to change state



		// Use this for initialization
		void Start () {
			this._keyCvs = this.GetComponentInChildren<Canvas> ();

			this._settings = this._keyCvs.GetComponentsInChildren<Button> () [0];
			this._settings.onClick.AddListener (settings);//   listener to return to settings screen	
		}

		/**
		 * listener to return to settings screen: cleans up itself
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
				this._keyCvs.enabled = false;
				this.chkSet = false;
				GameObject.Instantiate (Resources.Load ("SettingsCvs") as GameObject);
			}
		}
	}
	
}
