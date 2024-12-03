using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Status variables
    public bool isPaused;
    public bool fastForward;
    public bool isNight;
    public bool isInGodMode;
    public bool hasPaidMortgage;
    public bool isGameOver;

    // Array of ambiance sound effects
    public GameObject[] ambiance;

    // Array of music sound effects
    public GameObject[] music;

    // Reference to DayNightCycle object
    private DayNightCycle dayNightCycle;

    // Reference to PlayerData object
    private PlayerData player;

    // Reference to PlayerUI object
    private PlayerUI playerUI;

    // Game-related constants
    public const float NORMAL = 1.0f;
    public const float FAST_FORWARD = 100.0f;
    public const float PAUSED = 0.0f;

    public const int WIN_MONEY = 5000;
    public const int LOSE_MONEY = -5000;

    // Start is called before the first frame update
    void Start()
    {

        dayNightCycle = GameObject.Find("Main Camera").GetComponent<DayNightCycle>();

        player = GameObject.Find("Player").GetComponent<PlayerData>();

        playerUI = GameObject.Find("GameUI").GetComponent<PlayerUI>();

    }

    // Update is called once per frame
    void Update()
    {

        SetTimeOfDay();
        SetAmbience();
        SetMusic();
        EndGame();

    }

    // Helper method to set music if game is over or not
    private void SetMusic()
    {

        if(!isGameOver)
        {

            music[0].SetActive(true);
            music[1].SetActive(false);

        }

        else
        {

            music[0].SetActive(false);
            music[1].SetActive(true);

        }

    }

    // Method to toggle time fast forwarding
    public void FastForward()
    {

        if(!fastForward)
        {

            fastForward = true;
            Time.timeScale = FAST_FORWARD;

        }

        else
        {

            fastForward = false;
            Time.timeScale = NORMAL;

        }

    }

    // Method to pause game
    public void PauseGame()
    {

        if(!isPaused)
        {

            Debug.Log("Pause");
            isPaused = true;
            Time.timeScale = PAUSED;

        }

        else
        {

            Debug.Log("Unpause");
            isPaused = false;
            Time.timeScale = NORMAL;

        }

    }

    // Method to end game if player meets requirements
    private void EndGame()
    {

        if(player.getMoneyAmount() <= LOSE_MONEY && !isInGodMode)
        {


            if(playerUI.IsInMenu())
                playerUI.GetActiveMenu().SetActive(false);

            if(playerUI.GetShowUI())
                playerUI.ToggleUI();

            playerUI.endMenu.SetActive(true);
            playerUI.endText.text = "You Lose!";
            playerUI.playTimeText.text = "Playtime: " + ConvertTime(player.playTime);
            playerUI.totalMoneySpentText.text = "Total Money Spent: " + string.Format("${0}", player.totalMoneySpent);
            playerUI.highestMoneyText.text = "Highest Money: " + string.Format("${0}", player.highestMoney);
            isGameOver = true;
            Debug.Log("Fail Screen");

        }

        else if(player.getMoneyAmount() >= WIN_MONEY)
        {

            if(playerUI.IsInMenu())
                playerUI.GetActiveMenu().SetActive(false);

            if(playerUI.GetShowUI())
                playerUI.ToggleUI();

            playerUI.endMenu.SetActive(true);
            playerUI.endText.text = "You Win!";
            playerUI.playTimeText.text = "Playtime: " + ConvertTime(player.playTime);
            playerUI.totalMoneySpentText.text = "Total Money Spent: "
                     + string.Format("${0}", player.totalMoneySpent);
            playerUI.highestMoneyText.text = "Highest Money: "
                     + string.Format("${0}", player.highestMoney);
            isGameOver = true;
            Debug.Log("Win Screen");

        }

        else
            isGameOver = false;

    }

    // Helper method to convert playtime to a more readable format
    private string ConvertTime(float playTime)
    {

        int seconds = (int)playTime % 60;
        int minutes = (int)playTime / 60;

        return string.Format("{1}:{0}", seconds, minutes);

    }

    // Method to set whether it is day or night
    private void SetTimeOfDay()
    {

        if(dayNightCycle.hours >= DayNightCycle.NIGHT_INTERVAL
            || dayNightCycle.hours < DayNightCycle.DAY_INTERVAL)
            isNight = true;

        else
            isNight = false;

    }

    // Method to set ambience based on time of day
    private void SetAmbience()
    {

        if(!isNight)
        {

            ambiance[0].SetActive(true);
            ambiance[1].SetActive(false);

        }

        else
        {

            ambiance[0].SetActive(false);
            ambiance[1].SetActive(true);

        }

    }

}
