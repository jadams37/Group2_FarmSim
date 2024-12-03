using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{

    // String variables for item's name and type
    public string itemName;
    public string itemType;

    // Int variables for item's price, value, and quantity
    public int itemPrice;
    public int itemValue;
    public int quantity;

    // Reference to sprite of item
    public Sprite itemSprite;

    // Index of item
    public int itemIndex;

    // Constructor that was to be used by MarketMath
    public Item(string itemName, string itemType, int itemPrice, int itemValue, int quantity)
    {

        this.itemName = itemName;
        this.itemType = itemType;
        this.itemPrice = itemPrice;
        this.itemValue = itemValue;
        this.quantity = quantity;

    }

    // Getters and Setters
    public string GetItemName()
    {
        return itemName;
    }

    public string GetItemType()
    {
        return itemType;
    }

    public int GetItemPrice()
    {
        return itemPrice;
    }

    public int GetItemValue()
    {
        return itemValue;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public void SetItemName(string itemName)
    {
        this.itemName = itemName;
    }

    public void SetItemType(string itemType)
    {
        this.itemType = itemType;
    }

    public void SetItemPrice(int itemPrice)
    {
        this.itemPrice = itemPrice;
    }

    public void SetItemValue(int itemValue)
    {
        this.itemValue = itemValue;
    }

    public void SetQuantity(int quantity)
    {
        this.quantity = quantity;
    }

}
