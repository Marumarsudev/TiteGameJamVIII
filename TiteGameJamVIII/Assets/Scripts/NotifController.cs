using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NotifController : MonoBehaviour
{

    public TextMeshProUGUI inventoryNotif;
    public Transform canvasTransform;

    private List<string> notifStack = new List<string>();

    float nextNotifRate = 0.5f;
    float nextNotifTimer = 0;

    void Start()
    {
        inventoryNotif.gameObject.SetActive(false);
    }

    void Update()
    {
        if(nextNotifTimer >= nextNotifRate && notifStack.Count > 0)
        {
            SendNotif(notifStack[0]);
            notifStack.Remove(notifStack[0]);
        }
        else
        {
            nextNotifTimer += Time.deltaTime;
            if(nextNotifTimer >= nextNotifRate)
                nextNotifTimer = nextNotifRate;
        }
    }

    private void SendNotif(string text)
    {
        nextNotifTimer = 0f;
        TextMeshProUGUI notif = Instantiate(inventoryNotif, inventoryNotif.GetComponent<RectTransform>().position, Quaternion.identity, canvasTransform);
        notif.text = text;
        notif.GetComponent<NotifFade>().Fade();
    }

    public void CreateNotif(string text)
    {
        notifStack.Add(text);
    }
}
