/**
 * Filename: InteractMC_State.cs
 * Author: Chris Hatch
 * Created: 5/15/2015
 * Revision: 2
 * Rev. Date: 6/05/2015
 * Rev. Author: Chris Hatch
 * */

using System;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Database;
namespace States
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

					this._cvsQuestMC.setQuestion (this._quest.QuestionString);   //set question text panel
					this._cvsQuestMC.setAnswers (this._quest.Answers);   //set each answer button
				}
			}
			
			//if the button has been clicked,
			if (this._cvsQuestMC.btnClicked) {
				this._cvsQuestMC.cleanListeners();   //clean up the listeners
				GameObject.Destroy(this._cvsQuestion);	//clean up the question
				string userAns = this._cvsQuestMC.btnSelected.GetComponentInChildren<Text>().text;
				string correctAns = "";
				foreach(Answer ans in this._quest.Answers)
				{
					if(ans.Correct)
					{
						correctAns = ans.ToString ();   //sets answer to check against
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

