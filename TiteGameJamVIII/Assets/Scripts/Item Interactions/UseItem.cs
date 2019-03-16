using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : ItemInteractions
{
    public override void Interaction(Item item)
    {
        FindObjectOfType<PlayerController>().UseItem(item);
        FindObjectOfType<InputFocus>().CloseInventory();
    }
}
