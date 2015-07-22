/**
 * Filename: InteractButtonState.cs
 * Author: Jakob Wilson
 * Created: 5/9/2015
 * Revision: 1
 * Rev. Date:
 * Rev. Author: Jakob Wilson
 * */



using System;
using UnityEngine;
using UnityEngine.UI;
namespace States
{
	/**
	 * This state displays an "interact" button when the user approaches a door
	 * After the user interacts, it transitions to a question select state
	 * */
	public class InteractButtonState:InteractionState
	{

		private GameObject cvsQuestion;	/**The canvas containing the "interact" button"*/
		Button btnInteract;				/**The interact button itself(gotten from the canvas)*/
		private bool buttonClicked;		/**Whether or not the interact button has been clicked*/


		/**
		 * Sets default values and calls base constructor
		 * */
		public InteractButtonState (GameObject _actee, GameObject _actor = null):base(_actee, _actor)
		{
			this.actee.GetComponent<Interaction> ().ExitSignal += this.Suspend;
			buttonClicked = false;
		}

		/**
		 * Displays a GUI with an interact button, 
		 * if the button is clicked, then the state is transitioned to an Opening State(See OpeningState.cs)
		 * @return - InteractionState - the next state or this state if button not clicked
		 * */
		public override InteractionState Behave ()
		{
			//if the gui doesn't exist, create it
			if (cvsQuestion == null && this.actor != null) 
			{

				if(this.actor.tag == "Player")
				{
					cvsQuestion = GameObject.Instantiate(Resources.Load("InteractionCanvas/InteractCanvas") as GameObject);//get the canvas
					btnInteract = cvsQuestion.GetComponentInChildren<Button> ();//get the button
					btnInteract.onClick.AddListener ( this.onButtonClick ); //add a listener for the click event
			
				}
			}

			//if the button has been clicked,
			if (this.buttonClicked) {
				GameObject.Destroy(this.cvsQuestion);	//clean up the question 
				return new QuestionSelectState(this.actee, this.actor);	//open the door
			}
			else
				return this;//continue incurrent state

		}

		/**
		 * Overriding suspend do that the button goes away when the user walks away from the door
		 * @return void
		 * */
		public override void Suspend(Collider c)
		{
			//remove event listener
			this.actee.GetComponent<Interaction> ().ExitSignal -= this.Suspend;
			this.actor = null;
			if(this.btnInteract != null)
				this.btnInteract.onClick.RemoveListener (this.onButtonClick);//clean up listener
			GameObject.Destroy (this.cvsQuestion);
		}

		/**
		 * An event handler for the button click
		 * On button click, the buttonclicked bool is set to true and the listener is cleaned up
		 * */
		void onButtonClick()
		{
			this.buttonClicked = true;	//set button clicked to true
			this.btnInteract.onClick.RemoveListener (this.onButtonClick);//clean up listener
		}

		
	}
}

