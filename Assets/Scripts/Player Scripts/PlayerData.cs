using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int moneyAmount = 0;

    private Item[] itemsSoldForDay;

    private Inventory_Redone inventory;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new Inventory_Redone();
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

    public void setMoneyAmount(int moneyAmount)
    {
        this.moneyAmount = moneyAmount;
    }

    public void SetItemsSoldForDay(Item[] itemsSoldForDay)
    {
        this.itemsSoldForDay = itemsSoldForDay;
    }

}
