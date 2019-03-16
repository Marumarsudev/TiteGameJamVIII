using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifController : MonoBehaviour
{

    public TextMeshProUGUI inventoryNotif;
    public Transform canvasTransform;

    void Start()
    {
        inventoryNotif.gameObject.SetActive(false);
    }

    public void CreateNotif(string text)
    {
        TextMeshProUGUI notif = Instantiate(inventoryNotif, inventoryNotif.GetComponent<RectTransform>().position, Quaternion.identity, canvasTransform);
        notif.text = text;
        notif.GetComponent<NotifFade>().Fade();
    }
}
