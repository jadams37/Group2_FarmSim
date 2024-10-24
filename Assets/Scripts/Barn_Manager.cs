using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Barn_Manager : MonoBehaviour
{
    /// Class Summary
    /// Thus class basically tracks stored harvests and their quantities.
    /// The Barn has a maximum storage capacity that can be upgraded based on its level. <summary>

    int barn_level { get; set; }
    int max_storage { get; set; }
    int curr_storage { get; set; }
    int hervest_type { get; set; }
    int upgrade_cost { get; set; }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void upgrade_barn(int level)
    {
        level++;
        max_storage = level * 50;
        upgrade_cost = level * 100;
    }
    void sell_item(int plant_type)
    {
        if (curr_storage < 0)
        {
            Debug.Log("Empty Inventory");
        }
    }
    void display_barn_status()
    {
        Debug.Log("Barn Level:" +barn_level);
        Debug.Log("Storage:"+ curr_storage);
        Debug.Log("Max Storage:" +max_storage);
        Debug.Log("Upgrade Cost:"+ upgrade_cost);
    }
}
