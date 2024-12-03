using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DayNightCycle : MonoBehaviour
{

    // Class relating to Day/Night Cycle

    // PostProcessVolume object to apply effects
    public PostProcessVolume postProcVol;

    // Time related variables
    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days;

    // Day/Night Cycle related constants
    public const int NIGHT_INTERVAL = 20;
    public const int DAY_INTERVAL = 6;

    void Start()
    {

        tick = 60.0f;
        hours = 7;
        days = 1;

    }

    void FixedUpdate()
    {

        CalculateTime();

    }

    // Method to determine number of seconds, hours, and days
    private void CalculateTime()
    {

        seconds += Time.fixedDeltaTime * tick;

        if(seconds >= 60)
        {

            seconds = 0;
            mins += 1;

        }

        if(mins >= 60)
        {

            mins = 0;
            hours += 1;

        }

        if(hours >= 24)
        {

            hours = 1;
            days += 1;

        }

        ControlWeight();

    }

    // Method to control post processing effect
    private void ControlWeight()
    {

        if(hours >= NIGHT_INTERVAL && hours < NIGHT_INTERVAL + 1)
        {

            postProcVol.weight = (float)mins / 60;

        }

        if(hours >= DAY_INTERVAL && hours < DAY_INTERVAL + 1)
        {

            postProcVol.weight = 1 - (float)mins / 60;

        }

    }
}
