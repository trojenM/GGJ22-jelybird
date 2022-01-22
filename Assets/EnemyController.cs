using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private bool isLeftEnemy = false;
    private bool isUpEnemy = false;

    [HideInInspector] public Transform movePoint = default;
    
    [SerializeField] public static float moveSpeed = 5f;
    private float timer = default;
    [SerializeField] private float movePointInterval = 1f;
    
    private void Awake()
    {
        movePoint = transform.GetChild(0);
        //movePoint.parent = null;
        
        isUpEnemy = transform.position.y > 0;

        //StartCoroutine(Move(moveSpeed));
    }

    private void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        

        timer -= Time.deltaTime;
        
        if (timer > 0f)
            return;
        
        
        // Reset timer.
        timer = movePointInterval;
        
        if (isLeftEnemy)
        {
            if (isUpEnemy)
            {
                movePoint.Translate(Vector3.up);
            }
            else
            {
                movePoint.Translate(Vector3.down);
            }

            if (movePoint.position.y <= -6f || movePoint.position.y >= 6f)
            {
                EnemyPool.Instance.AddToPool(gameObject);
                movePoint.SetParent(transform);
                movePoint.position = Vector3.zero;
            }
        }
        else
        {
            movePoint.Translate(Vector3.left);
            
            if (movePoint.position.x <= -1f)
            {
                EnemyPool.Instance.AddToPool(gameObject);
                movePoint.SetParent(transform);
                movePoint.position = Vector3.zero;
            }
        }
    }
}
