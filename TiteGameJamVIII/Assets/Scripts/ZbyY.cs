using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZbyY : MonoBehaviour
{
    private Transform stransform;

    [SerializeField]
    private int offset = 0;

    // Start is called before the first frame update
    void Start()
    {
        stransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        stransform.SetPositionAndRotation(new Vector3(stransform.position.x, stransform.position.y, stransform.position.y + offset), Quaternion.identity);
    }
}
