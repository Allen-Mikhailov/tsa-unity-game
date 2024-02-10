using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bobo : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 pos;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = pos + new Vector3(0, Mathf.Sin(Time.timeSinceLevelLoad)*1, 0);
    }
}
