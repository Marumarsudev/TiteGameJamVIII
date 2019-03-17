using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Boat : InteractableObject
{

    NotifController notif;

    void Start()
    {
        notif = FindObjectOfType<NotifController>().GetComponent<NotifController>();
    }

    public override void InteractWithObject(Item item)
    {
        if(item != null)
        {
            notif.CreateNotif("Why would you do that? This is your way to escape.");
        }
        else
        {
            DOTween.KillAll();
            SceneManager.LoadScene("Survived");
        }
    }
}
