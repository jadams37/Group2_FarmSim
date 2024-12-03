using System.Collections;
using UnityEngine;

public class Crop : MonoBehaviour
{

    // Class containing all information related to crops and methods to
    // be performed on said crops

    // Current crop growth state and maximum state that can
    // be reached
    private int curState = 0;
    private int numStates;

    // How much the crop should give the player when harvested
    public int yieldCount;

    // Current level of water crop has
    public int hydrationLevel = 50;

    // Rate at which crop grows
    public int growthRate;

    // Item dropped from crop when harvested
    public Item drop;

    // Rate at which crop's hydration level drops
    private float decayRate = 0.10f;

    // Name of crop
    private string cropName;

    // Status of whether crop can be collected or not
    private bool isHarvestable;

    // SpriteRender to access crop sprite
    private SpriteRenderer spriteRenderer;

    // Array of all crop state sprites
    public Sprite[] spriteStates;

    // Status of whether crop is decaying or not
    public bool isDecaying = false;

    // Crop related constants
    public const int MIN_HYDRATION = 25;
    public const int MAX_HYDRATION = 100;
    public const int GROWTH_MULT = 100;

    void Start()
    {

        numStates = spriteStates.Length;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = spriteStates[curState];

        InitCrop();

    }

    void Update()
    {

        CheckHydration();
        Destroy();

    }

    // Method to set whether the crop is decaying or not
    private void CheckHydration()
    {

        if(hydrationLevel > MIN_HYDRATION)
            isDecaying = false;

    }
    
    // Helper method to start crop coroutines
    private void InitCrop()
    {

        StartCoroutine(Grow());
        StartCoroutine(Decay());

    }

    // Method to water crop, increasing it's hydration level
    public void Water(int waterAmount)
    {

        if(hydrationLevel < MAX_HYDRATION)
            hydrationLevel += waterAmount;

        else
        {

            hydrationLevel = MAX_HYDRATION;
            Debug.Log("Crop does not need to be watered");

        }

    }

    // Method to increase crop's current growth state if minimum hydration levels
    // are met
    private IEnumerator Grow()
    {

        while(!isHarvestable)
        {

            yield return new WaitForSeconds(growthRate * GROWTH_MULT);
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

            yield return new WaitForSeconds((growthRate * GROWTH_MULT) / 4);
            hydrationLevel = (int)(hydrationLevel * (1 - decayRate));

            if(hydrationLevel < MIN_HYDRATION)
                isDecaying = true;

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

    // Getters and Setters
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
