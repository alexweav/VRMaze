﻿using UnityEngine;
using System;

namespace Assets.Scripts
{
	public class Speed{
		
		private float currentSpeed;
		private float sneak = 1.5f;
		private float walk = 4.6f;
		private float sprint = 8.5f;

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
			if (value >= sprint) {
				currentSpeed = sprint;
			} 
			else if (value >= walk) {
				currentSpeed = walk;
			} 
			else if (value >= sneak) {
				currentSpeed = sneak;
			}
		}
	}
}