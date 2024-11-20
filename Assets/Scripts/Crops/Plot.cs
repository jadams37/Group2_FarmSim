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

    /*public Plot(int curState, int numStates, bool isCultivable, Crop crop)
    {

        this.curState = 0;
        this.numStates = numStates;
        this.isCultivable = isCultivable;
        this.crop = null;

    }*/

    void Start()
    {

        isCultivable = true;

        curState = 0;
        numStates = 2;

        sprite = GetComponent<SpriteRenderer>();

        sprite.color = new Color(255, 0, 0);

        cropObject = cropObjects[1];

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Debris"))
            isCultivable = false;

    }

    private void OnMouseDown()
    {

        if(Time.timeScale == 0)
            return;

        if(isCultivable && curState == 0)
            Cultivate();

        if(!isCultivable)
            Debug.Log("Plot not unlocked.");

        if(crop != null && crop.GetIsHarvestable()  && curState == 1)
            Harvest();

    }

    private void OnMouseOver()
    {

        if(Input.GetMouseButtonDown(1) && curState == 1 && crop == null && Time.timeScale != 0)
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

    private void Cultivate()
    {

        Debug.Log("Plot cultivated");
        curState = 1;
        sprite.color = new Color(0, 255, 0);

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
