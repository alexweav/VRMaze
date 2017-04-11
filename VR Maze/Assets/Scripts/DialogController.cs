using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
namespace Assets.Scripts
{
	public class DialogController: MonoBehaviour{
		
		public Text promptText;
		public Image promptBox;

		FreeRoamTut frTasks = new FreeRoamTut ();

		private string message;

		void Start(){
			displayPrompt (false);
			setMsg ();
			StartCoroutine (prompt (3.0f));
		}

		void setMsg(){
			message = frTasks.getMsg ();
		}

		/// <summary>
		/// IEnumberator works in conjunction with StartCoroutine()
		/// Creates typewriter effect for displaying dialog.
		/// </summary>
		/// <returns>Edits promptBox</returns>
		IEnumerator prompt(float delay){
			yield return new WaitForSeconds(delay);
			displayPrompt (true);
			for (int i = 0; i < (message.Length+1); i++)
			{
				promptText.text = message.Substring(0, i);
				yield return new WaitForSeconds(.03f);
			}
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

