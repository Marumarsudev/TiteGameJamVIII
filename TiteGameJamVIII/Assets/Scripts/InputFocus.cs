using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFocus : MonoBehaviour
{
    public PlayerController player;
    public PlayerInventory inventory;

    void Start()
    {
        player.hasInputFocus = true;
    }

    void Update()
    {
        if (InputManager.GetInventoryDown() && !inventory.hasInputFocus)
        {

            Debug.Log("INV open");
            player.hasInputFocus = false;
            inventory.hasInputFocus = true;
            inventory.OpenInventory();
        }
        else if (InputManager.GetInventoryDown())
        {
            Debug.Log("INV close");
            inventory.hasInputFocus = false;
            player.hasInputFocus = true;
            inventory.CloseInventory();
        }
    }
}
