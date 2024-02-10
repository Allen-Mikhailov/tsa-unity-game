using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    private float speed=0;
    private float count = 0;
    void Start()
    {
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void Update()
    {
        speed = Mathf.Tan(count);
        count+=0.01f;
        if(count>1.5){
            count =0;
        }
        rb.velocity = new Vector2(Random.Range(-.5f, .5f), speed*0.5f+(float)Random.Range(0f,0.5f));
        if(gameObject.transform.position.y>50){
            gameObject.transform.Translate(0,-80,0);
        }
    }
}
