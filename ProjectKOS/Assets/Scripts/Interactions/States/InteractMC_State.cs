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
using Database;
namespace AssemblyCSharp
{
	public class InteractMC_State:InteractionState
	{
		
		private GameObject _cvsQuestion;
		private accessMCCvs _cvsQuestMC;
		private Question _quest;
		/**
		 * Sets default values and calls base constructor
		 * */
		public InteractMC_State (GameObject _actee, Question quest, GameObject _actor = null):base(_actee, _actor)
		{
			this._quest = quest;
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

					this._cvsQuestMC.setQuestion (this._quest.QuestionString);
					this._cvsQuestMC.setAnswers (this._quest.Answers);
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

