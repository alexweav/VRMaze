using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class WalkingSound : MonoBehaviour {

    public AudioClip step;

    private AudioSource audio;
    private GameObject player;
    private WalkingScript walkScript;

    private float walk = 0.5f;
    private float jog = 3f;
    private float run = 6.5f;

    private float time;

	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
        player = GameObject.Find("MainPlayer");
        walkScript = player.GetComponent("WalkingScript") as WalkingScript;
        time = Time.deltaTime;

    }
	
	// Update is called once per frame
	void Update () {

       float playerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;
        time += Time.deltaTime; 

       if (playerSpeed > 0)
        {
            float currentSpeed = walkScript.currentSpeed();
            //Debug.Log("speed " + currentSpeed);

            if ( currentSpeed >= walk &&  time >= 1.5)
            {
                audio.PlayOneShot(step, 1.5f);
                time = 0f;
            }
            else if (currentSpeed >= jog && time >= 1)
            {
                audio.PlayOneShot(step, 1.5f);
                time = 0f;
            }
            else if (currentSpeed >= run && time >= 0.25)
            {
                audio.PlayOneShot(step, 1.5f);
                time = 0f;
            }
        }

	}
}
