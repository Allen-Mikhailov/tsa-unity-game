using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string nextScene = "Level 1";

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == PlayerMovement.plr.mainCollider)
            SceneTransitions.trans.Transition(nextScene);
    }
}
