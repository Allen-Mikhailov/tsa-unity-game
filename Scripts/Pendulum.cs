using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pendulum : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool launched = false;
    private float flip = 1;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb.angularVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(launched){
            rb.angularVelocity = flip*(float)Math.Sqrt(-2*(9.8/30)*(1-(float)Math.Cos(rb.rotation*(Math.PI/180)))+(speed*speed));
            if(rb.rotation > 45 && flip == 1){
                rb.rotation = 45;
                flip*=-1;
            }
            if(rb.rotation<-45 && flip == -1){
                rb.rotation = -45;
                flip*=-1;
            }
        }
    }
}
