using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {


	public Transform target;

	private Rigidbody body;

	private float speed = 0.1f;

	public string xdiff;
	public string ydiff;
	public string zdiff;
	// Use this for initialization
	void Start () {
		this.body = this.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {


		this.xdiff =  this.target.eulerAngles.x + " - " + this.transform.eulerAngles.x + " = " + (this.target.transform.eulerAngles.x - this.gameObject.transform.eulerAngles.x);
		this.ydiff = this.target.eulerAngles.y + " - " + this.transform.eulerAngles.y + " = " + (this.target.transform.eulerAngles.y - this.gameObject.transform.eulerAngles.y);
		this.zdiff = this.target.eulerAngles.z + " - " + this.transform.eulerAngles.z + " = " + (this.target.transform.eulerAngles.z - this.gameObject.transform.eulerAngles.z);

		this.body.angularVelocity = new Vector3(this.speed * (this.target.eulerAngles.x - this.gameObject.transform.eulerAngles.x),
		                                        this.speed * (this.target.eulerAngles.y - this.gameObject.transform.eulerAngles.y),
		                                        this.speed * (this.target.eulerAngles.z - this.gameObject.transform.eulerAngles.z));

		this.transform.position = target.position;

		//this.body.velocity = new Vector3(this.moveSpeed * (this.target.transform.position.x - this.transform.position.x),
		 //                                this.moveSpeed * (this.target.transform.position.y - this.transform.position.y),
		 //                                this.moveSpeed * (this.target.transform.position.z - this.transform.position.z));
	

		
		

	}
}
