using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : InteractableObject
{
    public Item rock;

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
            FindObjectOfType<PlayerInventory>().AddItem(rock, 1);
            Destroy(gameObject);
        }
    }
}
