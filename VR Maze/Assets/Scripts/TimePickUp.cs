using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;
using UnityEngine.UI;

public class TimePickUp : MonoBehaviour {

    private GameObject timerCanvas;
    private GameObject timerText;
    private GameTimer timer;

    public AudioClip clock_tick;

	// Use this for initialization
	void Start () {
        timerCanvas = GameObject.Find("MainPlayer").transform.FindChild("GvrMain").transform.FindChild("Head").transform.FindChild("Main Camera").transform.FindChild("TimerCanvas").gameObject;
        timerText = timerCanvas.transform.FindChild("Timer").gameObject;
        timer = timerText.GetComponent("GameTimer") as GameTimer;

       // Debug.Log(GetComponent<AudioSource>().clip);
    }

    private void OnCollisionEnter(Collision collision)
    {
        timer.reduceTime(10f);
        this.GetComponent<AudioSource>().clip = clock_tick;
        this.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<Renderer>().enabled = false;
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, - 10);
        Destroy(gameObject, 2 * clock_tick.length + 2);
    }
}
