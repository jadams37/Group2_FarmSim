using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item: MonoBehaviour
{

    public string itemName;
    public string itemType;

    public int itemPrice;
    public int itemValue;

    public int quantity;

    public Sprite itemSprite;

    public int itemIndex;

    public Item(string itemName, string itemType, int itemPrice, int itemValue, int quantity)
    {

        this.itemName = itemName;
        this.itemType = itemType;
        this.itemPrice = itemPrice;
        this.itemValue = itemValue;
        this.quantity = quantity;

    }

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
