using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : MonoBehaviour
{
    public Rigidbody2D rbody;
    // Start is called before the first frame update
    void Start()
    {
        rbody.angularVelocity = 100;
    }

    // Update is called once per frame
    void Update()
    {
        rbody.angularVelocity = 100;
    }
}
