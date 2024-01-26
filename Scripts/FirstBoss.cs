using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    public RectTransform barTransform;
    public float BossLength = 120;
    private float bossTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bossTime += Time.deltaTime;

        float alpha = Mathf.Min(1, bossTime/BossLength);

        barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, alpha*400);
        

        if (bossTime >= BossLength)
        {

        }
    }
}
