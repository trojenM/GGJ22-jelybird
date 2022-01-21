using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private Transform horizontalBorderLimits = default;
    private Transform movePoint = default;

    void Awake()
    {
        movePoint = transform.GetChild(0);
        movePoint.parent = null;
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        
        float leftLimit = horizontalBorderLimits.GetChild(0).position.x;
        float rightLimit = horizontalBorderLimits.GetChild(1).position.x;

        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(xInput) == 1f && (movePoint.position.x + xInput > leftLimit) && (movePoint.position.x + xInput < rightLimit))
            {
                movePoint.Translate(Vector3.right * xInput);
            }    
        }
    }
}
