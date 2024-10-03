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
    public int hours = 7;
    public int days = 1;

    void Start()
    {

    }


    void FixedUpdate()
    {

        CalculateTime();

    }

    public void CalculateTime()
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

            hours = 0;
            days += 1;

        }

        ControlWeight();

    }

    public void ControlWeight()
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
