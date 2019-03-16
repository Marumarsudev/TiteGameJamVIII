using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakCoconut : ItemInteractions
{
    public Item halfCoconut;
    private PlayerInventory playerInventory;

    private NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void Interaction(Item item)
    {
        if(Random.Range(0f, 1f) > 0.7f)
        {
            playerInventory = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
            playerInventory.AddItem(halfCoconut, 2);
            playerInventory.RemoveItem(item, 1);
        }
        else
        {
            if(notif == null)
                notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
            notif.CreateNotif("You failed to break the coconut.");
        }
    }
}
