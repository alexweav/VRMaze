using UnityEngine;
using System;

public class WalkingScript : MonoBehaviour {

	public GameObject cameraView;
	public Rigidbody playerRigidbody;
	public CapsuleCollider playerCollider;


	private bool isWalking;
	private float speed;
	private float camViewRotX;	//The value of the camera when you look up or doww

	void Update(){

		camViewRotX = cameraView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up



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
			
			Vector3 cameraDirection = new Vector3 (cameraView.transform.forward.x, 0, cameraView.transform.forward.z).normalized * 2 * Time.deltaTime; //2 = speed
			Quaternion cameraRotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (cameraRotation * cameraDirection);

		}
		else{
			
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "wall") {

			print ("Hit a dang wall!");
		}
	}
}