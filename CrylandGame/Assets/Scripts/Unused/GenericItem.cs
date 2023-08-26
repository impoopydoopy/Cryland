using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericItem
{
    protected int id;
    protected string itemName;
    protected string itemDescription;
    protected bool isSelected;

    protected bool isUsable;
    public int amount;
    public GenericItem(int Id = -1, string ItemName = "", string ItemDescription = "", int Amount = 0)
    {
        id = Id;
        itemName = ItemName;
        itemDescription = ItemDescription;
        amount = Amount;
        isSelected = false;
    }
    public virtual void UseItem()
    {
        // override with functionality
    }
}
