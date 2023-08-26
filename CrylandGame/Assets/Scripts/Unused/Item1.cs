using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item1 : GenericItem
{
    public Item1(int Id, string Name, string DescrName, int Amount) : base(Id, Name, DescrName, Amount)
    {
        
    }
    public override void UseItem()
    {
        if(amount <= 0)
        {
            Debug.LogFormat("cannot consume, have only {0} items", amount);
            return;
        }
        Debug.Log("Consumed!");
        amount--;
    }
}
