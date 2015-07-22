/**
 * Filename: AccessLoadCvs.cs
 * Author: Chris Hatch
 * Created: 5/28/2015
 * Revision: 1.0
 * Rev. Date: 7/19/2015
 * Rev. Author: Jakob Wilson
 * Rev. Info: Rewrote to automatically look up files in save directory and allow the user to select one
 * */
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using SaveLoad;
using System.IO;

namespace AssemblyCSharp
{
	public class AccessLoadCvs : MonoBehaviour 
	{

		private GameObject _scrollRect;					/*< Th scroll rect that will contain all the buttons*/
		private string _filepath = "SavedGames";		/*< The path for the saved games*/
		private List<GameObject> _savedGameButtons;		/*< A list of all the save files*/
		private Button _backButton;						/*< The button to go back*/

		/**
		 * Gets the canvas and sets up button listeners
		 * */
		void Start () {
			this.GetSavedGames ();

			//set up the back button by selecting the first button found in the heirarchy(since there is only one button on this layer)
			this._backButton = this.GetComponentInChildren<Button> ();//this should be changed to use transform.find if more buttons are added later
			this._backButton.onClick.AddListener (this.End);


		}

		// Update is called once per frame
		void Update () 
		{

		}

		/**
		 * Looks in the save directory and gets a list of all applicable save files
		 * */
		private void GetSavedGames()
		{
			DirectoryInfo info = new DirectoryInfo(this._filepath);//get the file path
			this._savedGameButtons = new List<GameObject> ();
			GameObject scrollContent = this.GetComponentInChildren<ScrollRect>().transform.Find("ScrollContent").gameObject;

			//for each file, create a button, set the text, and parent(to the scroll content), then add it to the buttons list so it can be cleaned up
			foreach (var fi in info.GetFiles())
			{
				GameObject b = GameObject.Instantiate(Resources.Load("UI/Button") as GameObject);
				b.GetComponentInChildren<Text>().text = fi.Name;
				b.transform.SetParent(scrollContent.transform, false);
				b.GetComponent<RectTransform>().localPosition = new Vector3(0,this._savedGameButtons.Count * -30 + scrollContent.GetComponent<RectTransform>().rect.height/2 - 20, 0);
				b.GetComponent<RectTransform>().sizeDelta = new Vector2(200, 30);
				b.GetComponent<Button>().onClick.AddListener(delegate() {SaveLoadManager.Instance.LoadGame(fi.Name);});
				this._savedGameButtons.Add(b);

			}
		}

		/**
		 * cleans up all the buttons from the canvas
		 * */
		private void CleanUp()
		{
			foreach (GameObject g in this._savedGameButtons)
				GameObject.Destroy (g);
		}

		/*
		 * Cleans up listeners and returns to main menu
		 * */
		private void End()
		{
			this._backButton.onClick.RemoveListener (this.End);
			this.CleanUp ();

			GameObject.Instantiate (Resources.Load ("MainScrCvs") as GameObject);
			GameObject.Destroy (this.gameObject);
		}

	}
	
}















