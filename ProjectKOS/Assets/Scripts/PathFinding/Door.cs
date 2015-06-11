/**
 * Filename: Door.cs
 * Author: Jakob Wilson
 * Created: 6/5/2015
 * Revision: 
 * Rev. Date: 
 * Rev. Author: Jakob Wilson
 * */

using UnityEngine;
using System.Collections;
using States;


/**
 * This class is a script for doors.
 * It allows the map editor to assign the rooms on either side of the door
 * This data is used by the pathfinding class to do a BFS on the map to ensure the player can actually win
 * 
 * */
public class Door : MonoBehaviour {

	public GameObject RoomOne;		/**The gameobject holding the first room collider*/
	public GameObject RoomTwo;		/**The gameobject holding the second room collider*/

	public Room ZoneOne;//{ get; private set; }	/**The actual room script for room one*/
	public Room ZoneTwo;//{ get; private set; }	/**The actual room script for room two*/

	public enum DoorState{LOCKED, IDLE, OPEN};	/**an enum to represent the state of the door so BFS knows where connections are*/
	public DoorState currentState = DoorState.IDLE;	/** the current door state*/

	private Interaction inter;		/**A reference to the door's interaction script so we can watch it's state and update ours accordingly*/


	/**
	 * Gets the Interaction script from the object and gets the room scripts from the rooms
	 * @return void
	 * */
	void Start () {
		inter = gameObject.GetComponent<Interaction> ();

		this.ZoneOne = RoomOne.GetComponent<Room>();
		this.ZoneTwo = RoomTwo.GetComponent<Room>();


	}
	
	/**
	 * Checks the state of the Interaction script and updates this object's state accordingly
	 * @return void
	 * */
	void Update () {
		if (inter != null) {
			if (inter.currentState is OpenState)
				this.currentState = DoorState.OPEN;
			else if (inter.currentState is LockedState)
				this.currentState = DoorState.LOCKED;
			else 
				this.currentState = DoorState.IDLE;
		}
	}
}
