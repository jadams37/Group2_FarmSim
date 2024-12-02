using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Tool
{

    private int waterAmount = 10;

    void Start()
    {

        toolIndex = 0;
        toolUseTime = 1;
        toolAudio = transform.GetComponent<AudioSource>();

    }

    public override void UseTool(Plot plot)
    {

        if(canUseTool)
        {

            plot.Water(waterAmount);
            toolAudio.Play();
            canUseTool = false;
            StartCoroutine(ToolCooldown());

        }

    }

    public override IEnumerator ToolCooldown()
    {

        yield return new WaitForSecondsRealtime(toolUseTime);
        canUseTool = true;

    }

}
