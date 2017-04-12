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
		public bool showPrompt;
		private float delayPrompt;

		void Start(){
			displayPrompt (false);
			frTasks.allowTasksToBeCompleted = false; //Overrides the call in displayPrompt so player cannot achieve tasks before the list of tasks begin.
			setPrompt (true, frTasks.getMsg(), 3.0f);
			StartCoroutine (prompt ());
		}

		void Update(){
			frTasks.checkState();
			if (frTasks.taskComplete){
				setPrompt (true, frTasks.getMsg (), 0.0f);
				StartCoroutine (prompt ());
			}
		}
			
		public void setPrompt(bool status,string msg, float delay){
			showPrompt = status;
			message = frTasks.getMsg();
			delayPrompt = delay;
		}

		/// <summary>
		/// IEnumberator works in conjunction with StartCoroutine()
		/// Creates typewriter effect for displaying dialog.
		/// </summary>
		/// <returns>Edits promptBox</returns>
		IEnumerator prompt(){
			yield return new WaitForSeconds(delayPrompt);
			displayPrompt (true);
			for (int i = 0; i < (message.Length+1); i++)
			{
				promptText.text = message.Substring(0, i);
				yield return new WaitForSeconds(.03f);
			}
			yield return new WaitForSeconds (4.0f);
			displayPrompt (false);
		}

		public void displayPrompt(bool status){
			promptBox.enabled = status;
			promptText.enabled = status;
			frTasks.allowTasksToBeCompleted = !status;
			disableWalking (status);
		}

		public void disableWalking(bool status){
			GameObject player = GameObject.Find ("MainPlayer");
			WalkingScript walkingController = player.GetComponent<WalkingScript> ();
			walkingController.freezePlayer = status;
		}
	}
}
