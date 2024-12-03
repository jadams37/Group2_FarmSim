using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject storyMenu;
    public GameObject controlsMenu;
    public GameObject creditsMenu;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {

        SceneManager.LoadSceneAsync("main");

    }

    public void Story()
    {

        mainMenu.SetActive(false);
        storyMenu.SetActive(true);

    }

    public void Controls()
    {

        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);

    }

    public void Options()
    {

        

    }

    public void Credits()
    {

        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);

    }

    public void ReturnToTitle()
    {

        SceneManager.LoadSceneAsync("startscreen");

    }

    public void Quit()
    {

        Application.Quit(0);
        //EditorApplication.isPlaying = false;

    }

}
