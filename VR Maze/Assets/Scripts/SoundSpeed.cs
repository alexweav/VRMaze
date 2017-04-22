using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class SoundSpeed : MonoBehaviour {

    public AudioClip sound;
    AudioSource audio;

    private float walkInterval = 2.5f;
    private float jogInterval = 1.5f;
    private float runInterval = 0.5f;
    
    private WalkingScript speed;
         
    private float time;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {

        time = Time.deltaTime;
        audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        speed = this.GetComponent("WalkingScript") as WalkingScript;
		
	}
	
	// Update is called once per frame
	void Update () {

        bool walk = speed.playerSpeed > 0 && speed.playerSpeed < 2;
        bool jog = speed.playerSpeed >= 2 && speed.playerSpeed < 3.5;
        bool run = speed.playerSpeed >= 3.5;
        bool move = rb.velocity.x > 0 || rb.velocity.z > 0;

        if (run && time >= runInterval && move)
        {
            audio.PlayOneShot(sound, 0.7f);
            time = 0;
        }
        else if(jog && time >= jogInterval && move)
        {
            audio.PlayOneShot(sound, 0.7f);
            time = 0;
        }
        else if (walk && time >= walkInterval && move)
        {
            audio.PlayOneShot(sound, 0.7f);
            time = 0;
        }

        time += Time.deltaTime;
		
	}
}
