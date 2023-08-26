using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventorySystem : MonoBehaviour
{
    [SerializeField]
    Image[] img;

    GenericItem item;

    GenericItem[] slots;
    int activeSlot = 0;

    private void Start()
    {
        slots = new GenericItem[28];
        Debug.LogFormat("the slots have been made theres {0} slots", slots.Length);

        item = new Item1(1, "Poop", "The stinky poop", 2);
        slots[0] = item;
        foreach(GenericItem item in slots)
        {
            if(item?.amount >= 0)
            {
                img[activeSlot].color = Color.red;
            }
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(slots[activeSlot] == null)
            {
                Debug.Log("the given slot contains no items");
                return;
            }
            slots[activeSlot].UseItem();
            img[activeSlot].color = Color.red;
            if (slots[activeSlot].amount <= 0)
            {
                img[activeSlot].color = Color.white;
                slots[activeSlot] = null;
            }
            
        }
    }
}
