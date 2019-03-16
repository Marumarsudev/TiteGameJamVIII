using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : InteractableObject
{
    public Item rawFish;

    public override void InteractWithObject()
    {
        FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(rawFish, 1);
    }
}
