using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    // References to all GUI elements
    public GameObject playerMoney;

    public TextMeshProUGUI moneyText;

    public GameObject gameTime;

    public TextMeshProUGUI timeText;

    public GameObject inventoryMenu;
    public GameObject marketMenu;
    public GameObject pauseMenu;

    public Button inventoryButton;
    public Button marketButton;

    public GameObject ToolIcon;

    public Sprite[] toolIcons;

    private DayNightCycle timeDisplay;

    private PlayerData player;

    // Status for GUI visibility
    private bool showUI;

    private bool cursorOnUI;

    // Class containing all GUI element references and methods for functionality

    // Start is called before the first frame update
    void Start()
    {

        timeDisplay = GameObject.Find("Main Camera").GetComponent<DayNightCycle>();

        player = GameObject.Find("Player").GetComponent<PlayerData>();

        showUI = true;

    }

    // Update is called once per frame
    void Update()
    {

        SetGameTime();
        SetPlayerMoney();
        ShowToolIcon();

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if(eventData.pointerEnter.gameObject.layer == 5)
            cursorOnUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        cursorOnUI = false;

    }

    // Returns if player has a menu open, excluding the pause menu
    public bool IsInMenu()
    {

        if(inventoryMenu.activeInHierarchy || marketMenu.activeInHierarchy)
            return true;

        else
            return false;

    }

    public bool isInPauseMenu()
    {

        if(pauseMenu.activeInHierarchy)
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

    // Enables or disables GUI
    public void ToggleUI()
    {

        if(showUI)
            UIOff();

        else if(!showUI)
            UIOn();

    }

    private void ShowToolIcon()
    {

        if(player.GetHasToolEquipped() && !(IsInMenu() || isInPauseMenu()))
        {

            ToolIcon.SetActive(true);
            ToolIcon.transform.position = Input.mousePosition;
            Cursor.visible = false;

        }

        else
        {

            ToolIcon.SetActive(false);
            Cursor.visible = true;

        }

    }

    private void SetPlayerMoney()
    {

        moneyText.text = string.Format("Money: ${0}", player.getMoneyAmount());

    }

    private void SetGameTime()
    {

        int hours = timeDisplay.hours;
        int mins = timeDisplay.mins;

        string[] timeOfDays = {"AM", "PM"};
        string timeOfDay = timeOfDays[0];

        if (timeDisplay.hours > 11 && timeDisplay.hours != 12)
        {
            hours = timeDisplay.hours - 12;
            timeOfDay = timeOfDays[1];
        }

        else if (timeDisplay.hours == 12)
            timeOfDay = timeOfDays[1];

        else
            timeOfDay = timeOfDays[0];

        timeText.text = string.Format("Time: {0}:{1:00} {2}", hours, mins, timeOfDay);

    }

    // Helper method to hide the GUI
    private void UIOff()
    {

        showUI = false;
        playerMoney.SetActive(false);
        gameTime.SetActive(false);
        inventoryButton.gameObject.SetActive(false);
        marketButton.gameObject.SetActive(false);

    }

    // Helper method to show the GUI
    private void UIOn()
    {

        showUI = true;
        playerMoney.SetActive(true);
        gameTime.SetActive(true);
        inventoryButton.gameObject.SetActive(true);
        marketButton.gameObject.SetActive(true);

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

    public bool GetCursorOnUI()
    {
        return cursorOnUI;
    }

    public void SetPlayerMoney(GameObject playerMoney)
    {
        this.playerMoney = playerMoney;
    }

    public void SetGameTime(GameObject gameTime)
    {
        this.gameTime = gameTime;
    }

    public void SetInventoryMenu(GameObject inventoryMenu)
    {
        this.inventoryMenu = inventoryMenu;
    }

    public void SetMarketMenu(GameObject marketMenu)
    {
        this.marketMenu = marketMenu;
    }

    public void SetPauseMenu(GameObject pauseMenu)
    {
        this.pauseMenu = pauseMenu;
    }

    public void SetInventoryButton(Button inventoryButton)
    {
        this.inventoryButton = inventoryButton;
    }
    public void SetMarketButton(Button marketButton)
    {
        this.marketButton = marketButton;
    }

    public void SetShowUI(bool showUI)
    {
        this.showUI = showUI;
    }

    public void SetCursorOnUI(bool cursorOnUI)
    {
        this.cursorOnUI = cursorOnUI;
    }

}
