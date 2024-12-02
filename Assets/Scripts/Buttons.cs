using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        //Get the button from the game, and attach a listener to the button
        button = GetComponent<Button>();
        button.onClick.AddListener(Action);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action()
    {
        //Get the name of the button
        string buttonName = gameObject.name;

        //Log the button that was clicked
        Debug.Log(buttonName + "was clicked.");

        //Operations dependant on the name of the button pressed
        switch(buttonName)
        {
            case "ContinueButton":
                //Close the pause menu
                break;
            case "SaveButton":
                //Save the game
                break;
            case "LoadButton":
                //Load a saved game
                break;
            case "OptionsButton":
                //Open the options menu
                break;
            case "MenuButton_Main":
                //Return to Main Menu
                break;
            case "QuitButton":
                //Directly quit the game
                break;
            case "ReturnButton":
                //Return to the pause menu
                break;
        }
    }
}
