using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plot : MonoBehaviour
{

    private int curState;
    private int numStates;

    private bool isCultivable;

    private Crop crop;

    public Plot(int curState, int numStates, bool isCultivable)
    {

        this.curState = 0;
        this.numStates = numStates;
        this.isCultivable = isCultivable;

    }

    private void OnMouseDown()
    {

        if(isCultivable && curState == 0)
            Cultivate();

        if (crop.GetIsHarvestable() && curState == 1)
            Harvest();

    }

    private void Harvest()
    {

        crop.Destroy();

    }

    private void Cultivate()
    {
        SetCurState(1);
    }

    public int GetCurState()
    {
        return curState;
    }

    public int GetNumStates()
    {
        return numStates;
    }

    public bool GetIsCultivable()
    {
        return isCultivable;
    }

    public Crop GetCrop()
    {
        return crop;
    }

    public void SetCurState(int curState)
    {
        this.curState = curState;
    }

    public void SetNumStates(int numStates)
    {
        this.numStates = numStates;
    }

    public void SetIsCultivable(bool isCultivable)
    {
        this.isCultivable = isCultivable;
    }

    public void SetCrop(Crop crop)
    {
        this.crop = crop;
    }

}
