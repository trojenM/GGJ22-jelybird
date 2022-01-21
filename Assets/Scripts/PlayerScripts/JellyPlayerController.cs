using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform verticalBorderLimits = default;
    private Transform movePoint = default;

    void Awake()
    {
        movePoint = transform.GetChild(0);
        movePoint.parent = null;
    }

    void Update()
    {
        float yInput = Input.GetAxisRaw("Vertical");

        float upLimit = verticalBorderLimits.GetChild(1).position.y;
        float downLimit = verticalBorderLimits.GetChild(0).position.y;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(yInput) == 1f && (movePoint.position.y + yInput > downLimit) && (movePoint.position.y + yInput < upLimit))
            {
                movePoint.Translate(Vector3.up * yInput);
            }    
        }
    }
}
