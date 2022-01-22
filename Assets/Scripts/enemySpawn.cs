using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemySpawn : MonoBehaviour
{
    public GameObject eUpToDown;
    public GameObject eRightToLeft;
    public GameObject playerLeft;
    public GameObject playerRight;

    float           spLeft,spRight;
    public int      randomR;
    public float    spawnRate = 0.5f;
    float           nextSpawn = 0.0f;
    Vector3         whereToSpawnUp, whereToSpawnDown;


    void Start()
    {
        randomR = 1;
        spLeft = playerLeft.transform.position.x + (UnityEngine.Random.Range(-2,2));
        spRight = playerRight.transform.position.x + (UnityEngine.Random.Range(-2, 2));
    }
   
    void Update()
    {
        spawn();
    }

    private void spawn()
    {
        if (Time.time > nextSpawn)
        {
            randomR = UnityEngine.Random.Range(1, 3);
            nextSpawn = Time.time + (UnityEngine.Random.Range(2, 4) - spawnRate);
            spLeft = playerLeft.transform.position.x + (UnityEngine.Random.Range(-2, 2));
            spRight = playerRight.transform.position.y + (UnityEngine.Random.Range(-1, 2));
            if (spLeft < -8)
                spLeft += UnityEngine.Random.Range(1, 2);
            if (spLeft > -1)
                spLeft -= UnityEngine.Random.Range(1, 2);
            if (spRight > 4)
                spRight -= UnityEngine.Random.Range(1, 2);
            if (spRight < -3)
                spRight += UnityEngine.Random.Range(1, 2);
            whereToSpawnUp = new Vector3(spLeft, 7, 0);
            whereToSpawnDown = new Vector3(11, spRight, 0);

            if (randomR == 1)
            {
                Instantiate(eUpToDown, whereToSpawnUp, Quaternion.identity);
                Instantiate(eRightToLeft, whereToSpawnDown, Quaternion.identity);
            }
            if (randomR == 2)
            {
                Instantiate(eUpToDown, whereToSpawnUp, Quaternion.identity);
                Instantiate(eRightToLeft, whereToSpawnDown, Quaternion.identity);
            }
            if (randomR == 3)
            {
                Instantiate(eUpToDown, whereToSpawnUp, Quaternion.identity);
            }
            if (randomR == 4)
            {
                Instantiate(eRightToLeft, whereToSpawnDown, Quaternion.identity);
            }
        }
    }
}
