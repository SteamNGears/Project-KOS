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
	 * 	A state to represent an idle door. 
	 * All interactions are ifnored and the door just stays there... forever
	 * */
	public class IdleState:InteractionState
	{
		/**
		 * delegates to base constructor
		 * @return void
		 * */
		public IdleState(GameObject _actee, GameObject _actor):base(_actee, _actor)
		{
			//nothing
		}

		/**
		 * Does nothing but return isdelf so no new states can be reached
		 * @return Interactionstate - this object so no new states are reached
		 * */
		public override InteractionState Behave ()
		{
			return this;
		}
	}
}

