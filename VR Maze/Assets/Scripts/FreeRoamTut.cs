using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class FreeRoamTut: MonoBehaviour{

		private string[] msgState = {"Welcome to Free Roam!\nLook around using your VR headset!","Great!\nTo move forward, look down!","To stop, look up towards the sky.\nYou don't need to look all the way up.","Well done!\nNow, find your way out of this maze."};
		public int msgIndex = 0;

		private GameObject player;

		void Start(){
			player = GameObject.Find ("MainPlayer");
		}

		public void chechState(){
			switch (msgIndex) {
			case 0:
				taskOne();
				break;
			case 1:
				taskTwo();
				break;
			}
		}

		public string getMsg(){
			return msgState [msgIndex];
		}

		public bool taskCompleted(){
			return false;
		}
	
		public void taskOne(){
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			if (walkingController.camViewRotX > 50) {
				
			}
		}

		public void taskTwo(){
			Debug.Log ("In task two");
		}
	}
}

