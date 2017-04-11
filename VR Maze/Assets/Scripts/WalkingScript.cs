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
		public float playerSpeed;

		Speed speed = new Speed ();

        private Vector3 INTIconPOS = GameObject.Find("Icon").transform.position;

        void Update(){
			if (!freezePlayer) {
				camViewRotX = cameraView.transform.eulerAngles.x; //Angel of the camer >0 is looking down <0 looking up
				playerSpeed = (float)Math.Pow (camViewRotX, 2) / 540;

				if (playerSpeed > 0 && playerSpeed < 15) {
					if (playerSpeed > speed.getCurrentSpeed ()) {
						speed.speedUp (playerSpeed);
					}
				} else if (camViewRotX > 270 && camViewRotX < 350) {
					speed.stop ();
				}
				walk (speed.getCurrentSpeed ());
			} else {
				speed.stop ();	
			}
             
            Vector3 MainPlayerPOS = playerCollider.transform.position;
            //GameObject.Find("Icon").transform.position = new Vector3(MainPlayerPOS.x / 10 + INTIconPOS.x, 20.001f, MainPlayerPOS.z / 10 + INTIconPOS.z);

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