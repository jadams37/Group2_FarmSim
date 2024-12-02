using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : Tool
{
    void Start()
    {

        toolIndex = 2;
        toolUseTime = 0.5f;
        toolAudio = transform.GetComponent<AudioSource>();

    }

    public override void UseTool(Plot plot)
    {

        if(canUseTool)
        {

            plot.ClearDebris();
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
