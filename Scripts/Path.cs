using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    public bool ghost = false;
    public float PauseTime = .5f;
    public float MoveTime = 4;

    GameObject target;
    float alpha = 0;
    float pauseAlpha = -1;

    // Start is called before the first frame update
    void Start()
    {
        target = p2;
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseAlpha != -1)
        {
            pauseAlpha = Mathf.Min(pauseAlpha + Time.deltaTime / PauseTime, 1);
            if (pauseAlpha == 1)
                pauseAlpha = -1;
        }
        else
        {
            alpha = Mathf.Min(alpha + Time.deltaTime / MoveTime, 1);

            Vector3 a = target == p1 ? p2.transform.position : p1.transform.position;
            Vector3 b = target == p1 ? p1.transform.position : p2.transform.position; ;
            transform.position = Vector3.Lerp(a, b, alpha);

            if (alpha == 1)
            {
                alpha = 0;
                if(ghost){
                    gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x*-1, 1, 1);
                }
                target = target == p1 ? p2 : p1;
                pauseAlpha = 0;
            }
        }
    }
}
