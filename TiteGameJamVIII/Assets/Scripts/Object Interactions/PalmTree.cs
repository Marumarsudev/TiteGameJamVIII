using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : InteractableObject
{
    public Item coconut;

    public Item rock;

    public Item bark;

    public NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void InteractWithObject(Item item)
    {
        if(item != null)
        {
            if (item == rock)
            {
                if(Random.Range(0f, 1f) > 0.4f)
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(bark, 1);
                else
                    notif.CreateNotif("You failed to collect bark.");
            }
        }
        else
        {
            if(Random.Range(0f, 1f) > 0.6f)
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(coconut, 1);
            else
                notif.CreateNotif("You failed to get a coconut to fall.");
        }
    }
}
