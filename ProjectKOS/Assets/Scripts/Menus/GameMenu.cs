using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using SaveLoad;

public class GameMenu : MonoBehaviour {

	/* All the menu buttons*/
	private Button _saveButton;
	private Button _quitButton;
	private Button _resumeButton;



	// Use this for initialization
	void Start () {
		//set up all buttons and listeners
		Button[] buttons = this.GetComponentsInChildren<Button> ();
		this._saveButton = buttons [0];
		this._quitButton = buttons [1];
		this._resumeButton = buttons [2];

		//add button listeners
		this._saveButton.onClick.AddListener (this.Save);
		this._quitButton.onClick.AddListener (this.Quit);
		this._resumeButton.onClick.AddListener (this.Resume);
		
	}
	
	// Update is called once per frame
	void Update () {

	}

	/**
	 * Saved the game using the save/load manager, then exits the menu
	 * */
	public void Save()
	{
		SaveLoadManager.Instance.SaveGame ();
	}
	
	/**
	 * Exits the game without saving by bringing the player back to the main menu
	 * */
	public void Quit()
	{
		//load up the main menu without saving
		this.CleanUp ();
		Application.LoadLevel (0);
	}

	/**
	 * Resumes the game by simply removing the menu canvas
	 * */
	public void Resume()
	{
		this.CleanUp ();
		GameObject.Destroy (this.gameObject);
	}

	/**
	 * Cleans up all button listeners
	 * */
	private void CleanUp()
	{
		this._saveButton.onClick.RemoveListener (this.Save);
		this._quitButton.onClick.RemoveListener (this.Quit);
		this._resumeButton.onClick.RemoveListener(this.Resume);
	}

}
