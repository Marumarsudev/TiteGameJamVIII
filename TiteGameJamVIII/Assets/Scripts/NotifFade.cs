using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class NotifFade : MonoBehaviour
{
    
    private TextMeshProUGUI notif;

    public void Fade()
    {
        notif = GetComponent<TextMeshProUGUI>();
        Vector3 origPos = notif.GetComponent<RectTransform>().position;
        gameObject.SetActive(true);
        DOTween.To(() => notif.GetComponent<RectTransform>().position, x => notif.GetComponent<RectTransform>().position = x, new Vector3(origPos.x, origPos.y - 300, origPos.z), 3f).OnComplete(() => {Destroy(gameObject);});
        notif.DOFade(0f, 0.2f).SetDelay(1.5f);
    }
}
