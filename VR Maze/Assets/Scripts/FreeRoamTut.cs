using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
	public class FreeRoamTut: MonoBehaviour {

		public Text promptText;
		public Image promptBox;

		private string[] msgState = {"Welcome to Free Roam!\nLook around using your VR headset!","Great!\nTo move forward, look down!","To stop, look up towards the sky.\nYou don't need to look all the way up.","Well done!\nNow, find your way out of this maze."};
		private int msgIndex = 0;
		private bool taskCompleted = false;

		void Start(){
			displayPrompt (false);
			StartCoroutine (prompt (3.0f));

		}

		void Update(){
			
			if (taskCompleted) {
				msgIndex++;
				StartCoroutine (prompt (.5f));
				taskCompleted = false;
			}
		}

		public void states(int stateNumber){
			switch(stateNumber){
			case 0:
				taskCompleted = playerLookedAround ();
				break;	
			case 1:
				Debug.Log ("In task '2' now!");
				break;
			}
		}

		public bool playerLookedAround(){
			return true;
		}
			
		/// <summary>
		/// IEnumberator works in conjunction with StartCoroutine()
		/// Creates typewriter effect for displaying dialog.
		/// </summary>
		/// <returns>Edits promptBox</returns>
		IEnumerator prompt(float delay){
			yield return new WaitForSeconds(delay);
			displayPrompt (true);
			for (int i = 0; i < (msgState[msgIndex].Length+1); i++)
			{
				promptText.text = msgState[msgIndex].Substring(0, i);
				yield return new WaitForSeconds(.03f);
			}
			yield return new WaitForSeconds (3.0f);
			displayPrompt (false);
		}

		public void displayPrompt(bool status){
			promptBox.enabled = status;
			promptText.enabled = status;
			disableWalking (status);
		}

		public void disableWalking(bool status){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			walkingController.freezePlayer = status;
		}
	}
}

