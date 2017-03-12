using UnityEngine;
using System;

namespace Assets.Scripts
{
	public class Speed {
		
		private float currentSpeed;

		public void testPrint(){
			Debug.Log ("CurrentSpeed: " + currentSpeed);
		}

		public Speed(){
			currentSpeed = 0;

		}

		public float getCurrentSpeed(){
			return currentSpeed;
		}

		public void stop(){
			currentSpeed = 0;
		}

		public void slowDown(){

		}

		public void speedUp(float value){
			currentSpeed = value;
		}

	}
}