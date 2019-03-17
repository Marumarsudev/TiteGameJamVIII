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

    public void CloseInventory()
    {
        inventory.hasInputFocus = false;
        player.hasInputFocus = true;
        inventory.CloseInventory();
    }

    public void OpenInventory()
    {
        player.hasInputFocus = false;
        inventory.hasInputFocus = true;
        inventory.OpenInventory();
    }

    void Update()
    {
        if (InputManager.GetInventoryDown() && !inventory.hasInputFocus && !player.isAsleep)
        {
            OpenInventory();
        }
        else if (InputManager.GetInventoryDown() || Input.GetKeyDown(KeyCode.Escape))
        {
            CloseInventory();
        }
    }
}
