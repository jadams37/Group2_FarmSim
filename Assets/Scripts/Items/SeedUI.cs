using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedUI : MonoBehaviour
{

    private Seeds seeds;

    public TextMeshProUGUI itemNameText;

    public Image itemSprite;

    private Item itemData;

    // Start is called before the first frame update
    void Start()
    {

        seeds = GameObject.Find("Player").GetComponentInChildren<Seeds>();

        itemData = transform.GetComponent<Item>();
        itemNameText.SetText(itemData.itemName);

        itemSprite.sprite = itemData.itemSprite;


    }

    // Update is called once per frame
    void Update()
    {

        if(!seeds.seedsOwned.Contains(itemData.itemIndex))
        {

            itemNameText.color = Color.red;

        }

        else
        {

            itemNameText.color = Color.green;

        }

    }

    public void EquipSeed()
    {

        if(seeds.seedsOwned.Contains(itemData.itemIndex))
            seeds.seedEquipped = itemData.itemIndex;

        else
            Debug.Log("Out of " + itemData.itemName + " seeds");

    }

}
