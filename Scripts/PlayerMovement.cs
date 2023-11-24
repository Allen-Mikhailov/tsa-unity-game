using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Collider2D bottomCollider;
    public Collider2D rightCollider;
    public Collider2D leftCollider;

    public Rigidbody2D rbody;

    Vector2 rightWallJump = new Vector2(-5, 5);
    Vector2 leftWallJump = new Vector2(5, 5);
    Vector2 floorJump = new Vector2(0, 5);

    public float maxXVelocity = 7;
    public float XAcceleration = 200;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void setVX(float x)
    {
        rbody.velocity = new Vector2(x, rbody.velocity.y);
    }

    void setVY(float y)
    {
        rbody.velocity = new Vector2(rbody.velocity.x, y);
    }

    // Update is called once per frame
    void Update()
    {
        setVX(Mathf.Clamp(rbody.velocity.x + Input.GetAxis("Horizontal")*XAcceleration*Time.deltaTime, -maxXVelocity, maxXVelocity));
        // setVX(Input.GetAxis("Horizontal")*XAcceleration);

        if (rightCollider.IsTouchingLayers())
        {setVX(Mathf.Min(rbody.velocity.x, 0));}

        if (leftCollider.IsTouchingLayers())
        {setVX(Mathf.Max(rbody.velocity.x, 0));}

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            if (rightCollider.IsTouchingLayers())
            {
                // rbody.AddForce(rightWallJump);
                rbody.velocity = rightWallJump;
            } else if (leftCollider.IsTouchingLayers()) {
                // rbody.AddForce(leftWallJump);
                rbody.velocity = rightWallJump;
            } else if (bottomCollider.IsTouchingLayers()) {
                Debug.Log("jump");
                // rbody.AddForce(floorJump);
                setVY(5);
            }
        }
    }
}
