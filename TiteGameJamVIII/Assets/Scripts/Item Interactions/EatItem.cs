using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatItem : ItemInteractions
{
    public int feedAmount = 1;
    public override void Interaction(Item item)
    {
        FindObjectOfType<PlayerController>().hunger += feedAmount;
        FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(item, 1);
    }
}
