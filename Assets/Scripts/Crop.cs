using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crop : MonoBehaviour
{

    private int curState;
    private int numStates;
    private int yieldCount;
    private int hydrationLevel;

    private float decayRate;

    private string name;

    private bool isHarvestable;

    public Crop(int curState, int numStates, int yieldCount, int hydrationLevel, float decayRate, string name, bool isHarvestable)
    {

        this.curState = 0;
        this.numStates = numStates;

        this.yieldCount = yieldCount;
        this.hydrationLevel = 50;

        this.decayRate = 0.10f;

        this.name = name;

        this.isHarvestable = false;

    }

    public void Grow()
    {
        
        if(hydrationLevel >= 50)
            curState++;

        if(curState >= numStates)
            SetIsHarvestable(true);

    }

    public void Decay()
    {

        int curHydration = (int)(hydrationLevel * (1 - decayRate));
        SetHydrationLevel(curHydration);

        if(hydrationLevel == 0)
            Destroy();

    }

    public void Destroy()
    {

        Destroy(gameObject);

    }

    public int GetCurState()
    {
        return curState;
    }

    public int GetNumStates()
    {
        return numStates;
    }

    public int GetYieldCount()
    {
        return yieldCount;
    }

    public int GetHydrationLevel()
    {
        return hydrationLevel;
    }

    public float GetDecayRate()
    {
        return decayRate;
    }

    public string GetName()
    {
        return name;
    }

    public bool GetIsHarvestable()
    {
        return isHarvestable;
    }

    public void SetCurState(int curState)
    {
        this.curState = curState;
    }

    public void SetNumStates(int numStates)
    {
        this.numStates = numStates;
    }

    public void SetYieldCount(int yieldCount)
    {
        this.yieldCount = yieldCount;
    }

    public void SetHydrationLevel(int hydrationLevel)
    {
        this.hydrationLevel = hydrationLevel;
    }

    public void SetDecayRate(float decayRate)
    {
        this.decayRate = decayRate;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public void SetIsHarvestable(bool isHarvestable)
    {
        this.isHarvestable = isHarvestable;
    }

}
