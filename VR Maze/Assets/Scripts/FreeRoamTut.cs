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

		private string[] msgState = {"Welcome to Free Roan!\nLook around using your VR headset!","Great!\nTo move forward, look down!","To stop, look up towards the sky.\nYou don't need to look all the way up.","Well done!\nNow, find your way out of this maze."};
		private int msgIndex = 0;
		private bool taskCompeleted = false;

		void Start(){
			displayPrompt (false);
			StartCoroutine (prompt (3.0f));
		}

		void Update(){
			
			if (taskCompeleted) {
				msgIndex++;	
			}
		}
			
		/// <summary>
		/// IEnumberator works in conjunction with StartCoroutine()
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
		}

		public void displayPrompt(bool status){
			promptBox.enabled = status;
			promptText.enabled = status;
			//disableWalking (status);
		}

		public void disableWalking(bool status){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			walkingController.freezePlayer = status;
		}
	}
}

