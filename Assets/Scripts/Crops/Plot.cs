using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Plot : MonoBehaviour
{

    public int curState;
    private int numStates;

    public bool isCultivable;

    public Crop crop;

    public GameObject cropObject;

    private SpriteRenderer sprite;

    public GameObject[] cropObjects;

    private PlayerUI playerUI;

    private PlayerData player;

    public Sprite[] spriteStates;

    /*public Plot(int curState, int numStates, bool isCultivable, Crop crop)
    {

        this.curState = 0;
        this.numStates = numStates;
        this.isCultivable = isCultivable;
        this.crop = null;

    }*/

    void Start()
    {

        playerUI = GameObject.Find("GameUI").GetComponent<PlayerUI>();

        isCultivable = true;

        numStates = spriteStates.Length;
        curState = SetRandomState();

        sprite = GetComponent<SpriteRenderer>();

        sprite.sprite = spriteStates[curState];

        cropObject = cropObjects[0];

        player = GameObject.Find("Player").GetComponent<PlayerData>();

    }

    void Update()
    {

    }

    private int SetRandomState()
    {

        int chanceOfDebris = 5;
        int state = Random.Range(0, numStates);
        int debris = Random.Range(0, chanceOfDebris + 1);

        if(state <= 3 || debris < chanceOfDebris)
            state = 0;

        return state;

    }

    private void OnMouseDown()
    {

        if(playerUI.isInPauseMenu() || playerUI.IsInMenu() || playerUI.GetCursorOnUI())
            return;

        if(isCultivable && curState < 3 && player.GetToolEquipped() != null && player.GetToolEquipped().toolIndex == 1)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

        if(!isCultivable && player.GetToolEquipped() != null && player.GetToolEquipped().toolIndex == 1)
            Debug.Log("Plot not unlocked.");

        if(curState > 3 && player.GetToolEquipped() != null && player.GetToolEquipped().toolIndex == 1)
            Debug.Log("Plot has debris");

        if(curState == 3)
            Debug.Log("Plot is cultivated");

        if(crop != null && crop.GetHydrationLevel() < 100 && player.GetToolEquipped() != null && player.GetToolEquipped().toolIndex == 0)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

        if(crop != null && crop.GetIsHarvestable()  && curState == 3)
            Harvest();

        if(curState > 3 && player.GetToolEquipped() != null && player.GetToolEquipped().toolIndex == 2)
            player.GetToolEquipped().UseTool(transform.GetComponent<Plot>());

    }

    private void OnMouseOver()
    {

        if(Input.GetMouseButtonDown(1) && curState == 3 && crop == null && (!playerUI.isInPauseMenu() || !playerUI.IsInMenu() || !playerUI.GetCursorOnUI()))
        {

            Debug.Log("Crop planted");
            cropObject = PrefabUtility.InstantiatePrefab(cropObject) as GameObject;
            cropObject.transform.position = transform.position;
            cropObject.transform.rotation = transform.rotation;
            cropObject.transform.parent = transform;
            crop = cropObject.GetComponent<Crop>();

        }

    }

    public void Harvest()
    {

        crop.Harvest();
        Destroy(transform.GetChild(0).gameObject);
        crop = null;

    }

    public void Cultivate()
    {

        curState++;
        sprite.sprite = spriteStates[curState];

    }

    public void ClearDebris()
    {

        curState = 0;
        sprite.sprite = spriteStates[curState];

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
