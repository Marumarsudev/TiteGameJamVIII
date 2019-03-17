using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmTree : InteractableObject
{
    public Item coconut;

    public Item rock;

    public Item bark;

    public Item sticks;

    private NotifController notif;

    private int coconuts = 4;

    private float coconutSpawnRate = 8f;
    private float coconutTimer = 0;

    public AudioClip[] hitclips;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    void Update()
    {
        if(Random.Range(0f, 1f) > 0.5f && coconuts < 4 && coconutTimer >= coconutSpawnRate)
        {
            coconutTimer = 0f;
            notif.CreateNotif("A coconut appears in the palm tree.");
            coconuts++;
            if(coconuts >= 4)
                coconuts = 4;
        }
        else
        {
            coconutTimer += Time.deltaTime;
        }
    }

    public override void InteractWithObject(Item item)
    {
        if(item != null)
        {
            if (item == rock)
            {
                audioSource.PlayOneShot(hitclips[Random.Range(0, hitclips.Length)]);
                bool gotSomething = false;
                if(Random.Range(0f, 1f) > 0.8f)
                {
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(bark, 1);
                    gotSomething = true;
                }

                if(Random.Range(0f, 1f) > 0.5f)
                {
                    FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(sticks, 1);
                    gotSomething = true;
                }
                if (!gotSomething)
                    notif.CreateNotif("You failed to collect anything useful.");
            }
            else
            {
                notif.CreateNotif("Nothing interesting happens.");
            }
        }
        else
        {
            if(Random.Range(0f, 1f) > 0.6f && coconuts > 0)
            {
                FindObjectOfType<PlayerInventory>().GetComponent<PlayerInventory>().AddItem(coconut, 1);
                coconuts--;
            }
            else if(coconuts == 0)
            {
                notif.CreateNotif("There are no more coconuts in the palm tree.");
            }
            else
            {
                notif.CreateNotif("You failed to get a coconut to fall.");
            }
        }
    }
}
