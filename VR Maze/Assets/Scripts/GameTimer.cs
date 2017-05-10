using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class GameTimer : MonoBehaviour
{
    public Canvas gameOver;
	// public float MaxGameTime = 300; //equivalent of 5 minutes
	public static float MaxGameTime;
    public Camera player; //camera -- allows timer to match rotation
    public Transform pauseMenu;

    private GameObject person;
    private WalkingScript walkScript;
    private Canvas c; //canvas text is placed on, allows text to rotate with player
    private Text timerText; //text element to display time in maze

    private bool paused = false;
    private bool end = false;
    private float duration = 0; //total time in maze
    private float pauseTime = 0; //time at pause
    private Scene scene;

    // Use this for initialization
    void Start()
    {
        //find start time
        duration = Time.deltaTime;
        person = GameObject.Find("MainPlayer");
        c = gameObject.GetComponentInParent<Canvas>();
        timerText = gameObject.GetComponentInParent<Text>();
        walkScript = person.GetComponent("WalkingScript") as WalkingScript;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        paused = pauseMenu.gameObject.activeSelf;
        if (!end && !paused)
        {
            //find time in maze
            duration += Time.deltaTime;
            //update minutes and seconds
            int minutes = Mathf.FloorToInt(duration / 60F);
            int seconds = Mathf.FloorToInt(duration - minutes * 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if(duration >= MaxGameTime && String.Compare(scene.name, "TimeTrial") == 0)
        {
            gameOver.gameObject.SetActive(true);
            walkScript.stopPlayer();
            walkScript.freezePlayer = true;
            end = true;
        }

        //update canvas rotation
        //float rotation = player.transform.eulerAngles.y - c.transform.eulerAngles.y;
        //c.transform.Rotate( 0, 0, rotation, Space.Self);
    }

    public void pauseTImer(bool pause)
    {
        if(pause)
        {
            pauseTime = duration;
            paused = true;
            walkScript.stopPlayer();
            walkScript.freezePlayer = true;
        }
        else
        {
            duration = pauseTime - Time.deltaTime;
            paused = false;
            walkScript.freezePlayer = false;
        }
    }

    public void reduceTime(float amount)
    {
        if(duration > amount)
        {
            duration -= amount;
        }
        else
        {
            duration = 0;
        }
    }
}
