using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{

    private Market market;

    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemCostText;
    public Image itemSprite;

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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PurchaseItem()
    {

        market.PurchaseItem(itemData);

    }

}
