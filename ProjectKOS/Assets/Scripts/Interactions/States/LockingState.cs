/**
 * Filename: IdleState.cs
 * Author: Jakob Wilson
 * Created: 5/9/2015
 * Revision: 1
 * Rev. Date:
 * Rev. Author: Jakob Wilson
 * */

using System;
using UnityEngine;
namespace States
{
	/**
	 * A state that locks the door(called on question failure)
	 * This code simple changes the emittion color of the door frame to red, 
	 * then transitions to a locked state
	 * */
	public class LockingState:InteractionState
	{
		private Renderer rend;					/**The renderer so we can change the color of the frame lights*/

		/**
		 * Calls base constructor only
		 * */
		public LockingState (GameObject _actee, GameObject _actor):base(_actee, _actor){ }


		/**
		 * Changes the emission color of the actee to red, then returns a new idleState
		 * @return InteractionState - the idle state so the door is locked
		 * */
		public override InteractionState Behave ()
		{
			this.rend = this.actee.GetComponentInChildren<Renderer>();
			
			//if we have the renderer, change the frame light color
			if(this.rend != null)
			{
				rend.material.EnableKeyword ("_EMISSION");
				rend.material.SetColor("_EmissionColor", Color.red);
			}

			return new LockedState(this.actee, this.actor);
		}
	}
}

