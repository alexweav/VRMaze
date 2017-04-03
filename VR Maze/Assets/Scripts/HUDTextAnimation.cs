using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assests.Sciprts
{
	public class HUDTextAnimation : MonoBehaviour {
		
		public Text textBox;
		public Image promptBox;
		private string currentMessage = "Welcome to VRMaze!\n Look around using your VR headset!";
		private bool updatedMessage = false;

		public void setMessage(string msg){
			currentMessage = msg;
			updatedMessage = true;
		}

		public void showPrompt(bool status){
			promptBox.enabled = status;
			textBox.enabled = status;

		}

		/// <summary>
		/// IEnumberator works in conjunction with StartCoroutine()
		/// </summary>
		/// <returns>Edits promptBox</returns>
		IEnumerator showPrompt(){
			showPrompt (true);
			for (int i = 0; i < (currentMessage.Length+1); i++)
			{
				textBox.text = currentMessage.Substring(0, i);
				yield return new WaitForSeconds(.03f);
			}
		}

		IEnumerator delayPrompt(){
			yield return new WaitForSeconds (2.0f);
			StartCoroutine(showPrompt ());
		}
			
		/// <summary>
		/// StartCoroutine() excellent for modelling behaviours over several frames.
		/// </summary>
		void Awake() {
			showPrompt (false);
			StartCoroutine(delayPrompt());

		}

		void Update(){
			if (updatedMessage == true){
				StartCoroutine(showPrompt());
				updatedMessage = false;
			}
		}
	}
}