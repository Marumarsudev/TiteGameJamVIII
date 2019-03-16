using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : InteractableObject
{
    public Item coconut;

    public override void InteractWithObject()
    {
        FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(coconut, 1);
    }
}
