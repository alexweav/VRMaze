using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public Transform mainMenu;
    public Transform instructMenu;
    public Transform optionMenu;
    public Transform loading;

    public float timer = 3f;//length of gaze required before action is taken
    private float lookTimer = 0f;//length of time the user has looked at an object
    private Renderer myRenderer;
    private BoxCollider myCollider;
    private bool isLookedAt = false;//set if an object is currently being looked at

    /*********************************************************
     variables are set when the corresponding button is pressed 
     **********************************************************/
    private bool startScene = false; //switches scenes
    private bool showInstruct = false; //switches to InstructMenu
    private bool goBack = false; //returns to previous menu
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
                if (startScene == true) //switch scenes
                {
                    //Debug.Log("load "+scene);
                    loading.gameObject.SetActive(true);
                    optionMenu.gameObject.SetActive(false);
                    SceneManager.LoadScene(scene);
                }
                else if (showOptions == true) //switch to options menu
                {
                    //Debug.Log("options");
                    optionMenu.gameObject.SetActive(true);
                    mainMenu.gameObject.SetActive(false);
                }
                else if (showInstruct == true) //show instructions menu
                {
                    //Debug.Log("instructions");
                    instructMenu.gameObject.SetActive(true);
                    mainMenu.gameObject.SetActive(false);
                }
                else if (goBack == true) //return to previous menu
                {
                    //Debug.Log("back");
                    if (instructMenu.gameObject.activeSelf)
                    {
                       // Debug.Log("inst");
                        mainMenu.gameObject.SetActive(true);
                        instructMenu.gameObject.SetActive(false);
                    }
                    else if (optionMenu.gameObject.activeSelf)
                    {
                        //Debug.Log("opt");
                        mainMenu.gameObject.SetActive(true);
                        optionMenu.gameObject.SetActive(false);
                    }
                }

                resetVars();
            }
            
        }
        else //iff user stops gaze before threshold time is reached
        {
           // Debug.Log("Stop gaze");
            resetVars();
        }

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
        startScene = false;
        showInstruct = false;
        goBack = false;
        showOptions = false;
        scene = "MainMenu";
        myCollider.enabled = false;
    }
   
    public void optionsMenu(bool pick)
    {
       // Debug.Log("show opt");
        showOptions = pick;
    }

    public void setScene(string name)
    {
       // Debug.Log("new scene");
        scene = name;
        startScene = true;
    }

    public void InstructMenu(bool pick)
    {
       // Debug.Log("show inst");
        showInstruct = pick;
    }

    public void backMenu(bool pick)
    {
      //  Debug.Log("go back");
        goBack = pick;
    }

}
