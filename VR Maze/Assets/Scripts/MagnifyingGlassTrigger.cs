using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlassTrigger : MonoBehaviour {

	public GameObject MagnifyingGlass;

	void OnTriggerEnter(Collider iCollide)
	{
		if (iCollide.transform.name == "MainPlayer") 
		{
			//make map visible
			MagnifyingGlass.SetActive (false);
		}
	}
		
		
}
