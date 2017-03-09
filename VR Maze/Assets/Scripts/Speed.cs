using UnityEngine;
using System;

namespace Assests.Scripts
{
	public class Speed
	{
		private float speedCheck;
		private float currentSpeed;
		private float tempSpeed;

		public void testPrint(){
			Debug.Log (currentSpeed);
		}

		public Speed(){
			currentSpeed = 0;
			tempSpeed = 0;
		}

		public float playerSpeed(){
			return currentSpeed;
		}

		public void stop(){
			tempSpeed = 0;
			currentSpeed = 0;
		}

		public void slowDown(){

		}

		public void speedUp(float angle){
			tempSpeed = (float)Math.Pow (angle, 2) / 540;
			if (tempSpeed > currentSpeed) {
				speedCheck = tempSpeed;
				if (speedCheck < 5) {
					currentSpeed = 5;
				}
			}
	
//			if (speedCheck >= tempSpeed) {
//				if (speedCheck < 5) {
//					currentSpeed = 5;
//				}
//				tempSpeed = speedCheck;
//				currentSpeed = tempSpeed;
//			} else {
//				currentSpeed = tempSpeed;
//			}
		}
	}
}

