/**
 * Filename: Interaction.cs
 * Author: Jakob Wilson
 * Created: 5/5/2015
 * Revision: 1
 * Rev. Author: Jakob Wilson
 * */



using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;
using States;


/**
 * This script is attached to a door to allow the user to interact.
 * It is essencially a state machine that uses classes extending InteractionState
 * It has two modes, constant and on trigger updating.
 * 
 * */
public class Interaction : MonoBehaviour 
{
	public InteractionState startingState;						/**< The starting state for the object(interact button by default*/
	public InteractionState currentState;						/**< the current state of the object*/

	public enum UpdateType{ON_TRIGGER, CONSTANT};				/**< Indicates whether we want state updates every frame, or just when we have a collision*/
	public UpdateType UpdateMode = UpdateType.ON_TRIGGER;


	public delegate void OnTrigEnter(Collider c);				/**event called when a new collider enters*/
	public event OnTrigEnter EnterSignal;


	public delegate void OnTrigExit(Collider c);				/**event called when a collider exits*/
	public event OnTrigExit ExitSignal;
	
	/**
	 * sets current state to the starting state
	 * If the starting state is null, it uses the Interact button state by default
	 * @return void
	 * */
	void Start () 
	{
		//if we have not defined a starting state, then set the default start state to a simple button interaction. 
		if (this.startingState == null) 
			this.startingState = new InteractButtonState (this.gameObject, null);
		this.currentState = this.startingState;
	
	}
	
	/**
	 * Updates the game state if constant updating is enabled
	 * @return void
	 * */
	void Update () 
	{
		//if constante behaviour updating is enabled, the behave
		if (this.UpdateMode == UpdateType.CONSTANT)
			this.currentState = this.currentState.Behave();
	}

	/**
	 * When something collides with the object, set the state's gameobject and fired the enter event
	 * @return void
	 * */
	void OnTriggerEnter(Collider c)
	{
		//tell the state machine who is acting on the object
		this.currentState.actor = c.gameObject;
		if(this.EnterSignal != null)
			EnterSignal (c);
	}

	/**
	 * Updates game state if trigger based updating is enabled
	 * 
	 * @return void
	 * */
	void OnTriggerStay()
	{
		if (this.UpdateMode == UpdateType.ON_TRIGGER)
			this.currentState = this.currentState.Behave();
		
	}

	/**
	 * Fires the exiting signal
	 * @return void
	 * */
	void OnTriggerExit(Collider c)
	{
		if(this.ExitSignal != null)
			ExitSignal (c);
	}
}
