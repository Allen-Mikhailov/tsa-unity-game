using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    // Start is called before the first frame update
    private float elapsedTime;

    public GameObject warning;
    private SpriteRenderer warningRender;
    public GameObject hit;
    public GameObject loseScreen;

    public ColExpo hitExpo;

    public Color flash1;
    public Color flash2;

    const float warningTime = 3;
    const float hitboxTime = 1;
    const float expandTime = .25f;
    const float laserWidth = 5;
    const float curve = 2;

    private bool inWarning = true;


    void Start()
    {
        elapsedTime = 0;

        hitExpo.TriggerEnter += AttemptDamage;

        warningRender = warning.GetComponent<SpriteRenderer>();
    }

    void AttemptDamage(Collider2D c)
    {
        if (inWarning)
        {return;}


        if (c == PlayerMovement.plr.mainCollider)
        {
            PlayerMovement.plr.Kill();
            loseScreen.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inWarning)
        {
            float walpha = Mathf.Sin(Mathf.Exp(elapsedTime/warningTime * 3.5f));
            warningRender.color = walpha > 0?flash1:flash2;

            if (elapsedTime > warningTime)
                inWarning = false;
        } else {
            float timeSinceWarning = elapsedTime - warningTime;

            float hAlpha = Mathf.Min(timeSinceWarning/expandTime, 1f);
            hit.transform.localScale = new Vector3(30, laserWidth*hAlpha, 1);

            if (timeSinceWarning > hitboxTime)
                Object.Destroy(gameObject);
        }

        elapsedTime += Time.deltaTime;
    }
}
