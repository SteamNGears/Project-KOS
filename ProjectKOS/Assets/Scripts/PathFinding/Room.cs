/**
 * Filename: Room.cs
 * Author: Jakob Wilson
 * Created: 5/10/2015
 * Revision: 1
 * Rev. Date:
 * Rev. Author: 
 * */

using UnityEngine;
using System.Collections;

/**
 * 	A script to be put on rooms
 * A room should have a collider that is a trigger around the walkable area of the room
 * This script mostly holds metadata about the room like whether or not the player is in that room
 * This class is used heavily by the Pathfinding class to ensure the user can win
 * 
 **/
public class Room : MonoBehaviour {

	public bool PlayerInRoom = false;	/**Whether or not the player is in the room*/
	public bool IsStart = false;		/**Whether or not the room is the starting room for the map*/
	public bool IsEnd = false;			/**Whether or not the room is the ending point for the map*/
	private bool displaying = false;


	/**
	 * if the room is the starting point, then this assumes the player is in the room
	 * */
	void Start () {
		if (IsStart)
			PlayerInRoom = true;
	}
	
	/**
	 * Checks if the room is the end room and the player is in it
	 * if so, then it displays the winning gui
	 * 
	 * */
	void Update () {
		if (this.PlayerInRoom && this.IsEnd && !displaying) {
			GameObject.Instantiate(Resources.Load("GamePlay/SuccessCanvas"));
			displaying = true;

		}
	}

	/**
	 * Updates the room information when the player enters
	 * */
	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
			this.PlayerInRoom = true;
	}

	/**
	 * Updates the room information when the player leaves
	 * */
	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Player")
			this.PlayerInRoom = false;
	}
}
