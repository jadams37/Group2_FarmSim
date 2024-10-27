using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    ItemData ScriptableObject class.
    This class is used to store the data needed for the creation of items.
    Acts as a subclass of the ScriptableObject class that comes with Unity, rather than a MonoBehavior
    subclass.
    Part of the inventory system.
*/

//CreateAssetMenu used to allow for editing of ItemData within the Unity Editor
[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    //Attribute variables used by all items
    //Each item will have a name and a sprite
    private string name;
    public Sprite icon;
    //TextArea used to expand the item description text box in the editor
    [TextArea]
    //Each item will also have short description to explain to the user what it is
    public string description;
    //Each item will also have a price for buying and selling it
    private float buyPrice;
    private float sellPrice;
    //Each item will also have an ItemAmount
    //This indicates how much of a particular item the player has
    private int itemAmount = 0;

    //Constructor
    public ItemData(string nme, float bP, float sP){
        //Translate parameters into the attributes
        name = nme;
        buyPrice = bP;
        sellPrice = sP;

    }

    //Method to increase the itemAmount by a specified value
    public void IncreaseAmount(int amtIncrease){
        itemAmount += amtIncrease;
    }

    //Getters
    public string GetItemName(){
        return name;
    }
    
    public float GetBuyPrice(){
        return buyPrice;
    }

    public float GetSalePrice(){
        return sellPrice;
    }

    public int GetAmount(){
        return itemAmount;
    }

    //Setters for buy and sale price, and for item amount
    //No setter needed for name
    public void setBuyPrice(float newPrice){
        buyPrice = newPrice;
    }

    public void SetSalePrice(float newSalePrice){
        sellPrice = newSalePrice;
    }

    public void SetItemAmount(int newAmount){
        itemAmount = newAmount;
    }
}
