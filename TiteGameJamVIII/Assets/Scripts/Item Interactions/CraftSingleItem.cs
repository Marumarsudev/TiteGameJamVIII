using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSingleItem : ItemInteractions
{
    public Item receiveItem;
    public int amount;
    public float successChance = 0f;
    private PlayerInventory playerInventory;

    public string failNotifMsg;
    private NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void Interaction(Item item)
    {
        if(Random.Range(0f, 1f) >= successChance)
        {
            playerInventory = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>();
            playerInventory.AddItem(receiveItem, amount);
            playerInventory.RemoveItem(item, 1);
        }
        else
        {
            if(notif == null)
                notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
            notif.CreateNotif(failNotifMsg);
        }
    }
}
