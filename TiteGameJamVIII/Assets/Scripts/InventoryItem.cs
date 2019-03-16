using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryItem : MonoBehaviour
{
    public Item item;
    public int amount;

    public Image bg;
    public Image image;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateGUI(false);
    }

    public void UpdateGUI(bool isActive)
    {
        image.sprite = item.image;
        if(isActive)
        {
            bg.color = Color.green;
        }
        else
        {
            bg.color = Color.white;
        }
        text.text = amount.ToString() + " x " + item.itemname.ToString();
    }

    public void InteractWithItem()
    {
        item.interactions.ForEach(interaction => {
            interaction.Interaction(item);
        });
    }
}
