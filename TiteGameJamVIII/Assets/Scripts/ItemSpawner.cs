using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] items;
    public Vector2[] spawnSpots;

    public float itemSpawnRate = 10f;
    private float itemSpawnTime;

    private NotifController notif;

    void Start()
    {
        itemSpawnTime = itemSpawnRate;
        notif = FindObjectOfType<NotifController>();
    }

    void Update()
    {

        itemSpawnTime += Time.deltaTime;

        if (itemSpawnTime >= itemSpawnRate)
        {
            itemSpawnTime = 0;
            if(Random.Range(0f, 1f) > 0.25f)
            {
                Vector2 spawnpos = spawnSpots[Random.Range(0, spawnSpots.Length)];
                if (!Physics2D.CircleCast(spawnpos, 0.5f, Vector2.up, 0))
                {
                    GameObject item = Instantiate(items[Random.Range(0, items.Length)], spawnpos, Quaternion.identity);
                    item.SetActive(true);
                }
                notif.CreateNotif("Something washed ashore.");
            }
        }
    }
}
