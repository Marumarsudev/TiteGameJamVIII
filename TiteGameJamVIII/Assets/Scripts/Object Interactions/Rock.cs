using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : InteractableObject
{
    public Item rock;

    public override void InteractWithObject(Item item)
    {
        FindObjectOfType<PlayerInventory>().AddItem(rock, 1);
        Destroy(gameObject);
    }
}
