using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    // Class relating to Main Menu and End Menu functions
    
    // GameObjects for each menu
    public GameObject mainMenu;
    public GameObject storyMenu;
    public GameObject controlsMenu;
    public GameObject creditsMenu;

    // Method to load main game scene on start of game
    public void StartGame()
    {

        SceneManager.LoadSceneAsync("main");

    }

    // Method to show story menu
    public void Story()
    {

        mainMenu.SetActive(false);
        storyMenu.SetActive(true);

    }

    // Method to show controls menu
    public void Controls()
    {

        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);

    }

    // Method to show credits menu
    public void Credits()
    {

        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }

    // Method to return to start screen scene
    public void ReturnToTitle()
    {

        SceneManager.LoadSceneAsync("startscreen");

    }

    // Method to quit current game instance
    public void Quit()
    {

        Application.Quit(0);
        //EditorApplication.isPlaying = false;

    }

}
