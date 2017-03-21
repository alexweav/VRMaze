using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu;
    public Transform statMenu;
    public Transform optionMenu;

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
    private bool showOptions = false; //switches to game options menu

    private string scene = "MainMenu"; //initially set to load itself if no other scene is designated

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
                else if(showOptions == true) //switch to options menu
                {
                    optMenu(true);
                }
                else if(showStats == true) //show statistics menu
                {
                    StatMenu(true);
                }
                else if(goBack == true) //return to previous menu
                {
                    if (statMenu.gameObject.activeSelf)
                        backStat(true);
                    else if (optionMenu.gameObject.activeSelf)
                        backOpt(true);
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
            showOptions = false;
        }
    }

    public void SetGazedAt(bool gazedAt) // called once the user sets their reticle on an interactible object
    {
        isLookedAt = gazedAt;
    }

/************************************************************************************************************
 * optionsMenu()
 * optMenu()
 * setScene()
 * LoadScene()
 * 
 * These functions set up and control the buttons on the options menu.
 * This menu displays the different game options that are available to the user for play. At this time these
 * game options include DEMO, and FREEROAM
 ***********************************************************************************************************/
    public void optionsMenu()
    {
        showOptions = true;
    }

    private void optMenu(bool clicked)
    {
        if (clicked == true)
        {
            startScene = false;
            showStats = false;
            goBack = false;
            stopGame = false;
            showOptions = false;

            optionMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
    }

    /*******************************************************
     * setScene()
     * LoadScene()
     * 
     * These functions load the scene from a string that is
     * passed to it. 
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

    private void backOpt(bool clicked)
    {
        if (clicked == true)
        {
            startScene = false;
            showStats = false;
            goBack = false;
            stopGame = false;
            showOptions = false;

            mainMenu.gameObject.SetActive(clicked);
            optionMenu.gameObject.SetActive(false);
        }
    }

/***********************************************************************************************************
* endScene()
* QuitGame()
* 
* These functions quit the game if the user chooses
* to discontinue playing the app
* *********************************************************************************************************/
    public void endScene()
    {
        stopGame = true;
    }
    private void QuitGame()
    {
        Application.Quit();
    }

/****************************************************************************************************************
* statsMenu()
* StatMenu()
*
* These functions switch from the MainMenu to the statistics menu and allow for the user to also return
* from the statistics menu back to the MainMenu
* *************************************************************************************************************/
    public void statsMenu()
    {
        showStats = true;
    }
    private void StatMenu(bool clicked)
    {
        if(clicked == true)
        {
            startScene = false;
            showStats = false;
            goBack = false;
            stopGame = false;
            showOptions = false;

            statMenu.gameObject.SetActive(clicked);
            mainMenu.gameObject.SetActive(false);
        }
    }

    /*******************************************************
    * returns to the main menu from the current menu 
    * ***************************************************/
    public void backMenu()
    {
        goBack = true;
    }
    private void backStat(bool clicked)
    {
        if (clicked == true)
        {
            startScene = false;
            showStats = false;
            goBack = false;
            stopGame = false;
            showOptions = false;

            mainMenu.gameObject.SetActive(clicked);
            statMenu.gameObject.SetActive(false);
        }
    }
}
