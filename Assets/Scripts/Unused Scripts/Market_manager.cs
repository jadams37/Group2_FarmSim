using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Market_manager : MonoBehaviour
{
    /// Represents a Market that stores products available for sale, their prices, 
    /// and handles buying and selling of products, as well as paying players after a sale.
    // Start is called before the first frame update
    Dictionary<string, int> products;
    Dictionary<string, float> productPrices;
    float playerMoney { get; set; }
    float totalSales { get; set; }
    bool isActive { get; set; }
    void Start()
    {
        
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void InitializeMarket()
    {
        products["Wheat"] = 100;
        products["Corn"] = 50;
        productPrices["Wheat"] = 2.0f;
        productPrices["Corn"] = 1.5f;
    }
    void display_market_status()
    {
        Debug.Log("Available Products: " + products);
        Debug.Log("Available Prices: " + productPrices);
        Debug.Log("Players Money: " + playerMoney);
    }
    int SellProduct(string productName, int quantity)
    {
        if (isActive)
        {
            if (products.ContainsKey(productName))
            {
                return products[productName];
            }
        }
        return -1;

    }
}
