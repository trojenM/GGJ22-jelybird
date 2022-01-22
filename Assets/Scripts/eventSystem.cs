using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventSystem : MonoBehaviour
{
    float   eventCount;
    float   eventTime;
    float   count;
    int     randomR;
    int     evnt;

    void Start()
    {
        eventCount = 5.0f;
        eventTime = 3.0f;
        count = 0;
        randomR = 0;
        evnt = 0;
    }

    void Update()
    {
        eventTimer();
    }

    void eventTimer()
    {
        count += Time.deltaTime;
        if (count >= eventCount && evnt == 0)
        {
            randomR = UnityEngine.Random.Range(1, 4);
            if (randomR == 1)
                PlayerController.moveSpeed = 7.5f;
            if (randomR == 2)
                EnemyController.moveSpeed = 7.5f;
            if (randomR == 3)
            {
                PlayerController.moveSpeed = 7.5f;
                EnemyController.moveSpeed = 7.5f;
            }
            count = 0;
            evnt = randomR;
        }
        
        if (evnt != 0)
            eventTime -= Time.deltaTime;
        
        if (eventTime <= 0)
        {
            PlayerController.moveSpeed = 5.0f;
            EnemyController.moveSpeed = 5.0f;
            eventTime = 3.0f;
            evnt = 0;
        }
    }
}
