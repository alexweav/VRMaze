using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.EditorTools;

namespace Assets.Scripts
{
    public class LevelManager : MonoBehaviour
    {

        public Transform mainMenu;
        public Transform instructMenu;
        public Transform optionMenu;
        public Transform loading;
        public Transform freeRoamOptionMenu;
        public Transform timeTrialOptionMenu;

        public GameObject emptyStart;

        public float timer = 3f;//length of gaze required before action is taken
        private float lookTimer = 0f;//length of time the user has looked at an object
        private Renderer myRenderer;
        private BoxCollider myCollider;
        private bool isLookedAt = false;//set if an object is currently being looked at

        [ReadOnly]
        public bool isLoading = false;

        /*********************************************************
	     variables are set when the corresponding button is pressed 
	     **********************************************************/
        private bool startScene = false; //switches scenes
        private bool showInstruct = false; //switches to InstructMenu
        private bool goBack = false; //returns to previous menu
        private bool showOptions = false; //switches to game options menu
        private bool showFreeRoamOptions = false; //switch to Free Roam Difficulty menu
        private bool showTimeTrialOptions = false; //switch to Time Trial Difficulty menu

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
            if (isLookedAt && !isLoading) //iff an item is being looked at by the user
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
                    if (startScene == true)//switch scenes
                    { 
                        loading.gameObject.SetActive(true);
                        optionMenu.gameObject.SetActive(false);
                        freeRoamOptionMenu.gameObject.SetActive(false);
                        isLoading = true;
                        StartCoroutine(LoadSceneAsync());
						//GameTimer.MaxGameTime = 300;
                    }
                    else if (showOptions == true)//switch to options menu
                    { 
                        optionMenu.gameObject.SetActive(true);
                        mainMenu.gameObject.SetActive(false);
                    }
                    else if (showInstruct == true)//show instructions menu
                    { 
                        instructMenu.gameObject.SetActive(true);
                        mainMenu.gameObject.SetActive(false);
                    }
                    else if (showFreeRoamOptions == true) //show free roam difficulty menu
                    {
                        freeRoamOptionMenu.gameObject.SetActive(true);
                        optionMenu.gameObject.SetActive(false);
                    }
                    else if(showTimeTrialOptions == true) //show time trial difficulty menu
                    {
                        timeTrialOptionMenu.gameObject.SetActive(true);
                        optionMenu.gameObject.SetActive(false);
                    }
                    else if (goBack == true) //return to previous menu
                    {
                        if (instructMenu.gameObject.activeSelf) //return from instruction menu
                        {
                            mainMenu.gameObject.SetActive(true);
                            instructMenu.gameObject.SetActive(false);
                        }
                        else if (optionMenu.gameObject.activeSelf) //return from options menu
                        {
                            mainMenu.gameObject.SetActive(true);
                            optionMenu.gameObject.SetActive(false);
                        }
                        else if(freeRoamOptionMenu.gameObject.activeSelf) //return from freeRoam option menu
                        {
                            optionMenu.gameObject.SetActive(true);
                            freeRoamOptionMenu.gameObject.SetActive(false);
                        }
                        else if(timeTrialOptionMenu.gameObject.activeSelf) //return from time trial option menu
                        {
                            optionMenu.gameObject.SetActive(true);
                            timeTrialOptionMenu.gameObject.SetActive(false);
                        }
                    }

                    resetVars();
                }

            }
            else //iff user stops gaze before threshold time is reached
            {
                resetVars();
            }

        }

        public void StartGaze() // called once the user sets their reticle on an interactible object
        {
            isLookedAt = true;
        }

        public void StopGaze() //called once the user moves their reticle off of an interactible object
        {
            isLookedAt = false;
        }

        private void resetVars() //resets all variables to false -- called if the user stops their gaze
        {
            if (!isLoading)
            {
                lookTimer = 0f;
                myRenderer.material.SetFloat("cutoff", 0f);
                startScene = false;
                showInstruct = false;
                goBack = false;
                showOptions = false;
                showFreeRoamOptions = false;
                showTimeTrialOptions = false;
                scene = "MainMenu";
                myCollider.enabled = false;
            }
        }

        public void optionsMenu(bool pick) //user wants to view the game options
        {
            showOptions = pick;
        }

        public void setScene(string name) //new scene is to be loaded
        {
            scene = name;
			if (scene == "TimeTrialEasy") 
			{
				scene = "TimeTrial";
				GameTimer.MaxGameTime = 300;
			}
			else if (scene == "TimeTrialMedium")
			{
				scene = "TimeTrial";
				GameTimer.MaxGameTime = 600;
			}
			else if (scene == "TimeTrialHard")
			{
				scene = "TimeTrial";
				GameTimer.MaxGameTime = 300;
			}

            startScene = true;
        }

        public void InstructMenu(bool pick) //user wants to see the game instructions
        {
            showInstruct = pick;
        }

        public void FreeRoamMenu(bool pick) //user wants to see the freeRoam game options
        {
            showFreeRoamOptions = pick;
        }

        public void TimeTrialMenu(bool pick) //user wants to see the time trial options
        {
            showTimeTrialOptions = pick;
        }

        public void backMenu(bool pick) //user wants to return to the previous menu panel
        {
            goBack = pick;
        }

        public void setFreeRoamDifficulty(string difficulty)
        {
            MazeGenerate mazeSize = emptyStart.GetComponent<MazeGenerate>();
            var noob = 5;
            var normal = 15;
            var expert = 25;
            if (difficulty == "Beginner")
            {
                Debug.Log(mazeSize.height);
                mazeSize.height = noob;
                mazeSize.width = noob;
            }
            else if (difficulty == "Normal")
            {
                Debug.Log(mazeSize.height);
                mazeSize.height = normal;
                mazeSize.width = normal;
            }
            if (difficulty == "Expert")
            {
                Debug.Log(mazeSize.height);
                mazeSize.height = expert;
                mazeSize.width = expert;
            }
            else
            {
                Debug.Log("Difficulty selection is not properly setup.");
            }
            setScene("FreeRoam");
            //Debug.Log (mazeSize.height);
        }

        /// <summary>
        /// Coroutine which loads a scene asynchronously
        /// </summary>
        IEnumerator LoadSceneAsync()
        {
            yield return new WaitForSeconds(0.5f);
            Application.backgroundLoadingPriority = ThreadPriority.Low;
            Debug.Log("Scene: " + scene);
            AsyncOperation loadTask = SceneManager.LoadSceneAsync(scene);
            loadTask.allowSceneActivation = false;
            yield return loadTask.isDone;
            yield return new WaitForSeconds(1.0f);
            SwitchScene(loadTask);
        }


        private void SwitchScene(AsyncOperation loadTask)
        {
            if (loadTask != null)
            {
                loadTask.allowSceneActivation = true;
            }
        }
    }
}