using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Class used to create instances of items for use in th game.
    Relies on the ScriptableObject class ItemData to work.
    Part of the inventory system.
*/

[System.Serializable]
public class ItemInstances
{
    //Attribute Variables
    //Each item will have an item type that includes it's name and description
    //Each item will also have a buying and selling price
    private ItemData itemType;
    private float bPrice;
    private float sPrice;

    //Constructor
    //Requires the data for the item to exist as an ItemData object
    public ItemInstances (ItemData itemData){
        itemType = itemData;
        bPrice = itemData.GetBuyPrice();
        sPrice = itemData.GetSalePrice();
    }

    //Getters
    public ItemData GetItemType(){
        return itemType;
    }
    
    public float GetBuyPrice(){
        return bPrice;
    }

    public float GetSalePrice(){
        return sPrice;
    }

    //Setters for buy and sale price
    //No setter needed for itemType
    public void setBuyPrice(float newPrice){
        bPrice = newPrice;
    }

    public void SetSalePrice(float newSalePrice){
        sPrice = newSalePrice;
    }
}
