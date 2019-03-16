using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCoconut : ItemInteractions
{
    public Item halfCoconut;
    private PlayerInventory playerInventory;
    public override void Interaction(Item item)
    {
        playerInventory = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
        playerInventory.AddItem(halfCoconut, 2);
        playerInventory.RemoveItem(item, 1);
    }
}
