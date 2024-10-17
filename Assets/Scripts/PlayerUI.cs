using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{

    public GameObject inventoryMenu;
    public GameObject marketMenu;

    public Button inventoryButton;
    public Button marketButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns if player has a menu open
    public bool IsInMenu()
    {

        if (inventoryMenu.activeInHierarchy || marketMenu.activeInHierarchy)
            return true;

        else
            return false;

    }

    // Returns current menu opened
    public GameObject GetActiveMenu()
    {

        if(inventoryMenu.activeInHierarchy)
            return inventoryMenu;

        else
            return marketMenu;

    }

}
