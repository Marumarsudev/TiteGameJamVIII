using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    private int previous = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<SpriteRenderer>().enabled = false;
            child.GetComponent<Collider2D>().enabled = false;
        }
        InvokeRepeating("ChangeFishSpot", 0f, 5f);
    }

    private void ChangeFishSpot()
    {
        int rand = Random.Range(0, 4);
        int i = 0;
        foreach(Transform child in transform)
        {
            if (rand == i)
            {
                child.GetComponent<SpriteRenderer>().enabled = true;
                child.GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                child.GetComponent<SpriteRenderer>().enabled = false;
                child.GetComponent<Collider2D>().enabled = false;
            }
            i++;
        }
        previous = rand;
    }
}
