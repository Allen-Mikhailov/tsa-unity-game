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
    public Collider2D mainCollider;

    private GameObject cam;
    public GameObject camBox;

    public Rect camRect;

    public static PlayerMovement plr;

    public ParticleSystem deathParticles;

    public CheckPoint checkPoint;

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

    public bool inDeathAnim = false;
    public Vector3 deathPos;

    private GameObject floor;

    private Quaternion targetRot;

    void Start()
    {
        plr = gameObject.GetComponent<PlayerMovement>();

        ColExpo bottom = bottomCollider.GetComponent<ColExpo>();
        bottom.TriggerEnter += (Collider2D col) => {floor = col.gameObject;};
        bottom.TriggerExit += (Collider2D col) => {floor = col.gameObject==floor?null:floor;};

        Camera camera = Camera.main;
        cam = camera.gameObject;

        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        Vector3 boxPos = camBox.transform.position;
        Vector3 boxScale = camBox.transform.localScale;

        camRect = Rect.zero;
        camRect.xMin = boxPos.x + halfWidth  - boxScale.x/2;
        camRect.xMax = boxPos.x - halfWidth  + boxScale.x/2;
        camRect.yMin = boxPos.y + halfHeight - boxScale.y/2;
        camRect.yMax = boxPos.y - halfHeight + boxScale.y/2;
    }

    IEnumerator KillAnim()
    {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();

        deathPos = transform.position;

        deathParticles.Emit(30);
        sprite.enabled = false;
        inDeathAnim = true;

        yield return new WaitForSeconds(2);

        transform.position = checkPoint.gameObject.transform.position;
        sprite.enabled = true;
        inDeathAnim = false;
    }

    public void Kill()
    {
        if (inDeathAnim) return;
        StartCoroutine(KillAnim());
    }

    // Update is called once per frame
    void Update()
    {
        if (inDeathAnim)
        {
            transform.position = deathPos;
            return;
        }

        float move = Input.GetAxisRaw("Horizontal");
        if (move != 0)
        {   
            rb.velocity = new Vector2(
                Mathf.Clamp(rb.velocity.x + moveSpeed * Time.deltaTime * move, -maxSpeed, maxSpeed), 
                rb.velocity.y
            );
            // fr = friction + 0.25f;
        }

        rb.velocity = new Vector2(rb.velocity.x * airFriction, rb.velocity.y);

        bool jumpKey = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W);
        if (jumpKey && jumpCD == 0)
        {
            if (bottomCollider.IsTouchingLayers())
            {
                float multi = 1;
                if (floor && floor.GetComponent<Bounce>())
                    multi = floor.GetComponent<Bounce>().bouce;

                jump = new Vector2(0f, jumpH*multi);
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

        

        cam.transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, camRect.xMin, camRect.xMax),
            Mathf.Clamp(transform.position.y, camRect.yMin, camRect.yMax),
            cam.transform.position.z
        );

        if (floor)
        {
            targetRot =  floor.transform.rotation;
        } else {
            targetRot = Quaternion.identity;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, .3f);
    }
}
