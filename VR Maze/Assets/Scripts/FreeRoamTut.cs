using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class FreeRoamTut: MonoBehaviour{

		private string[] msgState = {"Welcome to Free Roam!\nLook around using your VR headset!",
									 "Great!\n Now to move forward, look down.",
									 "To stop, look up towards the sky.\nNotice, you don't need to look all\n the way up to stop.",
									 "Well done!\nNow, find your way out of this maze!\nGood Luck!"};
		private int msgIndex = 1;
		public bool taskComplete = false;
		public bool allowTasksToBeCompleted = false;

		Stopwatch s = new Stopwatch ();


		public void checkState(){
			if (allowTasksToBeCompleted) {
				taskComplete = false;
				switch (msgIndex) {
				case 0:
					taskOne ();
					break;
				case 1:
					taskTwo ();
					break;
				}
			}
		}

		public string getMsg(){
			return msgState [msgIndex];
		}

		public void taskCompleted(){
			taskComplete = true;
			msgIndex++;
		}
		/// <summary>
		/// Task One: Player look left or right, directly behind them.
		/// </summary>
		public void taskOne(){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			if (walkingController.camViewRotY > 240 && walkingController.camViewRotY < 300) {
				taskCompleted ();
			}
		}
		/// <summary>
		/// Task Two: Player walkings forward by looking down for 4 seconds.
		/// </summary>
		public void taskTwo(){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			if (walkingController.currentSpeed() > 0) {
				s.Start ();
				print (s.ElapsedMilliseconds);
				if (s.ElapsedMilliseconds > 1000) {
					taskCompleted ();
				}
			}
			s.Stop ();
		}
		/// <summary>
		/// Tasks Four: Player stops movement by looking up.
		/// </summary>
		public void taskThree(){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			if (walkingController.currentSpeed() == 0) {
				taskCompleted ();
			}
		}
		/// <summary>
		/// Task Five: Player completed the maze.
		/// </summary>
		public void taskFour(){
			
		}
	}
}
