using UnityEngine;
using System.Collections;
using States;

public class Door : MonoBehaviour {

	public GameObject RoomOne;
	public GameObject RoomTwo;

	public Room ZoneOne{ get; private set; }
	public Room ZoneTwo{ get; private set; }

	public enum DoorState{LOCKED, IDLE, OPEN};
	public DoorState currentState = DoorState.IDLE;

	private Interaction inter;
	// Use this for initialization
	void Start () {
		inter = gameObject.GetComponent<Interaction> ();
		if (inter == null)
			Debug.Log ("Error, could not find door state");

		this.ZoneOne = RoomOne.GetComponent<Room>();
		this.ZoneTwo = RoomTwo.GetComponent<Room>();


	}
	
	// Update is called once per frame
	void Update () {

		if (inter.currentState is OpenState)
			this.currentState = DoorState.OPEN;

		else if (inter.currentState is LockedState)
			this.currentState = DoorState.LOCKED;

		else 
			this.currentState = DoorState.IDLE;
	}
}
