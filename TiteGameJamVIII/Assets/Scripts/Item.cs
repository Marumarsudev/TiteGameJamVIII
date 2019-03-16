using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemname;
    public bool stackable;
    public Sprite image;
    public List<ItemInteractions> interactions = new List<ItemInteractions>();
}
