using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour
{

    public List<Item> marketInventory;

    private GameObject player;

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

    // Update is called once per frame
    void Update()
    {

    }

    public void PurchaseItem(Item item)
    {

        if(!player.GetComponentInChildren<Seeds>().seedsOwned.Contains(item.itemIndex))
        {

            playerDat.setMoneyAmount(playerDat.getMoneyAmount() - item.itemPrice);
            player.GetComponentInChildren<Seeds>().seedsOwned.Add(item.itemIndex);

        }

        else
            Debug.Log("Item owned already");

    }

    public void SellYield()
    {



    }

}
