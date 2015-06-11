/**
 * Filename: IdleState.cs
 * Author: Jakob Wilson
 * Created: 6/9/2015
 * Revision: 1
 * Rev. Date:
 * Rev. Author: Jakob Wilson
 * */

using System;
using UnityEngine;
namespace States
{
	/**
	 * This class represents a locked state. It is the same as the Idle statem but 
	 * since it is unique from openstate, it can be used by the pathfinding code to determine valid paths
	 * */
	public class LockedState:InteractionState
	{
		/**
		 * Does nothing but calls base constructor
		 * */
		public LockedState(GameObject _actee, GameObject _actor):base(_actee, _actor)
		{
			//nothing
		}


		/**
		 * Simply returns itself to ensure no other states are reached
		 * @return InteractionState - this state so no other states can be reached
		 * */
		public override InteractionState Behave ()
		{
			return this;
		}
	}
}
