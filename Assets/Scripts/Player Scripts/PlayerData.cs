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

    public int totalMoneySpent;

    public int highestMoney;

    public float playTime;

    // Start is called before the first frame update
    void Start()
    {

        inventory = new Inventory_Redone();

        toolEquipped = null;

        playTime = 0;

        highestMoney = moneyAmount;

    }

    // Update is called once per frame
    void Update()
    {

        SetPlayTime();
        SetHighestMoney();

    }

    private void SetPlayTime()
    {

        playTime += Time.unscaledDeltaTime;

    }

    private void SetHighestMoney()
    {

        if(moneyAmount > highestMoney)
            highestMoney = moneyAmount;

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
