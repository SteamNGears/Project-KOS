/**
 * Filename: OpeningState
 * Author: Jakob Wilson
 * Created: 5/22/2015
 * Revision: 1
 * Rev. Date: 
 * Rev. Author: 
 * */
using System;
using UnityEngine;
namespace States
{
	/**
	 * A momentary state that simply plays the door opening animation, 
	 * changes the emission color of the main material to green, 
	 * then returns an idle state so no more actions can be done to the door.
	 * */
	public class OpeningState:InteractionState
	{
		private Animator anim;		/**The animator so we cna playback animations*/
		private Renderer rend;		/**The renderer so we can change the color of the frame lights*/

		public OpeningState (GameObject _actee, GameObject _actor):base(_actee, _actor){}


		/**
		 * Changes the emission color of the actee to green, 
		 * then plays the door opening animation
		 * then returns a new idleState
		 * @return InteractionState - the idle state so the door won't close or prompt for interaction
		 * */
		public override InteractionState Behave ()
		{
				this.anim = this.actee.GetComponent<Animator> ();
				this.rend = this.actee.GetComponentInChildren<Renderer>();
				
				// if we have an animator, play the animation
				if(this.anim != null)
					this.anim.Play("OpenDoors");
				
				//if we have the renderer, change the frame light color
				if(this.rend != null)
				{
					rend.material.EnableKeyword ("_EMISSION");
					rend.material.SetColor("_EmissionColor", Color.green);
				}
				
				return new OpenState(this.actee, this.actor);
		}
	}
}

