using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : InteractableObject
{
    public Item rawFish;

    private NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void InteractWithObject(Item item)
    {
        if (item == null)
        {
            if(Random.Range(0f, 1f) > 0.6f)
            {
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(rawFish, 1);
            }
            else
            {
                notif.CreateNotif("You failed to catch fish.");
            }
        }
        else
        {
            notif.CreateNotif("Nothing interesting happened.");
        }
    }
}
