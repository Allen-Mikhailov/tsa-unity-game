using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColExpo : MonoBehaviour
{
    public delegate void CollisionEvent(Collision2D c);
    public delegate void TriggerEvent(Collider2D c);

    public event CollisionEvent CollisionEnter;
    public event CollisionEvent CollisionExit;
    public event TriggerEvent TriggerEnter;
    public event TriggerEvent TriggerExit;

    void OnCollisionEnter2D(Collision2D c)
    { CollisionEnter?.Invoke(c); }

    void OnCollisionExit2D(Collision2D c)
    { CollisionExit?.Invoke(c); }

    void OnTriggerEnter2D(Collider2D c)
    { TriggerEnter?.Invoke(c); }

    void OnTriggerExit2D(Collider2D c)
    { TriggerExit?.Invoke(c); }
}
