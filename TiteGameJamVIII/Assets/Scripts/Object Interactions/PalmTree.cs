using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : InteractableObject
{
    public Item coconut;

    public Item rock;

    public Item bark;

    public override void InteractWithObject(Item item)
    {
        if(item != null)
        {
            if (item == rock)
            {
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(bark, 1);
            }
        }
        else
        {
            FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(coconut, 1);
        }
    }
}
