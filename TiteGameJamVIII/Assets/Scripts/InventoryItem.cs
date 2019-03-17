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
        UpdateGUI(false, false);
    }

    public void UpdateGUI(bool isActive, bool selectedCrafting)
    {
        image.sprite = item.image;
        if(isActive && selectedCrafting)
        {
            bg.color = Color.cyan;
        }
        else if(isActive)
        {
            bg.color = Color.green;
        }
        else if (selectedCrafting)
        {
            bg.color = Color.yellow;
        }
        else
        {
            bg.color = Color.white;
        }
        text.text = amount.ToString() + " x " + item.itemname.ToString();
    }

    public void UseItem()
    {
        FindObjectOfType<PlayerController>().UseItem(item);
        FindObjectOfType<InputFocus>().CloseInventory();
    }

    public void InteractWithItem()
    {
        item.interactions.ForEach(interaction => {
            interaction.Interaction(item);
        });
    }
}
