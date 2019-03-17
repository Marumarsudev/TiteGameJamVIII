using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Receipe
{
    public Item result;
    public Item[] materials;
    public int[] amount;
}


public class ItemDictionary : MonoBehaviour
{
    public Receipe[] items;
}
