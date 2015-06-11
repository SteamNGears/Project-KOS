/**
 * Filename: PathFinding.cs
 * Author: Jakob Wilson
 * Created: 6/10/2015
 * Revision: 1
 * Rev. Date: 
 * Rev. Author: Jakob Wilson
 * */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
 * A class ensures that there is always a path to the exit
 * If no path is available, then a message is displayed and the user is prompted to exit the game
 * */
public class PathFinding : MonoBehaviour {

	public Door[] Doors;	/**All the doors on the map*/
	public Room[] Rooms;	/**All the rooms on the map*/

	List<Room> Checked;			/**The list of checked rooms for BFS*/
	List<Room> UnChecked;		/**The list of unchecked rooms for BFS*/

	bool noSolution = false;	/**A bool that is true when no solution can be found*/
	
	int wait = 0;	/**An int for delaying solution checks so they don't try to execute every frame*/

	/**
	 * Gets all the Doors and Rooms
	 * */
	void Start () {
		Doors = GetComponentsInChildren<Door> ();
		Rooms = GetComponentsInChildren<Room> ();
	}
	
	/**
	 * If we have not determined that there is no solution already, 
	 * then we increment wait and check for a 1/100 chance
	 * if the chance, then do a BFS to check if the map can be solved
	 * 	if so, do nothing
	 * 	if not, diaply failure gui
	 * */
	void Update () {
		if(noSolution == false)
		{
			wait++;
			wait = wait % 100;
			if (wait == 0) {
				if (!ExitIsReachable ())
				{
					GameObject.Instantiate(Resources.Load("GamePlay/FailureCanvas"));
					noSolution = true;
				}
			}
		}
	
	}

	/**
	 * A function that inits the BFS 
	 * @return bool - whether or not the exit can be reached
	 * */
	public bool ExitIsReachable()
	{
		Checked = new List<Room> ();
		UnChecked = new List<Room> ();

		foreach (Room r in Rooms)
			UnChecked.Add (r);

		Room start = null;

		foreach (Room r in UnChecked)
			if (r.PlayerInRoom || r.IsStart) {
				start = r;
				//Debug.Log("found start!");
			}

		return DFS (start);
	}

	/**
	 * A recursive DFS method that checks a single room
	 * then all adjacent rooms recursively
	 * @return bool - whether or not a suitable path was found in the given subset of rooms
	 * */
	bool DFS(Room r)
	{

		if (r == null)
			return false;

		if (r.IsEnd) {
			return true;
			Debug.Log("Found end!");
		}


		Checked.Add (r);
		UnChecked.Remove (r);

		foreach (Door d in Doors) {
			//if it is an adacent door and not locked
			if(d.ZoneOne == r && d.currentState != Door.DoorState.LOCKED && !Checked.Contains(d.ZoneTwo))
			{
				if(DFS(d.ZoneTwo))
					return true;
			}
			else if(d.ZoneTwo == r && d.currentState != Door.DoorState.LOCKED && !Checked.Contains(d.ZoneOne))
			{
				if(DFS(d.ZoneOne))
					return true;
			}
		}

		return false;
			
	}
}
