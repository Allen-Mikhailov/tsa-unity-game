using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called before the first frame update
    BoxCollider2D col;
    void Start()
    {
        col = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.plr)
            col.enabled = !(PlayerMovement.plr.rb.velocity.y > 0 || Input.GetKey(KeyCode.S)) ;
    }
}
