/**
 * Filename: InteractSA_State.cs
 * Author: Chris Hatch
 * Created: 5/15/2015
 * Revision: 1
 * Rev. Date: 5/21/2015
 * Rev. Author: Chris Hatch
 * */

using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Database;
namespace States
{
	public class InteractSA_State:InteractionState
	{
		
		private GameObject _cvsQuestion;
		private accessSACvs _cvsQuestSA;

		private Question _quest;
		
		/**
		 * Sets default values and calls base constructor
		 * */
		public InteractSA_State (GameObject _actee, Question quest, GameObject _actor = null):base(_actee, _actor)
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
					//instantiate SACvs.prefab as GameObject
					this._cvsQuestion = GameObject.Instantiate(Resources.Load ("QCanvas/SACvs") as GameObject);

					//script to access SACvs.prefab
					this._cvsQuestSA = this._cvsQuestion.GetComponentInChildren<accessSACvs> ();

					this._cvsQuestSA.setQuestion (this._quest.QuestionString);
				}
			}
			
			//if the button has been clicked,
			if (this._cvsQuestSA.ansTyped) {
				GameObject.Destroy(this._cvsQuestion);	//clean up the question
				string userAns = this._cvsQuestSA.userAnswer;
				string correctAns;
				foreach(Answer ans in this._quest.Answers)
				{
					if(ans.Correct)
					{
						correctAns = ans.ToString;
					}
				}

				bool correct = correctAns.Equals(userAns, StringComparison.OrdinalIgnoreCase);
				if(correct)
				{
					return new OpeningState (this.actee, this.actor);	//open the door
				}
				else
				{
					return new LockingState (this.actee, this.actor);   //lock the door
				}
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

