using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeFlipper : MonoBehaviour
{
    public float flipTime = 5;
    private float repeatTime = 0;
    private bool count = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        repeatTime+=Time.deltaTime;
        if(repeatTime%5>1){
            count=true;
        }
        if(repeatTime % flipTime <= 0.1 && count){
            transform.localScale*=-1;
            count=false;
        }
    }
}
