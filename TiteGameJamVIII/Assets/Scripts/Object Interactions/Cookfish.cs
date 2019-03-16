using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cookfish : InteractableObject
{
    public Item rawFish;
    public Item cookedFish;

    public override void InteractWithObject()
    {
        bool canCook = false;
        canCook = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().SearchItem(rawFish, 1);

        Debug.Log(canCook);

        if(canCook)
        {
            FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(cookedFish, 1);
            FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(rawFish, 1);
        }
    }
}
