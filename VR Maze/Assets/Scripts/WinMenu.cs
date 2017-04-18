using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public Transform winMenu;
    public Transform loading;
    public Canvas c;
    public Camera player;

    public float timer = 3f;//length of gaze required before action is taken
    private float lookTimer = 0f;//length of time the user has looked at an object
    private Renderer myRenderer;
    private BoxCollider myCollider;
    private bool isLookedAt = false;//set if an object is currently being looked at

    /*********************************************************
     variables are set when the corresponding button is pressed 
     **********************************************************/
    private bool playAgain = false; //restarts the scene
    private bool mainMenu = false; //switches to MainMenu

    private void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.SetFloat("cutoff", 0f);
    }
    /****************************************************************************************************
     * Update()
     * 
     * This function checks continuously to determine if the user is looking at any interactive object
     * on the screen, if the use looks at any one interactive item for at least the length required by 
     * timer then an action is taken based on the object being looked at.
     ***************************************************************************************************/
    private void Update()
    {

        if (isLookedAt) //iff an item is being looked at by the user
        {
            lookTimer += Time.deltaTime; //get length of look

            myRenderer.material.SetFloat("cutoff", lookTimer / timer);

            if (lookTimer > timer) //if length is at the threshold length
            {
                //Debug.Log("Time "+lookTimer);
                //lookTimer = 0f; //reset the lookTimer
                myCollider.enabled = false;
                /*************************************************************
                 * depending on which action is to be taken, the proper
                 * function will be called
                 * **********************************************************/
                if (mainMenu == true) //switch scenes
                {
                    //Debug.Log("load "+scene);
                    loading.gameObject.SetActive(true);
                    winMenu.gameObject.SetActive(false);
                    SceneManager.LoadScene("MainMenu");
                }
                else if (playAgain == true) //switch to options menu
                {
                    //Debug.Log("options");
                    loading.gameObject.SetActive(true);
                    winMenu.gameObject.SetActive(false);
                    SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                    int index = SceneManager.GetActiveScene().buildIndex;
                    SceneManager.LoadScene(index);
                }

                resetVars();
            }

        }
        else //iff user stops gaze before threshold time is reached
        {
            // Debug.Log("Stop gaze");
            resetVars();
        }

        float rotation = player.transform.eulerAngles.y - c.transform.eulerAngles.y;
        c.transform.Rotate(0, rotation, 0, Space.Self);

    }

    public void StartGaze() // called once the user sets their reticle on an interactible object
    {
        isLookedAt = true;
    }

    public void StopGaze()
    {
        isLookedAt = false;
    }

    private void resetVars()
    {
        // Debug.Log("reset");
        lookTimer = 0f;
        myRenderer.material.SetFloat("cutoff", 0f);
        playAgain = false;
        mainMenu = false;
        myCollider.enabled = false;
    }

    public void PlayAgain(bool pick)
    {
        // Debug.Log("show opt");
        playAgain = pick;
    }

    public void MainMenu(bool pick)
    {
        // Debug.Log("new scene");
        mainMenu = pick;
    }

}

