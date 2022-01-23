using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coralSpawner : MonoBehaviour
{
    public GameObject coral;
    float spawnTimer;
    bool waitingToSpawn;
    float timer;

    void Start()
    {
        
    }

    void Update()
    {
        if (!waitingToSpawn)
        {
            spawnTimer = UnityEngine.Random.Range(4f, 6f);
            waitingToSpawn = true;
        }

        if (!waitingToSpawn)
            return;
        timer += Time.deltaTime;
        if (timer >= spawnTimer)
        {
            int spawnPosIndex = UnityEngine.Random.Range(0, 2);
            Instantiate(coral, transform.GetChild(spawnPosIndex).position, Quaternion.identity);
            timer = 0;
            waitingToSpawn = false;
        }
    }
}
