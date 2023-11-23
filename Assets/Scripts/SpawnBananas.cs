using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBananas : MonoBehaviour
{
    public float xRandom = 0f;
    public float yRandom = 0f;
    public GameObject bananaEnemy;
    public float bananaSpawnRate = 5f;
    private float bananaSpawnTimer = 0f;

    void Update()
    {
        xRandom = Random.Range(-10f, 10f);
        yRandom = Random.Range(-5f, 4f);
        var enemyPosition = new Vector3(xRandom, yRandom, 0f);

        if (bananaSpawnTimer <= 0f)
        {
            Instantiate(bananaEnemy, enemyPosition, Quaternion.identity);
            bananaSpawnTimer = bananaSpawnRate;
        }
        else
        {
            bananaSpawnTimer -= Time.deltaTime;;
        }
    }   
}
