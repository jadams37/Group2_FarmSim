using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Redone
{
    private List<Item_Redone> inventoryList;

    public Inventory_Redone()
    {
        inventoryList = new List<Item_Redone>();
        AddItem(new Item_Redone{itemType = Item_Redone.ItemType.Corn, amount = 1});
        Debug.Log(inventoryList.Count);
    }

    public void AddItem(Item_Redone item)
    {
        inventoryList.Add(item);
    }
}
