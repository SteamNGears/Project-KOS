using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour {

	public bool PlayerInRoom = false;
	public bool IsStart = false;
	public bool IsEnd = false;
	private bool displaying = false;
	// Use this for initialization
	void Start () {
		if (IsStart)
			PlayerInRoom = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.PlayerInRoom && this.IsEnd && !displaying) {
			GameObject.Instantiate(Resources.Load("GamePlay/SuccessCanvas"));
			displaying = true;

		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Player")
			this.PlayerInRoom = true;
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Player")
			this.PlayerInRoom = false;
	}
}
