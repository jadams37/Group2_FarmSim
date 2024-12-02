using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crop : MonoBehaviour
{

    // Current crop growth state and maximum state that can
    // be reached
    private int curState = 0;
    private int numStates;

    // How much the crop should give the player when harvested
    public int yieldCount;

    // Current level of water crop has
    public int hydrationLevel = 50;

    public int growthRate;

    // Item dropped from crop when harvested
    public Item drop;

    // Rate at which crop's hydration level drops
    private float decayRate = 0.10f;

    // Name of crop
    private string cropName;

    // Status of whether crop can be collected or not
    private bool isHarvestable;

    private SpriteRenderer spriteRenderer;

    public Sprite[] spriteStates;

    public bool isDecaying = false;

    // Class containing all information related to crops and methods to
    // be performed on said crops

    /*public Crop(string cropName, int numStates, int yieldCount)
    {

        this.numStates = numStates;

        this.yieldCount = yieldCount;

        this.cropName = cropName;

    }*/

    void Start()
    {

        numStates = spriteStates.Length;
        isHarvestable = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteStates[curState];

        InitCrop();

    }

    void Update()
    {

        CheckHydration();
        Destroy();

    }

    private void CheckHydration()
    {

        if(hydrationLevel > 25)
            isDecaying = false;

    }
    
    private void InitCrop()
    {

        StartCoroutine(Grow());
        StartCoroutine(Decay());

    }

    // Method to water crop, increasing it's hydration level
    public void Water(int waterAmount)
    {

        if (hydrationLevel < 100)
            hydrationLevel += waterAmount;

        else
        {

            hydrationLevel = 100;
            Debug.Log("Crop does not need to be watered");

        }

    }

    // Method to increase crop's current growth state if minimum hydration levels
    // are met
    private IEnumerator Grow()
    {

        while(!isHarvestable)
        {

            yield return new WaitForSeconds(growthRate * 100);
            if(!isDecaying)
            {

                curState++;
                spriteRenderer.sprite = spriteStates[curState];

            }

            if(curState >= numStates - 1)
            {

                SetIsHarvestable(true);
                curState = numStates - 1;
                spriteRenderer.sprite = spriteStates[curState];

            }

        }

        StopCoroutine(Grow());

    }

    // Method to reduce crop's hydration level over time
    private IEnumerator Decay()
    {

        while(!isHarvestable)
        {

            yield return new WaitForSeconds((growthRate * 100) / 4);
            hydrationLevel = (int)(hydrationLevel * (1 - decayRate));

            if(hydrationLevel < 25)
            {

                isDecaying = true;

            }

        }

        StopCoroutine(Decay());

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

        if(hydrationLevel <= 0)
        {

            Debug.Log("Crop has died");
            Destroy(gameObject);

        }

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
