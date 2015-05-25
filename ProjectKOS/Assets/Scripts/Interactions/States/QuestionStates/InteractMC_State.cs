/**
 * Filename: InteractMC_State.cs
 * Author: Chris Hatch
 * Created: 5/15/2015
 * Revision: 1
 * Rev. Date: 5/22/2015
 * Rev. Author: Chris Hatch
 * */

using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace States
{
	public class InteractMC_State:InteractionState
	{
		
		private GameObject _cvsQuestion;
		private accessMCCvs _cvsQuestMC;
		
		/**
		 * Sets default values and calls base constructor
		 * */
		public InteractMC_State (GameObject _actee, GameObject _actor = null):base(_actee, _actor)
		{

		}
		
		/**
		 * 
		 * */
		public override InteractionState Behave ()
		{
			//if the gui doesn't exist, create it
			if (_cvsQuestion == null && this.actor != null) 
			{
				if(this.actor.tag == "Player")
				{
					this._cvsQuestion = GameObject.Instantiate(Resources.Load ("QCanvas/MCCvs") as GameObject);

					this._cvsQuestMC = this._cvsQuestion.GetComponentInChildren<accessMCCvs> ();

					string quest = "Is Unity is AMAZING?";
					string[] ans = {"Everything","Something","Nothing","Particle Physics"};

					this._cvsQuestMC.setQuestion (quest);
					this._cvsQuestMC.setAnswers (ans);
				}
			}
			
			//if the button has been clicked,
			if (this._cvsQuestMC.btnClicked) {
				this._cvsQuestMC.cleanListeners();
				GameObject.Destroy(this._cvsQuestion);	//clean up the question 
				return new OpeningState (this.actee, this.actor);	//open the door
			}
			else
				return this;//continue incurrent state
			
		}
		
		/**
		 * 
		 * */
		public override void Suspend(Collider c = null)
		{
			Debug.Log("Cleared event");
			GameObject.Destroy (this._cvsQuestion);
		}

	}
}

