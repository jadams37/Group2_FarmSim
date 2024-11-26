using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plow : Tool
{

    void Start()
    {

        toolIndex = 1;
        toolUseTime = 3;

    }

    public override void UseTool(Plot plot)
    {

        if(canUseTool)
        {

            plot.Cultivate();
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
