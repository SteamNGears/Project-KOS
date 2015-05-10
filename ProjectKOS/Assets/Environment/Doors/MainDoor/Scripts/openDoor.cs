using UnityEngine;
using System.Collections;

public class openDoor : MonoBehaviour {

	Animator anim;
	//public something[] stuff;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		anim.StopPlayback();
		anim.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Player") {
			anim.enabled = true;
			anim.Play ("OpenDoor");
		}
	}

}
