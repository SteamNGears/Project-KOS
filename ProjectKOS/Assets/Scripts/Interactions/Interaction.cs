using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using AssemblyCSharp;

public class Interaction : MonoBehaviour 
{
	public InteractionState startingState;
	InteractionState currentState = null;


	// Use this for initialization
	void Start () 
	{
		//if we have not defined a starting state, then set the default start state to a simple button interaction. 
		if (this.startingState == null) 
			this.startingState = new InteractTestUI_State (this.gameObject);
		this.currentState = this.startingState;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//nothing for now
	}

	void OnTriggerEnter(Collider c)
	{
		//tell the state machine who is acting on the object
		this.currentState.actor = c.gameObject;
	}

	//If we have a collision, start updating state
	void OnTriggerStay()
	{
		this.currentState = this.currentState.Behave();
	}

	//Reset the state after the user has walked away
	void OnTriggerExit()
	{
		this.currentState.Suspend ();
		this.currentState.actor = null;
	}
}
