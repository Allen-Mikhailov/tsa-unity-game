using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    public ParticleSystem particles1;
    public ParticleSystem particles2;

    private ColExpo collider1;
    private ColExpo collider2;

    private bool needs1Leave;
    private bool needs2Leave;

    public float _teleportCD = 0;

    bool isPlayer(Collider2D collision)
    {
        return PlayerMovement.plr.mainCollider == collision;
    }

    void Teleport(GameObject marker)
    {
        // Debug.Log("Teleport");
        PlayerMovement.plr.gameObject.transform.position = marker.transform.position;
        _teleportCD = Time.timeSinceLevelLoad + 2f;
    }

    void Start()
    {
        collider1 = p1.GetComponent<ColExpo>();
        collider2 = p2.GetComponent<ColExpo>();

        collider1.TriggerEnter += ((Collider2D collision) => {
            if (needs1Leave || !isPlayer(collision) || _teleportCD > Time.timeSinceLevelLoad) return;

            particles2.Emit(10);
            needs2Leave = true;
            Teleport(p2);
        });

        collider1.TriggerExit += ((Collider2D collision) => {
            if (!isPlayer(collision)) return;
            needs1Leave = false;
        });

        collider2.TriggerEnter += ((Collider2D collision) => {
            if (needs2Leave || !isPlayer(collision) || _teleportCD > Time.timeSinceLevelLoad) return;
            particles1.Emit(10);
            needs1Leave = true;
            Teleport(p1);
        });

        collider2.TriggerExit += ((Collider2D collision) => {
            if (!isPlayer(collision)) return;
            needs2Leave = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
