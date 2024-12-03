using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{

    // Class relating to all market functions

    // List containing items for sale
    public List<Item> marketInventory;

    // Reference to player gameobject
    private GameObject player;

    // Reference to PlayerData object
    private PlayerData playerDat;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("Player");

        playerDat = player.GetComponent<PlayerData>();

        marketInventory = new List<Item>();

        for(int item = 0; item < transform.childCount; item++)
            marketInventory.Add(transform.GetChild(item).GetComponent<Item>());

    }
    
    // Method to purchase passed item
    public void PurchaseItem(Item item)
    {

        playerDat.setMoneyAmount(playerDat.getMoneyAmount() - item.itemPrice);
        playerDat.totalMoneySpent += item.itemPrice;
        player.GetComponentInChildren<Seeds>().seedsOwned.Add(item.itemIndex);
        player.GetComponentInChildren<Seeds>().seedsOwned.Sort();

    }

}
