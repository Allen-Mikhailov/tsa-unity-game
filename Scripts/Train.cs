using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool launched = true;
    private float speed = 4;
    public float acceleration = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(launched){
            speed += Time.deltaTime * acceleration;
            rb.velocity = new Vector2(speed, 0);
        }
        if(rb.position.x >300){
            launched = false;
            rb.velocity = new Vector2(0,0);
        }
    }
}
