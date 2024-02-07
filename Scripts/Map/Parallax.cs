using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] objects;
    public float expo_diff = .1f;

    private GameObject cam;

    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 pos = cam.transform.position - transform.position;
        for (int i = 0; i < objects.Length; i++)
        {
            objects[i].transform.localPosition = new Vector3(
                pos.x*(objects.Length-i)*expo_diff, 
                pos.y*(objects.Length-i)*expo_diff, 
                5 + i
                );
        }
    }
}
