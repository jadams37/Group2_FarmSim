using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool isPaused;
    public bool fastForward;
    public bool isNight;

    public bool isGameOver;

    public GameObject[] ambiance;

    private DayNightCycle dayNightCycle;

    private PlayerData player;

    // Start is called before the first frame update
    void Start()
    {

        dayNightCycle = GameObject.Find("Main Camera").GetComponent<DayNightCycle>();

        player = GameObject.Find("Player").GetComponent<PlayerData>();

    }

    // Update is called once per frame
    void Update()
    {

        SetTimeOfDay();
        SetAmbience();

        EndGame();

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

        if (player.getMoneyAmount() <= -5000)
        {

            isGameOver = true;

        }

        else
        {

            isGameOver = false;

        }

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
