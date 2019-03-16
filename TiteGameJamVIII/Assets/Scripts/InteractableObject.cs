﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string objectname;

    public virtual void InteractWithObject()
    {
        Debug.Log("Interacted with " + objectname.ToString());
    }
}
