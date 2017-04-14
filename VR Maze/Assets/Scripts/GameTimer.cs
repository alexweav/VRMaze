using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float MaxGameTime = 600; //equivalent of 10 minutes
    public Camera player; //camera -- allows timer to match rotation

    private Canvas c; //canvas text is placed on, allows text to rotate with player
    private Text timerText; //text element to display time in maze

    private bool paused = false;
    private float duration = 0; //total time in maze
    private float pauseTime = 0; //time at pause

    // Use this for initialization
    void Start()
    {
        //find start time
        duration = Time.deltaTime;
        c = gameObject.GetComponentInParent<Canvas>();
        timerText = gameObject.GetComponentInParent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!paused)
        {
            //find time in maze
            duration += Time.deltaTime;
            //update minutes and seconds
            int minutes = Mathf.FloorToInt(duration / 60F);
            int seconds = Mathf.FloorToInt(duration - minutes * 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        //update canvas rotation
        float rotation = player.transform.eulerAngles.y - c.transform.eulerAngles.y;
        c.transform.Rotate( 0, 0, rotation, Space.Self);
    }

    public void pauseTImer(bool pause)
    {
        if(pause)
        {
            pauseTime = duration;
            paused = true;
        }
        else
        {
            duration = pauseTime - Time.deltaTime;
            paused = false;
        }
    }
}
