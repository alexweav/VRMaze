using UnityEngine;
using System;

namespace Assests.Scripts
{
	public class Speed {
		public float currentSpeed;
		public float tempSpeed;
		public float speedCheck;

		public void testPrint(){
			Debug.Log ("CurrentSpeed: " + currentSpeed);
		}

		public Speed(){
			currentSpeed = 0;

		}

		public float playerSpeed(float value){
			currentSpeed = value;
			return currentSpeed;
		}

		public float playerSpeed(){
			return currentSpeed;
		}

		public void stop(){
			currentSpeed = 0;
		}

		public void slowDown(){

		}

		public void speedUp(float angle){
			currentSpeed = (float)Math.Pow (angle, 2) / 540;
			if (currentSpeed >= tempSpeed) {
				if (currentSpeed < 5) {
					currentSpeed = 5;
				}
				tempSpeed = currentSpeed;
			} else {
				currentSpeed = tempSpeed;
			}
		}

	}
}