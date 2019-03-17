using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireplace : InteractableObject
{
    public Item rawFish;
    public Item cookedFish;
    public Item burnedFish;


    public Item bark;

    public Item shirt;

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
                if(Random.Range(0f, 1f) > 0.95f)
                {
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(burnedFish, 1);
                }
                else
                {
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(cookedFish, 1);
                }
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
        else if (isBurning && item == shirt)
        {
            notif.CreateNotif("The shirt burns, what did you expect?");
            FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().RemoveItem(shirt, 1);
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
