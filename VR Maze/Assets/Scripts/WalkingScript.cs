using UnityEngine;
using System;

public class WalkingScript : MonoBehaviour {

	public Rigidbody  myRigidBody;
	public Rigidbody playerRigBody;
	public GameObject myHead;
	public GameObject camView;


	private bool isWalking;
	private float speed;
	private float camViewRotX;	//The value of the camera when you look up or doww

	void Start(){

	}

	void Update(){
		camViewRotX = camView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up

		speed = (float) Math.Pow(0.00001, (double)1/camViewRotX); //Formula that increase the speed the more you look down

		//Testing purposes: Alter the speed and downward angle ratio
		//print ("cam: " + camViewRotX);
		//print ("Speed: " + speed);

		if (camViewRotX > 5 && camViewRotX < 90) {
			isWalking = true;
		}
		else{
			isWalking = false;
		}
		
		if (isWalking) {
			myRigidBody.position = transform.position + camView.transform.forward * speed;
			playerRigBody.position = transform.position + camView.transform.forward * speed;
		}
		else{
			myRigidBody.velocity = Vector3.zero;	//Keep both the PlayerModel and Camera still 
			playerRigBody.velocity = Vector3.zero;	// whenever there is no movement.
		}
	}
}