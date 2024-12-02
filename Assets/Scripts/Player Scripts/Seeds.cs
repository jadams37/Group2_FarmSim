using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : Tool
{

    public List<int> seedsOwned;

    void Start()
    {

        seedsOwned = new List<int>();
        
        toolIndex = 3;
        toolUseTime = 0.5f;
        toolAudio = transform.GetComponent<AudioSource>();

    }

    public override void UseTool(Plot plot)
    {

        if(canUseTool)
        {

            plot.Cultivate();
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
