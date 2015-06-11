/**
 * Filename: InteractionState.cs
 * Author: Jakob Wilson
 * Created: 5/10/2015
 * Revision: 1
 * Rev. Date:
 * Rev. Author: Jakob Wilson
 * */

using System;
using UnityEngine;
namespace States
{
	/**
	 * A base interaction state for all interactions such as gui displays
	 * @author Jakob Wilson
	 * */
	public abstract class InteractionState
	{
		public GameObject actee; 	/**The completing the action*/
		public GameObject actor;	/**The gameobject triggering the interaction*/

		/**
		 * The constructor is called with one required param: the actee which is the object being acted upon
		 * It also has oe optional param called actor which is the object acting upon the state machine
		 * Actor can also be changed on the fly to allow for more dynamic behaviour
		 * @param GameObject _actee - the gameobject that is is being interacted with
		 * @param GameObject _actor - the GameObject that is interacting with the _actee
		 * */
		public InteractionState (GameObject _actee, GameObject _actor = null)
		{
			this.actee = _actee;
			this.actor = _actor;	
		}

		/**
		 * The generic bahaviour of the InteractionState
		 * @return InteractionState - the next state we want to move to (could be this)
		 * */
		public abstract InteractionState Behave();

		/**
		 * A method for suspending the state 
		 * Useful for doing any kind of cleanup
		 * @return void
		 * */
		public virtual void Suspend(Collider c = null)
		{
			//do nothing
		}
	}
}

