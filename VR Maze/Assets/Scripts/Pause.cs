﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts
{
public class Pause : MonoBehaviour {

	public GameObject menuObject;
	public GameObject player;

	
	// How long to look at Menu Item before taking action
	public float timerDuration = 2f;

	// This value will count down from the duration
	private float lookTimer = 0f;

	// My renderer so I can set _Cutoff value
	private Renderer myRenderer;

	// Box Collider
	private BoxCollider myCollider;

	// Is player looking at me?
	private bool isLookedAt = false;

	// MonoBehaviour Start
	void Start() {
		// My Collider
		myCollider = GetComponent<BoxCollider>();
		// Get my Renderer
		myRenderer = GetComponent<Renderer>();
		// Set cutoff
		myRenderer.material.SetFloat("_Cutoff", 0f);
	}

	// MonoBehaviour Update
	void Update() {
		// While player is looking at me
		if (isLookedAt) {
			// Reduce Timer
			lookTimer += Time.deltaTime;

			// Set cutoff value on material to value between 0 and 1
			myRenderer.material.SetFloat("_Cutoff", lookTimer / timerDuration);

			if (lookTimer > timerDuration) {
				// Reset timer
				lookTimer = 0f;

				// Do something
				Debug.Log("BUTTON HAS BEEN SELECTED!");
				menuObject.SetActive (true);
				//rotation RotationController = menuObject.GetComponent<rotation> (); 
				//RotationController.enabled = false;
				WalkingScript WalkingController = player.GetComponent<WalkingScript> ();
				WalkingController.enabled = false;
				menuObject.transform.parent = null;
				

			}     
		}  else {
			// Reset Timer
			lookTimer = 0f;
			// Reset Cutoff
			myRenderer.material.SetFloat("_Cutoff", 0f);
		}
	}

	// Google Cardboard Gaze
	public void SetGazedAt(bool gazedAt) {
		// Set the local bool to the one passed from Event Trigger
		isLookedAt = gazedAt;
	}
}
}