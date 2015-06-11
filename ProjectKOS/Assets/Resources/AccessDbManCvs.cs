/**
 * Filename: AccessDbManCvs.cs
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
using Database;
namespace AssemblyCSharp
{
	public class AccessDbManCvs : MonoBehaviour {
		
		private Canvas _DbManCvs;

		private Button _mainMenu;
		private Button _typeMC;
		private Button _typeSA;
		private Button _typeTF;

		private bool _chkState;

		public enum nextDbManState {DATABASE, MAIN_MENU};
		public enum questType {MC, SA, TF, NULL};
		public questType qt;
		public nextDbManState nxtState;

		// Use this for initialization
		void Start () {
			this._DbManCvs = this.GetComponentInChildren<Canvas> ();

			this._mainMenu = this._DbManCvs.GetComponentsInChildren<Button> () [0];
			this._mainMenu.onClick.AddListener (mainMenu);
			this._typeMC = this._DbManCvs.GetComponentsInChildren<Button> () [1];
			this._typeMC.onClick.AddListener (typeMc);
			this._typeSA = this._DbManCvs.GetComponentsInChildren<Button> () [2];
			this._typeSA.onClick.AddListener (typeSa);
			this._typeTF = this._DbManCvs.GetComponentsInChildren<Button> () [3];
			this._typeTF.onClick.AddListener (typeTf);

		}
	
		void mainMenu ()
		{
			this.nxtState = nextDbManState.MAIN_MENU;
			this._chkState = true;
		}

		void typeMc ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.MC;
			this._chkState = true;
		}

		void typeSa ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.SA;
			this._chkState = true;
		}

		void typeTf ()
		{
			this.nxtState = nextDbManState.DATABASE;
			this.qt = questType.TF;
			this._chkState = true;
		}

		void removeListeners()
		{
			this._mainMenu.onClick.RemoveListener (mainMenu);
			this._typeMC.onClick.RemoveListener (typeMc);
			this._typeSA.onClick.RemoveListener (typeSa);
			this._typeTF.onClick.RemoveListener (typeTf);
		}


		// Update is called once per frame
		void Update () {
			if (this._chkState) 
			{

				switch(this.nxtState)
				{
				case nextDbManState.DATABASE:
					this._DbManCvs.enabled = false;//disables dbMan canvas
					switch(this.qt)
					{
					case questType.MC:
						GameObject.Instantiate (Resources.Load ("MCInputCvs") as GameObject);
						break;
					case questType.SA:
						GameObject.Instantiate (Resources.Load ("SAInputCvs") as GameObject);
						break;
					case questType.TF:
						GameObject.Instantiate (Resources.Load ("TFInputCvs") as GameObject);
						break;
					}
					this._chkState = false;
					this.qt = questType.NULL;
					break;
				case nextDbManState.MAIN_MENU:
					this._DbManCvs.enabled = false;//disables dbMan canvas
					removeListeners ();//cleans up listeners on request for return to main menu only
					this._chkState = false;
					GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
					break;
				}
			}
		}
	}
	
}
