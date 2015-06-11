/**
 * Filename: GameOver.cs
 * Author: Jakob Wilson
 * Created: 6/5/2015
 * Revision: 
 * Rev. Date: 
 * Rev. Author: 
 * */


using UnityEngine;
using System.Collections;
using UnityEngine.UI;


/**
 * This class is to be attached to the failure GUI 
 * This class handles the onclick event for the button
 * when the ok button is clicked, it beings the player bacj to the main menu
 * 
 * */
public class GameOver : MonoBehaviour {


	private Button ok; 		/**A reference to the button in the canvas*/


	/**
	 * Sets the button reference and adds the button listener
	 * */
	void Start () {
		ok = this.GetComponentInChildren<Button>();
		ok.onClick.AddListener (this.OnClick);
	}

	/**
	 * Does nothing
	 * */
	// Update is called once per frame
	void Update () {
	
	}
	/**
	 * Handles the button click by cleaning up listeners
	 * and loading the main scene
	 * */
	void OnClick()
	{
		ok.onClick.RemoveListener (this.OnClick);
		Application.LoadLevel ("mainScene");
	}
}
