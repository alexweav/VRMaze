using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assests.Sciprts
{
	public class HUDTextAnimation : MonoBehaviour {
		
		public Text textBox;

		string message =  "Welcome to VRMaze!";

		int currentlyDisplayingText = 0;


		//This is a function for a button you press to skip to the next text
		public void SkipToNextText(){
			StopAllCoroutines();
			currentlyDisplayingText++;
			//If we've reached the end of the array, do anything you want. I just restart the example text
			if (currentlyDisplayingText>message.Length) {
				currentlyDisplayingText=0;
			}
			StartCoroutine(AnimateText());
		}

		IEnumerator AnimateText(){
			for (int i = 0; i < (message.Length+1); i++)
			{
				textBox.text = message.Substring(0, i);
				yield return new WaitForSeconds(.03f);
			}
		}

		void Awake () {
			StartCoroutine(AnimateText());
		}
	}
}