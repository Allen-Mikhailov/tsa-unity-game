using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    public bool activated = false;
    public Rigidbody2D rb;
    public Camera cam;
    public Rigidbody2D player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activated){
            Debug.Log(rb.transform.position);
            rb.angularVelocity = -5;
        }
        if(activated && rb.rotation<=0){
            rb.rotation = 0;
            activated = false;
            rb.angularVelocity=0;
        }
    }
}
