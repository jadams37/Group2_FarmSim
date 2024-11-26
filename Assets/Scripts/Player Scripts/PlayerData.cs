using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int moneyAmount = 0;

    private Item[] itemsSoldForDay;

    private Inventory_Redone inventory;

    private bool hasToolEquipped;

    public Tool toolEquipped;

    public Tool[] tools;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory_Redone();

        toolEquipped = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getMoneyAmount()
    {
        return moneyAmount;
    }

    public Item[] GetItemsSoldForDay()
    {
        return itemsSoldForDay;
    }

    public bool GetHasToolEquipped()
    {
        return hasToolEquipped;
    }

    public Tool GetToolEquipped()
    {
        return toolEquipped;
    }

    public void setMoneyAmount(int moneyAmount)
    {
        this.moneyAmount = moneyAmount;
    }

    public void SetItemsSoldForDay(Item[] itemsSoldForDay)
    {
        this.itemsSoldForDay = itemsSoldForDay;
    }

    public void SetHasToolEquipped(bool hasToolEquipped)
    {
        this.hasToolEquipped = hasToolEquipped;
    }

    public void SetToolEquipped(Tool toolEquipped)
    {
        this.toolEquipped = toolEquipped;
    }

}
