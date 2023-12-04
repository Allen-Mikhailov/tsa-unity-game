using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Collider2D bottomCollider;
    public Collider2D rightCollider;
    public Collider2D leftCollider;

    public static PlayerMovement plr;

    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpH;
    public bool grounded;
    public float maxSpeed;
    public float airFriction;
    public float jumpCoolDown;
    private float jumpCD;
    private Vector2 jump;
    public float sideJump;
    public float gravity;

    void Start()
    {
        plr = gameObject.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        if (rb.velocity.x >= maxSpeed)
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        else if (rb.velocity.x <= -(maxSpeed))
            rb.velocity = new Vector2(-(maxSpeed), rb.velocity.y);
            
        if (Input.GetAxisRaw("Horizontal") != 0)
        {   
            rb.velocity += new Vector2(moveSpeed * Time.deltaTime * move, 0f);
            // fr = friction + 0.25f;
        }

        bool jumpKey = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        if (jumpKey && jumpCD == 0)
        {
            if (bottomCollider.IsTouchingLayers())
            {
                jump = new Vector2(0f, jumpH);
                rb.AddForce(jump, ForceMode2D.Impulse);
                jumpCD = jumpCoolDown;
            }
            else if (leftCollider.IsTouchingLayers())
            {
                jump = new Vector2(sideJump, (jumpH));
                rb.velocity = jump;
                jumpCD = jumpCoolDown;
            }
            else if (rightCollider.IsTouchingLayers())
            {
                jump = new Vector2(-(sideJump), (jumpH));
                rb.velocity = jump;
                jumpCD = jumpCoolDown;
            }
        }
        gravity = 40;
        jumpCD = Mathf.Max(0, jumpCD-Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") == -1)
        {
            gravity = 60;
        }
        if ((rightCollider.IsTouchingLayers() || leftCollider.IsTouchingLayers()) && rb.velocity.y <= 0)
        {
            if(!bottomCollider.IsTouchingLayers()){
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
            gravity = 3.5f;
            if (Input.GetAxisRaw("Vertical") == -1)
            {
                gravity = 30;
            }
        }
        rb.velocity -= new Vector2(0f, gravity * Time.deltaTime);

        if (!bottomCollider.IsTouchingLayers())
            rb.velocity = new Vector2(rb.velocity.x * airFriction, rb.velocity.y);

    }
}
