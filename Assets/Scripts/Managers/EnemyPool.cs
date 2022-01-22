using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    private Queue<GameObject> availableObjects = new Queue<GameObject>();
    public static EnemyPool Instance { get; private set; }
    
    private void Awake()
    {
        Instance = this;
        GrowPool(10);
    }

    public GameObject GetFromPool()
    {
        if (availableObjects.Count == 0)
        {
            GrowPool(10);   
        }

        var instance = availableObjects.Dequeue();
        instance.SetActive(true);
        return instance;
    }
    
    private void GrowPool(int n)
    {
        for (int i = 0; i < n; i++)
        {
            int a = i % 3;
            var instantiatedObj = Instantiate(enemyPrefabs[a],transform);
            AddToPool(instantiatedObj);
        }
    }

    public void AddToPool(GameObject instance)
    {
        instance.SetActive(false);
        availableObjects.Enqueue(instance);
    }
}
