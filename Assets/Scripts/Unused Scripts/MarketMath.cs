using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class MarketMath
{

    private const int MAX_DISCOUNT = 50;
    private const int MAX_VALUE_LOSS = 25;

    public const int VALUE_INC = 1;
    public const int VALUE_DEC = 2;

    public MarketMath()
    {

    }

    public Item CalculateItemDiscount(Item item, bool isDiscounted)
    {

        int normPrice = item.GetItemPrice();

        if(isDiscounted)
        {

            float discount = Random.Range(1, MAX_DISCOUNT) / 100;
            int newPrice = (int)(normPrice * (1 - discount));
            return new Item(item.GetItemName(), item.GetItemType(), newPrice, 
                            item.GetItemValue(), item.GetQuantity());

        }

        else
            return item;

    }

    public Item CalculateYieldValue(PlayerData playerData, Item item, int valueState)
    {

        int normValue = item.GetItemValue();
        int newValue = 0;

        float valuePerc = 0;
        float soldPerc = 0;

        for(int index = 0; index < playerData.GetItemsSoldForDay().Length; index++)
        {

            Item curItem = playerData.GetItemsSoldForDay()[index];

            if(curItem.GetItemName() == item.GetItemName())
            {

                soldPerc = curItem.GetQuantity() / 1000;

                if(soldPerc * 1000 > MAX_VALUE_LOSS)
                    soldPerc = MAX_VALUE_LOSS / 1000;

                break;

            }
            

        }

        switch(valueState)
        {

            case VALUE_INC:
                valuePerc = Random.Range(1, MAX_DISCOUNT) / 100;
                newValue = (int)(normValue * (1 + (valuePerc - soldPerc)));
                return new Item(item.GetItemName(), item.GetItemType(),
                                item.GetItemPrice(), newValue, item.GetQuantity());

            case VALUE_DEC:
                valuePerc = Random.Range(1, MAX_DISCOUNT) / 100;
                newValue = (int)(normValue * (1 - (valuePerc + soldPerc)));
                return new Item(item.GetItemName(), item.GetItemType(),
                                item.GetItemPrice(), newValue, item.GetQuantity());

            default:
                newValue = (int)(normValue * (1 - soldPerc));
                return new Item(item.GetItemName(), item.GetItemType(),
                                item.GetItemPrice(), newValue, item.GetQuantity());

        }

    }

}
