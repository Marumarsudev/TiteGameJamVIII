using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : InteractableObject
{
    public Item rawFish;

    public override void InteractWithObject(Item item)
    {
        FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(rawFish, 1);
    }
}
