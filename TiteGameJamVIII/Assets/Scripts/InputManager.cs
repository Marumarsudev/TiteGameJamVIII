using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool GetInteract() => Input.GetKeyDown(KeyCode.Space);
    public static bool GetInteractDown() => Input.GetKeyDown(KeyCode.Space);
    public static bool GetInteractUp() => Input.GetKeyUp(KeyCode.Space);

    public static bool GetInventory() => Input.GetKeyDown(KeyCode.I);
    public static bool GetInventoryDown() => Input.GetKeyDown(KeyCode.I);
    public static bool GetInventoryUp() => Input.GetKeyUp(KeyCode.I);

    public static bool GetDirUpDown() => Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
    public static bool GetDirDownDown() => Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);

    public static Vector2 GetMovement()
    {
        Vector2 movement = new Vector2();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement = movement.normalized;

        return movement;
    }
}
