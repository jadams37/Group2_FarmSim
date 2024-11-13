using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int moneyAmount;

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

    public Item[] GetItemsSoldForDay()
    {
        return itemsSoldForDay;
    }

    public void SetItemsSoldForDay(Item[] itemsSoldForDay)
    {
        this.itemsSoldForDay = itemsSoldForDay;
    }

}
