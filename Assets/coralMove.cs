using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coralMove : MonoBehaviour
{
    float startPosY;
    float speed = 2.0f;
    int randomY;
    bool onTargetY;

    void Start()
    {
        randomY = UnityEngine.Random.Range(0, 5);
        startPosY = transform.position.y;
    }
    void Update()
    {
        if (!onTargetY)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, startPosY + randomY, transform.position.z));
        }
        if ()
    }
}
