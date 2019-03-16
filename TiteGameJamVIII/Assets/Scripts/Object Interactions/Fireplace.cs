using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : InteractableObject
{
    public Item rawFish;
    public Item cookedFish;

    public Item bark;

    public float barkAmount = 0f;

    public bool isBurning = false;

    public Light fireLight;
    public SpriteRenderer fireSprite;

    private NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
        fireLight.enabled = false;
        fireSprite.enabled = false;
    }

    void Update()
    {
        if(isBurning && barkAmount > 0)
        {
            barkAmount -= Time.deltaTime;
        }
        else if(barkAmount <= 0)
        {
            barkAmount = 0;
            isBurning = false;
            fireLight.enabled = false;
            fireSprite.enabled = false;
        }
    }

    public override void InteractWithObject(Item item)
    {
        if(isBurning && item == null)
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
        else if ((barkAmount == 0 && item == null) || item == bark)
        {
            bool hasBark = false;
            hasBark = FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().SearchItem(bark, 1);

            if(hasBark)
            {
                barkAmount += 30f;
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(bark, 1);
                notif.CreateNotif("You add bark to the fireplace.");
            }
        }
        else if (!isBurning && item == null)
        {
            if(Random.Range(0f, 1f) > 0.3f)
            {
                isBurning = true;
                fireLight.enabled = true;
                fireSprite.enabled = true;
                notif.CreateNotif("You light a fire.");
            }
            else
            {
                notif.CreateNotif("You failed to light a fire.");
            }
        }
        else
        {
            notif.CreateNotif("Nothing interesting happened.");
        }
    }
}
