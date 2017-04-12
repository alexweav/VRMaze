using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float MaxGameTime = 600; //equivalent of 10 minutes
    public Text timerText; //text element to display time in maze
    public Camera player; //camera -- allows timer to match rotation
    public Canvas c; //canvas text is placed on, allows text to rotate with player
    private float duration = 0; //total time in maze

    // Use this for initialization
    void Start()
    {
        //find start time
        duration = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //find time in maze
        duration += Time.deltaTime;
        //update minutes and seconds
        int minutes = Mathf.FloorToInt(duration / 60F);
        int seconds = Mathf.FloorToInt(duration - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        //update canvas rotation
        float rotation = player.transform.eulerAngles.y - c.transform.eulerAngles.y;

        c.transform.Rotate( 0, 0, rotation, Space.Self);
    }
}
