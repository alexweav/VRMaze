using UnityEngine;
using System;

namespace Assests.Scripts
{
	public class WalkingScript : MonoBehaviour {

		public GameObject cameraView;
		public Rigidbody playerRigidbody;
		public CapsuleCollider playerCollider;

		private float camViewRotX;	//The value of the camera when you look up or down

		void Update(){


			camViewRotX = cameraView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up
			Speed speed = new Speed ();

			//TODO: Process below makes unneccary calls, check if the speed has changed rather
			///		constantly check the angle.
			if (camViewRotX > 8 && camViewRotX < 90) {
				speed.speedUp (camViewRotX);

			}
			if (camViewRotX < 345 && camViewRotX > 270) {
				speed.stop ();
			}
			walk (speed.playerSpeed ());
		}

		public void walk(float speed){

			Vector3 cameraDirection = new Vector3 (cameraView.transform.forward.x, 0, cameraView.transform.forward.z).normalized * speed * Time.deltaTime; //2 = speed
			Quaternion cameraRotation = Quaternion.Euler (new Vector3 (0, -transform.rotation.eulerAngles.y, 0));
			transform.Translate (cameraRotation * cameraDirection);
		}

		private bool PlayerSpawnGrounded(){
			var player = GameObject.Find ("MainPlayer");
			var playerHeight = player.GetComponent<Renderer> ().bounds.size.y;
			var playerPosition = playerHeight / 2 + 0.1f;
			var actualPosition = player.transform.position.y;

			if (playerPosition <= actualPosition) {
				return true;
			} else {
				return false; 
			}
		}
	}
}