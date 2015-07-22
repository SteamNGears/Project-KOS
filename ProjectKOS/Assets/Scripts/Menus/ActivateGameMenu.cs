using UnityEngine;
using System.Collections;

public class ActivateGameMenu : MonoBehaviour {

	private GameObject _menu;

	// Use this for initialization
	void Start () {
		this._menu = null;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Escape) && this._menu == null) 
		{
			this._menu = GameObject.Instantiate (Resources.Load ("GamePlay/CvsGameMenu") as GameObject);
		}

	}
}
