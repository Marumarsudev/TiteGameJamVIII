﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static bool GetInteract() => Input.GetKeyDown(KeyCode.E);
    public static bool GetInteractDown() => Input.GetKeyDown(KeyCode.E);
    public static bool GetInteractUp() => Input.GetKeyUp(KeyCode.E);

    public static Vector2 GetMovement()
    {
        Vector2 movement = new Vector2();
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        movement = movement.normalized;

        return movement;
    }
}