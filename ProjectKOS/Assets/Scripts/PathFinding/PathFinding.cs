using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour {

	Door[] Doors;
	Room[] Rooms;

	List<Room> Checked;
	List<Room> UnChecked;

	bool noSolution = false;

	//debug
	int wait = 0;

	// Use this for initialization
	void Start () {
		Doors = GetComponentsInChildren<Door> ();
		Rooms = GetComponentsInChildren<Room> ();
	}
	
	// Update is called once per frame
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
					Debug.Log ("NO SOLUTION");
				}
				else
					Debug.Log ("SOLUTION");
			}
		}
	
	}

	bool ExitIsReachable()
	{
		Checked = new List<Room> ();
		UnChecked = new List<Room> ();

		foreach (Room r in Rooms)
			UnChecked.Add (r);

		Room start = null;

		foreach (Room r in UnChecked)
			if (r.PlayerInRoom || r.IsStart) {
				start = r;
			}

		return DFS (start);
	}

	bool DFS(Room r)
	{

		if (r == null)
			return false;

		if (r.IsEnd)
			return true;

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
