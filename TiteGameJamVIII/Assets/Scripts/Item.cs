using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item : MonoBehaviour
{
    public string itemname;
    public string usedescription;
    public bool stackable;
    public Sprite image;
    public List<ItemInteractions> interactions = new List<ItemInteractions>();
}
