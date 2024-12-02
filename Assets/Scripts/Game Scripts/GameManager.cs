using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isPaused;
    public bool fastForward;
    public bool isNight;
    public bool isInGodMode;
    public bool hasPaidMortgage;

    public bool isGameOver;

    public GameObject[] ambiance;

    public GameObject[] music;

    private DayNightCycle dayNightCycle;

    private PlayerData player;

    private PlayerUI playerUI;

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

        //DeductMortgage();

        EndGame();

    }

    private void SetMusic()
    {

        if (!isGameOver)
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

    private void DeductMortgage()
    {

        int month = 1;

        if(dayNightCycle.days % 30 == 0 && !hasPaidMortgage)
        {

            player.setMoneyAmount(player.getMoneyAmount() - 100);
            hasPaidMortgage = true;

        }

        else if(dayNightCycle.days % 30 == 0 && hasPaidMortgage)
        {

            hasPaidMortgage = true;

        }

    }

    public void FastForward()
    {

        if(!fastForward)
        {

            fastForward = true;
            Time.timeScale = 100.0f;

        }

        else
        {

            fastForward = false;
            Time.timeScale = 1.0f;

        }

    }

    public void PauseGame()
    {

        if(!isPaused)
        {

            Debug.Log("Pause");
            isPaused = true;
            Time.timeScale = 0f;

        }

        else
        {

            Debug.Log("Unpause");
            isPaused = false;
            Time.timeScale = 1.0f;

        }


    }

    private void EndGame()
    {

        if(player.getMoneyAmount() <= -5000 && !isInGodMode)
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

        else if(player.getMoneyAmount() >= 5000)
        {

            if(playerUI.IsInMenu())
                playerUI.GetActiveMenu().SetActive(false);

            if(playerUI.GetShowUI())
                playerUI.ToggleUI();

            playerUI.endMenu.SetActive(true);
            playerUI.endText.text = "You Win!";
            playerUI.playTimeText.text = "Playtime: " + ConvertTime(player.playTime);
            playerUI.totalMoneySpentText.text = "Total Money Spent: " + string.Format("${0}", player.totalMoneySpent);
            playerUI.highestMoneyText.text = "Highest Money: " + string.Format("${0}", player.highestMoney);
            isGameOver = true;
            Debug.Log("Win Screen");

        }

        else
        {

            isGameOver = false;

        }

    }

    private string ConvertTime(float playTime)
    {

        int seconds = (int)playTime % 60;
        int minutes = (int)playTime / 60;

        return string.Format("{1}:{0}", seconds, minutes);

    }

    private void SetTimeOfDay()
    {

        if(dayNightCycle.hours >= 20 || dayNightCycle.hours < 6)
            isNight = true;

        else
            isNight = false;

    }

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
