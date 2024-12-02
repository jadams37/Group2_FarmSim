using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class DayNightCycle : MonoBehaviour
{

    public PostProcessVolume postProcVol;

    public float tick;
    public float seconds;
    public int mins;
    public int hours;
    public int days;
    public int curDay;

    void Start()
    {

        // Default
        tick = 60.0f;
        hours = 7;
        days = 1;

        curDay = days;

        // Load time stats from save here

    }

    void FixedUpdate()
    {

        CalculateTime();

    }

    private void NewDayTransition()
    {

        if(days > curDay && hours == 7)
        {

            curDay = days;

        }

    }

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

    private void ControlWeight()
    {

        if(hours >= 20 && hours < 21)
        {

            postProcVol.weight = (float)mins / 60;

        }

        if(hours >= 6 && hours < 7)
        {

            postProcVol.weight = 1 - (float)mins / 60;

        }

    }
}
