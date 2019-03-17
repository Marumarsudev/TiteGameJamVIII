using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuText : MonoBehaviour
{
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        InvokeRepeating("FlashText", 0f, 0.5f);
    }

    void FlashText()
    {
        text.enabled = !text.enabled;
    }

    void Update()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

}
