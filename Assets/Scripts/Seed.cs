using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the attributes
public class Seed
{
   
    private string name;
   
    private int yieldCount;
    private bool isPlanted;
    private float hydrationRequired;

    // Constructor
    public Seed(string name, int yieldCount, float hydrationRequired)
    {
        this.name = name; //NAME OF SEED
       
        this.yieldCount = yieldCount;
        this.isPlanted = false; // Initially not planted
        this.hydrationRequired = hydrationRequired;
    }

    // Getter and Setter Methods
    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    

    public int GetYieldCount()
    {
        return yieldCount;
    }

    public void SetYieldCount(int yieldCount)
    {
        this.yieldCount = yieldCount;
    }

    public bool GetIsPlanted()
    {
        return isPlanted;
    }

    public void SetIsPlanted(bool isPlanted)
    {
        this.isPlanted = isPlanted;
    }

    public float GetHydrationRequired()
    {
        return hydrationRequired;
    }

    public void SetHydrationRequired(float hydrationRequired)
    {
        this.hydrationRequired = hydrationRequired;
    }

    // Class Methods
    public void Plant()
    {
        if (!isPlanted)
        {
            isPlanted = true;
            Debug.Log(seedName + " has been planted.");
        }
        else
        {
            Debug.Log(seedName + " is already planted.");
        }
    }


    public void Water()
    {
        Debug.Log("Watering " + seedName + ". );
    }

   
}
