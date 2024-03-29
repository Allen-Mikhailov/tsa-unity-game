using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstBoss : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public RectTransform barTransform;
    public float BossLength = 10;
    private float bossTime = 0;
    public GameObject laserObject;
    const float laserSpawnTime = 5;
    private float nextLaser = laserSpawnTime;
    public float minSpawnHeight;
    public float maxSpawnHeight;

    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameEnded) {return;}
        bossTime += Time.deltaTime;

        float alpha = Mathf.Min(1, bossTime/BossLength);

        barTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, alpha*400);
        
        nextLaser -= Time.deltaTime;
        if (nextLaser < 0)
        {
            nextLaser = laserSpawnTime;
            GameObject newLaser = Object.Instantiate(laserObject, transform) as GameObject;
            newLaser.transform.position = new Vector3(0, Random.Range(minSpawnHeight, maxSpawnHeight), -2);
            newLaser.GetComponent<Lazer>().loseScreen = loseScreen;
        }

        if (bossTime >= BossLength)
        {
            winScreen.SetActive(true);
            gameEnded = true;
            // Time.timeScale  = 0;
        } else if (loseScreen.activeSelf) {
            gameEnded = true;
        }
    }
}
