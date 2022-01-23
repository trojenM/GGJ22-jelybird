using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyManager : MonoBehaviour
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
            EnemyPoolRight.Instance.AddToPool(other.gameObject);
            other.gameObject.GetComponent<EnemyController>().movePoint.SetParent(other.transform);
            other.gameObject.GetComponent<EnemyController>().movePoint.position = Vector3.zero;

        }
        else if (other.CompareTag("Coral"))
        {
            LevelManager.Instance.GetDamage(1);
            Destroy(other.GetComponent<coralMove>().movePoint.gameObject);
            Destroy(other.gameObject);
        }
    }
}
