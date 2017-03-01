using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public Transform mainMenu;
    public Transform statMenu;

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StatMenu(bool clicked)
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

    public void backButton(bool clicked)
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
