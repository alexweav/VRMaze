using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{

    public float MaxGameTime = 600; //equivalent of 10 minutes
    public Text timerText;
    public Transform player;
    private float duration = 0;

    // Use this for initialization
    void Start()
    {
        duration = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {

        duration += Time.deltaTime;

        int minutes = Mathf.FloorToInt(duration / 60F);
        int seconds = Mathf.FloorToInt(duration - minutes * 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
