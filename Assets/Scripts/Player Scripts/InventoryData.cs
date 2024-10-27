using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    InventoryData ScriptableObject class.
    This class is used to store the data for the player's inventory.
    Relies on the use of a List object and the ItemData ScriptableObject.
*/

//CreateAssetMenu used to allow editing of the object within the Unity Editor
[CreateAssetMenu]
public class InventoryData : ScriptableObject
{
    //Create a List object to store the items purchased by the player
    public List<ItemData> InventoryList = new();

    //Simple constructor
    public InventoryData(){

    }

    //Add item method
    //Takes an ItemData object and adds it to the inventory list or updates the item amount
    public void AddInventoryItem(ItemData item){
        if(!InventoryList.Contains(item)){
            //Add the new item to the list
            item.IncreaseAmount(1);
            InventoryList.Add(item);
        }
        else{
            //Get the info for the item in the list
            ItemData oldItem = item;//InventoryList.Find(item);
            //Increase the item amount
            int increment = oldItem.GetAmount();
            item.IncreaseAmount(increment);
            //Replace the old item with the new item
            InventoryList.Remove(oldItem);
            InventoryList.Add(item);
        }
        
    }
}
