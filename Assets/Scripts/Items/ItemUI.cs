using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    // Class relating to item display functions

    // Reference to Market object
    private Market market;

    // Reference to item name and cost texts
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemCostText;

    // Reference to sprite of item
    public Image itemSprite;

    // Reference to Item object
    private Item itemData;

    // Start is called before the first frame update
    void Start()
    {

        market = GameObject.Find("MarketMenu").GetComponent<Market>();

        itemData = transform.GetComponent<Item>();
        itemNameText.SetText(itemData.itemName);
        itemCostText.SetText("$" + itemData.itemPrice.ToString());
        itemSprite.sprite = itemData.itemSprite;


    }

    // Method to purchase item
    public void PurchaseItem()
    {

        market.PurchaseItem(itemData);

    }

}
