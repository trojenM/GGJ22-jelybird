using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Serialization;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private bool isEnemySpawnerLeft = false;
    
    private List<Transform> spawnPositionsTr = new List<Transform>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPositionsTr.Add(transform.GetChild(i));
        }
    }

    private void Start()
    {
        StartCoroutine(StartSpawning(2f));
    }

    IEnumerator StartSpawning(float spawnInterval)
    {
        while (!LevelManager.Instance.isGameEnded)
        {
            
            int spawnIdx = UnityEngine.Random.Range(0, spawnPositionsTr.Count);

            GameObject enemy;
            if (isEnemySpawnerLeft)
                enemy = EnemyPool.Instance.GetFromPool();
            else
                enemy = EnemyPoolRight.Instance.GetFromPool();
                
            enemy.transform.position = spawnPositionsTr[spawnIdx].position;
            enemy.transform.GetChild(0).position = enemy.transform.position;
            if (enemy.transform.GetChild(0) != null)
                enemy.transform.GetChild(0).parent = null;
            
            yield return new WaitForSeconds(spawnInterval);
        }

        yield return null;
    }
}
