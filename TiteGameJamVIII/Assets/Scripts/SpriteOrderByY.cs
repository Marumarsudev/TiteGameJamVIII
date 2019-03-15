using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteOrderByY : MonoBehaviour
{

    private SpriteRenderer sprite;

    [SerializeField]
    private int offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sprite.sortingOrder = Mathf.RoundToInt(transform.position.y * 100f) * -1 + offset;
    }
}
