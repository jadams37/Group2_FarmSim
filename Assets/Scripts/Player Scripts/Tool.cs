using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Tool : MonoBehaviour
{

    public int toolUseTime;
    public int toolIndex;
    public int tier = 0;

    public bool canUseTool = true;

    public abstract void UseTool(Plot plot);
    public abstract IEnumerator ToolCooldown();

}
