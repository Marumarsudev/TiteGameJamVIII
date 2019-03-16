using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageThirst : ItemInteractions
{
    public int waterAmount = 1;
    public override void Interaction(Item item)
    {
        FindObjectOfType<PlayerController>().water -= waterAmount;
        FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(item, 1);
    }
}
