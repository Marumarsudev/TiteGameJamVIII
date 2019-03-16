using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbyY : MonoBehaviour
{
    private Transform transform;

    [SerializeField]
    private int offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, transform.position.y, transform.position.y + offset), Quaternion.identity);
    }
}
