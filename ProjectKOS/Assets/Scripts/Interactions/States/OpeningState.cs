//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;
namespace AssemblyCSharp
{
	public class OpeningState:InteractionState
	{
		private Animator anim;/**The animator so we cna playback animations*/
		private Renderer rend;/**The renderer so we can change the color of the frame lights*/

		public OpeningState (GameObject _actee, GameObject _actor):base(_actee, _actor)
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
		}

		public override InteractionState Behave ()
		{
				return new OpenState(this.actee, this.actor);
		}
	}
}
