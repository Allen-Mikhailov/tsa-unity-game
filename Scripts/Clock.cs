using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool launched = false;
    private float flip = 1;
    public float speed;
    public float HitForce = 10;
    public float limit = 50;

    public ColExpo ball;

    // Start is called before the first frame update
    void Start()
    {
        rb.angularVelocity = 0;

        ball.CollisionEnter += (Collision2D c) => {
            if (c.collider == PlayerMovement.plr.mainCollider)
            {
                Rigidbody2D rigid = PlayerMovement.plr.GetComponent<Rigidbody2D>();
                Vector3 dif = PlayerMovement.plr.transform.position - ball.transform.position;
                float angle = MathF.Atan2(dif.y, dif.x);
                Vector2 force = new Vector2(
                    HitForce * MathF.Cos(angle),
                    HitForce * MathF.Sin(angle)
                    );
                rigid.AddForce(force);
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(launched){
            rb.angularVelocity = flip*(float)Math.Sqrt(-2*(9.8/30)*(1-(float)Math.Cos(rb.rotation*(Math.PI/180)))+(speed*speed));
            if(rb.rotation > 45 && flip == 1){
                rb.rotation = 45;
                flip*=-1;
                speed+=2;
            }
            if(rb.rotation<-45 && flip == -1){
                rb.rotation = -45;
                flip*=-1;
                speed+=2;
            }
        }
        if(speed >=limit){
            launched = false;
            rb.angularVelocity = 0;
            rb.rotation = -45;
        }
    }
}
