using UnityEngine;
using System;

public class WalkingScript : MonoBehaviour {

	public GameObject cameraView;
	public Rigidbody playerRigidbody;
	public CapsuleCollider playerCollider;

	private float currentSpeed = 0;
	private float tempSpeed = 0;
	private float camViewRotX;	//The value of the camera when you look up or doww

	void Update(){

		camViewRotX = cameraView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up


		if (camViewRotX > 8 && camViewRotX < 90) {
			speedUp (camViewRotX);

		}
		if (camViewRotX < 345 && camViewRotX > 270){
			slowDown ();
		}
		walk (currentSpeed);
	}

	public void walk(float speed){

		Vector3 cameraDirection = new Vector3 (cameraView.transform.forward.x, 0, cameraView.transform.forward.z).normalized * speed * Time.deltaTime; //2 = speed
		Quaternion cameraRotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
		transform.Translate (cameraRotation * cameraDirection);
	}

	public void speedControl(){
		
	}
	public void speedUp(float angle){
		currentSpeed = (float)Math.Pow (camViewRotX, 2) / 540;
		if (currentSpeed >= tempSpeed) {
			if (currentSpeed < 5) {
				currentSpeed = 5;
			}
			tempSpeed = currentSpeed;
		} else {
			currentSpeed = tempSpeed;
		}
	}
	public void slowDown(){
		tempSpeed = 0;
		currentSpeed = 0;
	}
}