using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

    private string itemName;
    private string itemType;

    private int itemPrice;
    private int itemValue;

    private int quantity;

    private bool isSellable;

    public Item(string itemName, string itemType, int itemPrice, int itemValue, int quantity, bool isSellable)
    {

        this.itemName = itemName;
        this.itemType = itemType;
        this.itemPrice = itemPrice;
        this.itemValue = itemValue;
        this.quantity = quantity;
        this.isSellable = isSellable;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public bool GetIsSellable()
    {
        return isSellable;
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

    public void SetIsSellable(bool isSellable)
    {
         this.isSellable = isSellable;
    }

}
