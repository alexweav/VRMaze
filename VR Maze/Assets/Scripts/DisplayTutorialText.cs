using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTutorialText : MonoBehaviour {

	public string text=" Hello World";
	bool display = true;
	public GameObject cubeObject;

	void OnTriggerEnter(Collider iCollide)
	{
		if (iCollide.transform.name == "MainPlayer") 
		{
			cubeObject.SetActive (true);
			display = true; 

		}
	}

	void OnTriggerExit(Collider uCollide)
	{
		if (uCollide.transform.name == "MainPlayer") 
		{
			cubeObject.SetActive (false);
			display = false;

		}
	}

	void OnGUI()
	{
		if (display == true) 
		{
			//GUI.Box (new Rect (0, 0, Screen.width, Screen.height), text);

		}
	}
}
