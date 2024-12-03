using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Plot : MonoBehaviour
{

    // Class containing all information related to plots and methods to
    // be performed on said plots

    // Current plot state and maximum state that can
    // be reached
    public int curState;
    private int numStates;

    // Status of whether the plot can be culitvated or not
    public bool isCultivable;

    // Reference to Crop object
    public Crop crop;

    // Crop GameObject to be instantiated
    public GameObject cropObject;

    // SpriteRender reference to access sprite
    private SpriteRenderer sprite;

    // Array of valid crop GameObjects that can be planted
    public GameObject[] cropObjects;

    // Reference to PlayerUI object
    private PlayerUI playerUI;

    // Reference to PlayerData object
    private PlayerData player;

    // Reference to Seeds object
    private Seeds seeds;

    // Array of plot sprite states
    public Sprite[] spriteStates;

    // Icon to show if crop needs water
    private GameObject waterIcon;

    // Status of whether the cursor is hovering over plot
    public bool isHighlighted = false;

    // Plot related constant
    public const int DEBRIS_CHANCE = 5;

    void Start()
    {

        playerUI = GameObject.Find("GameUI").GetComponent<PlayerUI>();

        isCultivable = true;

        numStates = spriteStates.Length;
        curState = SetRandomState();

        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = spriteStates[curState];

        player = GameObject.Find("Player").GetComponent<PlayerData>();

        waterIcon = transform.GetChild(0).gameObject;

        seeds = GameObject.Find("Seeds").GetComponent<Seeds>();

    }

    void Update()
    {

        SetWaterIcon();
        SetCropObject();
        

    }

    // Helper method to set crop to current seed equipped
    private void SetCropObject()
    {

        if(seeds.seedsOwned.Count > 0
            && seeds.seedsOwned.Contains(seeds.seedEquipped))
            cropObject = cropObjects[seeds.seedEquipped];

        else
            cropObject = null;

    }

    // Helper method to show water icon if crop is decaying
    private void SetWaterIcon()
    {

        if (crop != null && crop.isDecaying)
            waterIcon.SetActive(true);

        else
            waterIcon.SetActive(false);

    }

    // Helper method to set whether if crop has debris or not
    private int SetRandomState()
    {

        int state = Random.Range(0, numStates);
        int debris = Random.Range(0, DEBRIS_CHANCE + 1);

        if(state <= 3 || debris < DEBRIS_CHANCE)
            state = 0;

        return state;

    }

    // Method to control Left Mouse Click plot interactions
    private void OnMouseDown()
    {

        if(playerUI.isInPauseMenu()
            || playerUI.IsInMenu()
            || playerUI.GetCursorOnUI())
            return;

        if(isCultivable && curState < 3
            && player.GetToolEquipped() != null
            && player.GetToolEquipped().toolIndex == 1)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

        if(!isCultivable && player.GetToolEquipped() != null
            && player.GetToolEquipped().toolIndex == 1)
            Debug.Log("Plot not unlocked.");

        if(curState > 3 && player.GetToolEquipped() != null
            && player.GetToolEquipped().toolIndex == 1)
        {

            Debug.Log("Plot has debris");
            return;

        }

        if(curState == 3)
        {

            Debug.Log("Plot is cultivated");

        }

        if(crop != null && crop.GetHydrationLevel() < Crop.MAX_HYDRATION
            && player.GetToolEquipped() != null
            && player.GetToolEquipped().toolIndex == 0)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

        if(crop != null && crop.GetIsHarvestable()
            && curState == 3
            && !player.GetHasToolEquipped())
            Harvest();

        if(curState > 3 && player.GetToolEquipped() != null
            && player.GetToolEquipped().toolIndex == 2)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

    }

    // Method to highlight the plot if selected and plant
    // crop on Right Mouse Button
    private void OnMouseOver()
    {

        if(playerUI.isInPauseMenu()
            || playerUI.IsInMenu()
            || playerUI.GetCursorOnUI())
            return;

        if(Input.GetMouseButtonDown(1) 
            && curState == 3 
            && crop == null 
            && cropObject != null)
        {

            Debug.Log("Crop planted");
            //cropObject = PrefabUtility.InstantiatePrefab(cropObject) as GameObject;
            cropObject = Instantiate(cropObject, transform.position, transform.rotation, transform);
            //cropObject.transform.position = transform.position;
            //cropObject.transform.rotation = transform.rotation;
            //cropObject.transform.parent = transform;
            crop = cropObject.GetComponent<Crop>();
            seeds.seedsOwned.Remove(seeds.seedEquipped);

        }

        isHighlighted = true;

        if(player.GetToolEquipped() != null && player.GetHasToolEquipped())
            sprite.color = new Color(0.70f, 0.70f, 0.70f);

        else
            sprite.color = Color.white;

    }

    // Method to remove plot highlight if not selected
    private void OnMouseExit()
    {

        isHighlighted = false;

        sprite.color = Color.white;

    }

    // Method to water crop if watering can used on plot
    public void Water(int waterAmount)
    {

        crop.Water(waterAmount);

    }

    // Method to harvest crop and give player money in return
    public void Harvest()
    {

        player.setMoneyAmount(player.getMoneyAmount() + (crop.drop.itemValue * crop.yieldCount));
        crop.Harvest();
        Destroy(transform.GetChild(1).gameObject);
        crop = null;

    }

    // Method to cultivate plot
    public void Cultivate()
    {

        curState++;
        sprite.sprite = spriteStates[curState];

    }

    // Method to clear any debris on plot
    public void ClearDebris()
    {

        curState = 0;
        sprite.sprite = spriteStates[curState];

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
