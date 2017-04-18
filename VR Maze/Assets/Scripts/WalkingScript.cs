using UnityEngine;
using System;

namespace Assets.Scripts
{
	public class WalkingScript : MonoBehaviour {

		public GameObject cameraView;
		public Rigidbody playerRigidbody;
		public CapsuleCollider playerCollider;
		public bool freezePlayer = false;

		public float camViewRotX;	//The value of the camera when you look up or down
		public float camViewRotY;	//Value of camera when look left or right. Mainly for tasks in tutorial mode.
		public float playerSpeed;

		Speed speed = new Speed ();

        

        void Update(){
			if (!freezePlayer) {
				camViewRotX = cameraView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up
				camViewRotY = cameraView.transform.eulerAngles.y; 
				playerSpeed = (float)Math.Pow (camViewRotX, 2) / 540;

				if (playerSpeed > 0 && playerSpeed < 15) {
					if (playerSpeed > speed.getCurrentSpeed ()) {
						increaseSpeed (playerSpeed);
					}
				} else if (camViewRotX > 270 && camViewRotX < 350) {
					stopPlayer ();
				}
				walk (currentSpeed());
			} else {
				stopPlayer ();	
			}

            Vector3 INTIconPOS = GameObject.Find("Icon").transform.position;
            
            Vector3 MainPlayerPOS = playerCollider.transform.position;
            GameObject.Find("Icon").transform.position = new Vector3(MainPlayerPOS.x / 10 + INTIconPOS.x, 20.001f, MainPlayerPOS.z / 10 + INTIconPOS.z);

            GameObject.Find("HUDMiniMap").transform.FindChild("Icon").transform.rotation =Quaternion.Euler(0, GameObject.Find("MainPlayer").transform.FindChild("GvrMain").transform.FindChild("Head").rotation.eulerAngles.y + 143.25f,0);

    	}

		public float currentSpeed(){
			return speed.getCurrentSpeed ();
		}

		public void increaseSpeed(float speedValue){
			speed.speedUp (speedValue);
		}
		public void stopPlayer(){
			speed.stop ();
		}

	    public void walk(float speed){
				Vector3 cameraDirection = new Vector3 (cameraView.transform.forward.x, 0, cameraView.transform.forward.z).normalized * speed * Time.deltaTime; //2 = speed
				Quaternion cameraRotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
				transform.Translate (cameraRotation * cameraDirection);
		}
	}
}