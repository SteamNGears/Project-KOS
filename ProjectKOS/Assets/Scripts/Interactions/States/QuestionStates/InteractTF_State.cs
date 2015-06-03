/**
 * Filename: InteractTF_State.cs
 * Author: Chris Hatch
 * Created: 5/15/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Chris Hatch
 * */

using System;
using UnityEngine;
//using UnityEditor;
using UnityEngine.UI;
using Database;
namespace States
{
	public class InteractTF_State:InteractionState
	{
		
		private GameObject _cvsQuestion;
		private accessTFCvs _cvsQuestTF;
		private Question _quest;
		/**
		 * Sets default values and calls base constructor
		 * */
		public InteractTF_State (GameObject _actee, Question quest, GameObject _actor = null):base(_actee, _actor)
		{
			this._quest = quest;
		}
		
		/**
		 * Displays a GUI with an interact button, 
		 * if the button is clicked, then the state is transitioned to an Opening State(See OpeningState.cs)
		 * 
		 * */
		public override InteractionState Behave ()
		{
			//if the gui doesn't exist, create it
			if (_cvsQuestion == null && this.actor != null) 
			{
				if(this.actor.tag == "Player")
				{
					//instantiate TFCvs.prefab as GameObject
					this._cvsQuestion = GameObject.Instantiate(Resources.Load ("QCanvas/TFCvs") as GameObject);

					this._cvsQuestTF = this._cvsQuestion.GetComponentInChildren<accessTFCvs> ();

					this._cvsQuestTF.setQuestion (this._quest.QuestionString);
				}
			}
			
			//if the button has been clicked,
			if (this._cvsQuestTF.ansSelected) {
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
			//Debug.Log("Cleared event");
			GameObject.Destroy (this._cvsQuestion);
		}

	}
}

