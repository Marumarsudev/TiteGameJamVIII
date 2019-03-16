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
        // notif.alpha = 0f;
        notif.DOFade(0f, 0f);
        notif.DOFade(1f, 0.2f);
        DOTween.To(() => notif.GetComponent<RectTransform>().position, x => notif.GetComponent<RectTransform>().position = x, new Vector3(origPos.x, origPos.y - 300, origPos.z), 0.7f).SetDelay(0.5f);
        notif.DOFade(0f, 0.2f).SetDelay(0.7f).OnComplete(() => {Destroy(gameObject);});
    }
}
