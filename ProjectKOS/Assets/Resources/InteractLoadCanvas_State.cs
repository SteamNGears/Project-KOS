/**
 * Filename: InteractLoadCanvas_State.cs
 * Author: Chris Hatch
 * Created: 5/29/2015
 * Revision: 0
 * Rev. Date: 5/29/2015
 * Rev. Author: Chris Hatch
 * */

using System;
using UnityEngine;
using UnityEngine.UI;
namespace AssemblyCSharp
{
	public class InteractLoadCanvas_State : InteractionState
	{
		public InteractLoadCanvas_State (GameObject actee, GameObject actor = null) : base(actee, actor)
		{
		}
		
		public override InteractionState Behave()
		{
			return this;
		}
	}
}

