using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flints : InteractableObject
{
    public Item flints;

    private NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void InteractWithObject(Item item)
    {
        if(item != null)
        {
            notif.CreateNotif("Nothing interesting happens.");
        }
        else
        {
            FindObjectOfType<PlayerInventory>().AddItem(flints, 4);
            Destroy(gameObject);
        }
    }
}
