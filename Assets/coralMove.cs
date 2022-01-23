using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coralMove : MonoBehaviour
{
    private float movePointStartPosY;
    private float speed = 2.0f;
    private int randomY;

    private bool isUpCoral = false;
    
    [HideInInspector] public Transform movePoint = default;

    [SerializeField] private float movePointIntervalX = 1f;
    [SerializeField] private float movePointIntervalY = .3f;
    private float moveYtimer;
    private float moveXtimer;

    private void Awake()
    {
        movePoint = transform.GetChild(0);
        movePoint.parent = null;

        isUpCoral = transform.position.y > 0f;

        movePointStartPosY = movePoint.position.y;
        
        randomY = UnityEngine.Random.Range(2, 5);

        moveXtimer = movePointIntervalX;
        moveYtimer = movePointIntervalY;

    }

    void Update()
    {
        transform.position =
            Vector3.MoveTowards(transform.position, movePoint.position, speed * Time.deltaTime);

        if (moveYtimer <= 0f)
        {
            if (!isUpCoral)
            {
                if (movePoint.position.y <= movePointStartPosY + randomY)
                    movePoint.Translate(Vector3.up);
            }
            else
            {
                if (movePoint.position.y >= movePointStartPosY - randomY)
                    movePoint.Translate(Vector3.down);
            }

            moveYtimer = movePointIntervalY;
        }

        if (moveXtimer <= 0f)
        {
            movePoint.Translate(Vector3.left);
            moveXtimer = movePointIntervalX;
        }

        if (movePoint.position.x <= -1f)
        {
            Destroy(gameObject);
        }
        

        moveXtimer -= Time.deltaTime;
        moveYtimer -= Time.deltaTime;
    }
}
