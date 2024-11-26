using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCan : Tool
{

    private int waterAmount = 10;

    void Start()
    {

        toolIndex = 0;

    }

    public override void UseTool(Plot plot)
    {

        if(canUseTool)
        {

            plot.crop.Water(waterAmount);
            canUseTool = false;
            StartCoroutine(ToolCooldown());

        }

    }

    public override IEnumerator ToolCooldown()
    {

        yield return new WaitForSecondsRealtime(0.5f);
        canUseTool = true;

    }

}
