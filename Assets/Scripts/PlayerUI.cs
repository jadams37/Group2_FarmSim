using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public GameObject playerMoney;
    public GameObject gameTime;

    public GameObject inventoryMenu;
    public GameObject marketMenu;
    public GameObject pauseMenu;

    public Button inventoryButton;
    public Button marketButton;

    private bool showUI;

    // Start is called before the first frame update
    void Start()
    {

        showUI = true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns if player has a menu open, excluding the pause menu
    public bool IsInMenu()
    {

        if (inventoryMenu.activeInHierarchy || marketMenu.activeInHierarchy)
            return true;

        else
            return false;

    }

    // Returns current menu opened
    public GameObject GetActiveMenu()
    {

        if(inventoryMenu.activeInHierarchy)
            return inventoryMenu;

        else
            return marketMenu;

    }

    public void ToggleUI()
    {

        if(showUI)
        {

            showUI = false;
            playerMoney.SetActive(false);
            gameTime.SetActive(false);
            inventoryButton.gameObject.SetActive(false);
            marketButton.gameObject.SetActive(false);

        }

        else if(!showUI)
        {

            showUI = true;
            playerMoney.SetActive(true);
            gameTime.SetActive(true);
            inventoryButton.gameObject.SetActive(true);
            marketButton.gameObject.SetActive(true);

        }

    }

    public GameObject GetPlayerMoney()
    {
        return playerMoney;
    }

    public GameObject GetGameTime()
    {
        return gameTime;
    }

    public GameObject GetInventoryMenu()
    {
        return inventoryMenu;
    }

    public GameObject GetMarketMenu()
    {
        return marketMenu;
    }

    public GameObject GetPauseMenu()
    {
        return pauseMenu;
    }

    public Button GetInventoryButton()
    {
        return inventoryButton;
    }
    public Button GetMarketButton()
    {
        return marketButton;
    }

    public bool GetShowUI()
    {
        return showUI;
    }

}
