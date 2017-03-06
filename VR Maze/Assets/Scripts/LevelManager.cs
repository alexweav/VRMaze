using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu;
    public Transform statMenu;

    private float timer = 2f;//length of gaze required before action is taken
    private float lookTimer = 0f;//length of time the user has looked at an object
    private Renderer myRenderer;
    private BoxCollider myCollider;
    private bool isLookedAt = false;//set if an object is currently being looked at

    /*********************************************************
     variables are set when the corresponding button is pressed 
     **********************************************************/
    private bool startScene = false; //switches scenes
    private bool showStats = false; //switches to statMenu
    private bool goBack = false; //returns to previous menu
    private bool stopGame = false; //ends the application iff not in debug mode

    private string scene = "MainMenu"; //initially set to load itself if no other scene is designated

    private void Start()
    {
        myCollider = GetComponent<BoxCollider>();
        myRenderer = GetComponent<Renderer>();
        myRenderer.material.SetFloat("cutoff", 0f);
    }

    private void Update()
    {
        if(isLookedAt) //iff an item is being looked at by the user
        {
            lookTimer += Time.deltaTime; //get length of look

            myRenderer.material.SetFloat("cutoff", lookTimer / timer);

            if(lookTimer > timer) //if length is at the threshold length
            {
                lookTimer = 0f; //reset the lookTimer
                myCollider.enabled = false;
                /*************************************************************
                 * depending on which action is to be taken, the proper
                 * function will be called
                 * **********************************************************/
                if(startScene == true) //switch scenes
                {
                    LoadScene(scene);
                }
                else if(showStats == true) //show statistics menu
                {
                    StatMenu(true);
                }
                else if(goBack == true) //return to previous menu
                {
                    backButton(true);
                }
                else if(stopGame == true) //end the game
                {
                    QuitGame();
                }
            }

        }
        else //iff user stops gaze before threshold time is reached
        {
            //all variables are reset

            lookTimer = 0f;
            myRenderer.material.SetFloat("cutoff", 0f);
            startScene = false;
            showStats = false;
            goBack = false;
            stopGame = false;
        }
    }

    public void SetGazedAt(bool gazedAt) // called once the user sets their reticle on an interactible object
    {
        isLookedAt = gazedAt;
    }

    /*******************************************************
     * Loads the proper scene into the 
     * ***************************************************/
    public void setScene(string name)
    {
        scene = name;
        startScene = true;
    }

    private void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /*******************************************************
     * Quits the game iff the game is built to a device 
    * ***************************************************/
    public void endScene()
    {
        stopGame = true;
    }
    private void QuitGame()
    {
        Application.Quit();
    }

    /*******************************************************
    * Switches to the statistices menu
    * ***************************************************/
    public void switchMenu()
    {
        showStats = true;
    }
    private void StatMenu(bool clicked)
    {
        if(clicked == true)
        {
            statMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
        else
        {
            statMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(true);
        }
    }

    /*******************************************************
    * returns to the main menu from the current menu 
    * ***************************************************/
    public void backMenu()
    {
        goBack = true;
    }
    private void backButton(bool clicked)
    {
        if (clicked == true)
        {
            mainMenu.gameObject.SetActive(clicked);
            statMenu.gameObject.SetActive(false);
        }
        else
        {
            mainMenu.gameObject.SetActive(clicked);
            statMenu.gameObject.SetActive(true);
        }
    }
}
