using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crop : MonoBehaviour
{

    // Current crop growth state and maximum state that can
    // be reached
    private int curState;
    private int numStates;

    // How much the crop should give the player when harvested
    private int yieldCount;

    // Current level of water crop has
    private int hydrationLevel;

    private int growthRate = 10;

    // Item dropped from crop when harvested
    private Item drop;

    // Rate at which crop's hydration level drops
    private float decayRate;

    // Name of crop
    private string cropName;

    // Status of whether crop can be collected or not
    private bool isHarvestable;

    private SpriteRenderer spriteRenderer;

    public Sprite[] spriteStates;

    // Class containing all information related to crops and methods to
    // be performed on said crops

    /*public Crop(int curState, int numStates, int yieldCount, int hydrationLevel, 
                float decayRate, string cropName, bool isHarvestable)
    {

        this.curState = 0;
        this.numStates = numStates;

        this.yieldCount = yieldCount;
        this.hydrationLevel = 50;

        this.decayRate = 0.10f;

        this.cropName = cropName;

        this.isHarvestable = false;

    }*/

    void Start()
    {

        curState = 0;
        hydrationLevel = 50;
        numStates = spriteStates.Length - 1;
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetSprite();

        StartCoroutine(InitCrop());

    }

    void Update()
    {

        

    }

    IEnumerator InitCrop()
    {

        while(true)
        {

            yield return new WaitForSeconds(growthRate);
            Grow();
            SetSprite();

        }

    }

    private void SetSprite()
    {

        spriteRenderer.sprite = spriteStates[curState];

    }

    // Method to water crop, increasing it's hydration level
    public void Water()
    {

        if(hydrationLevel > 100)
            SetHydrationLevel(100);

        if(hydrationLevel != 100)
        {

            int curHydration = (int)(hydrationLevel * (1 + decayRate));
            SetHydrationLevel(curHydration);

        }

        else
            Debug.Log("Crop does not need to be watered");

    }

    // Method to increase crop's current growth state if minimum hydration levels
    // are met
    public void Grow()
    {

        if(hydrationLevel >= 50)
        {

            curState++;

        }

        if(curState >= numStates)
        {

            SetIsHarvestable(true);
            curState = numStates;

        }

    }

    // Method to reduce crop's hydration level over time
    public void Decay()
    {

        if(hydrationLevel < 50 && !isHarvestable)
        {

            int curHydration = (int)(hydrationLevel * (1 - decayRate));
            SetHydrationLevel(curHydration);

        }

    }

    // Method to allow crop to be harvested once it is fully grown
    public Item Harvest()
    {

        if(isHarvestable)
        {

            Debug.Log("Crop harvested");
            return drop;

        }

        else
        {

            Debug.Log("Crop not ready for harvest");
            return null;

        }

    }

    // Method to remove crop if hydration levels reach 0
    public void Destroy()
    {
        if (hydrationLevel <= 0)
        {

            Debug.Log("Crop has died");
            Destroy(gameObject);

        }

        else
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
        return cropName;
    }

    public Item GetDrop()
    {
        return drop;
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

    public void SetName(string cropName)
    {
        this.cropName = cropName;
    }

    public void SetIsHarvestable(bool isHarvestable)
    {
        this.isHarvestable = isHarvestable;
    }

    public void SetDrop(Item drop)
    {
        this.drop = drop;
    }

}
