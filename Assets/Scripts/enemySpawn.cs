using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemyUp;
    public GameObject enemyDown;
    public GameObject playerUp;
    public GameObject playerDown;

    float             spUp,spDown;
    public int      randomR;
    public float    spawnRate = 0.02f;
    float           nextSpawn = 0.0f;
    Vector3         whereToSpawnUp, whereToSpawnDown;


    void Start()
    {
        randomR = 1;
        spUp = playerDown.transform.position.x + (UnityEngine.Random.Range(-2,2));
        spDown = playerDown.transform.position.x + (UnityEngine.Random.Range(-1, 2));
    }

    void Update()
    {
        spawn();
    }

    private void spawn()
    {
        if (Time.time > nextSpawn)
        {
            randomR = UnityEngine.Random.Range(1, 2);
            nextSpawn = Time.time + (UnityEngine.Random.Range(1, 2) - 0.5f);
            spUp = playerUp.transform.position.x + (UnityEngine.Random.Range(-2, 2));
            spDown = playerDown.transform.position.y + (UnityEngine.Random.Range(-1, 2));

            whereToSpawnUp = new Vector3(spUp, 7, 0);
            whereToSpawnDown = new Vector3(11, spDown, 0);

            if (randomR == 1)
            {
                Instantiate(enemyUp, whereToSpawnUp, Quaternion.identity);
                Instantiate(enemyDown, whereToSpawnDown, Quaternion.identity);
                spUp = playerUp.transform.position.x + (UnityEngine.Random.Range(-2, 2));
                spDown = playerDown.transform.position.y + (UnityEngine.Random.Range(-1, 2));
            }
            if (randomR == 2)
            {
                Instantiate(enemyUp, whereToSpawnUp, Quaternion.identity);
                Instantiate(enemyDown, whereToSpawnDown, Quaternion.identity);
                spUp = playerUp.transform.position.x + (UnityEngine.Random.Range(-2, 2));
                spDown = playerDown.transform.position.y + (UnityEngine.Random.Range(-1, 2));
            }
            if (randomR == 3)
            {
                Instantiate(enemyUp, whereToSpawnUp, Quaternion.identity);
                spUp = playerUp.transform.position.y + (UnityEngine.Random.Range(-2, 2));
            }
        }
    }
}
