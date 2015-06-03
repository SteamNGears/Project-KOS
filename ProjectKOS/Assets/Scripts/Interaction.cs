using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using States;
using AssemblyCSharp;

public class Interaction : MonoBehaviour 
{
	public InteractionState startingState;/**< The starting state for the object(interact button by default*/
	public InteractionState currentState{ get; private set; }/**< the current state of the object*/

	public enum UpdateType{ON_TRIGGER, CONSTANT};/**< Indicates whether we want state updates every frame, or just when we have a collision*/
	public UpdateType UpdateMode = UpdateType.ON_TRIGGER;

	/**event called when a new collider enters*/
	public delegate void OnTrigEnter(Collider c);
	public event OnTrigEnter EnterSignal;

	/**event called when a collider exits*/
	public delegate void OnTrigExit(Collider c);
	public event OnTrigExit ExitSignal;
	
	/**
	 * sets current state to the starting state
	 * If the starting state is null, it uses the Interact button state by default
	 * */
	void Start () 
	{
		//if we have not defined a starting state, then set the default start state to a simple button interaction. 
		if (this.startingState == null) 
			this.startingState = new InteractButtonState(this.gameObject, null);
		//this.startingState = new InteractSA_State (this.gameObject, new Database.TrueFalseQuestion("MATH", 1, "What is pi?", "zero"), null);
		this.currentState = this.startingState;


		// set up events for the object so states can listed for events
	}
	
	/**
	 * Updates the game state if constant updating is enabled
	 * */
	void Update () 
	{
		//if constante behaviour updating is enabled, the behave
		if (this.UpdateMode == UpdateType.CONSTANT)
			this.currentState = this.currentState.Behave();
	}

	/**
	 * When something collides with the object, set the state's gameobject and fired the enter event
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
	 * */
	void OnTriggerStay()
	{
		if (this.UpdateMode == UpdateType.ON_TRIGGER)
			this.currentState = this.currentState.Behave();
		
	}

	/**
	 * Fired the exiting signal
	 * */
	void OnTriggerExit(Collider c)
	{
		if(this.ExitSignal != null)
			ExitSignal (c);
	}
}
