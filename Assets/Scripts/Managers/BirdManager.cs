using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            LevelManager.Instance.GetDamage(1);
            EnemyPool.Instance.AddToPool(other.gameObject);
            other.gameObject.GetComponent<EnemyController>().movePoint.SetParent(other.transform);
            other.gameObject.GetComponent<EnemyController>().movePoint.position = other.transform.position;
        }
    }
}
