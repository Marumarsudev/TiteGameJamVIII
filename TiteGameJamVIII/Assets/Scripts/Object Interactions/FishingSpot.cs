using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingSpot : InteractableObject
{
    public Item rawFish;

    private NotifController notif;

    public Item harpoon;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void InteractWithObject(Item item)
    {
        if (item == harpoon)
        {
            if(Random.Range(0f, 1f) > 0.3f)
            {
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(rawFish, 1);
                if(Random.Range(0f, 1f) >= 0.95f)
                {
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(harpoon, 1);
                    notif.CreateNotif("Your harpoon broke!");
                }
            }
            else
            {
                notif.CreateNotif("You failed to catch fish.");
            }
        }
        else if (item != null)
        {
            notif.CreateNotif("Nothing interesting happened.");
        }
        else
        {
            notif.CreateNotif("You can't catch anything barehanded.");
        }
    }
}
