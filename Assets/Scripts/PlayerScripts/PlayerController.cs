using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform bird, jellyFish;
    [SerializeField] private Transform horizontalBorderLimits;

    private Transform movePointBird, movePointJellyFish;

    public static float moveSpeed = 5f;

    void Awake()
    {
        movePointBird = bird.GetChild(0);
        movePointBird.parent = null;
        
        movePointJellyFish = jellyFish.GetChild(0);
        movePointJellyFish.parent = null;
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        
        float leftLimit = horizontalBorderLimits.GetChild(0).position.x;
        float rightLimit = horizontalBorderLimits.GetChild(1).position.x;

        bird.position = Vector3.MoveTowards(bird.position, movePointBird.position, moveSpeed * Time.deltaTime);
        jellyFish.position = Vector3.MoveTowards(jellyFish.position, movePointJellyFish.position, moveSpeed * Time.deltaTime);

        if (xInput < 0)
        {
            bird.localScale = new Vector3(-1, bird.localScale.y, bird.localScale.z);
        }
        else
        {
            bird.localScale = new Vector3(1, bird.localScale.y, bird.localScale.z);
        }
        
        if (Vector3.Distance(bird.position, movePointBird.position) <= 0.05f)
        {
            if (Mathf.Abs(xInput) == 1f && (movePointBird.position.x + xInput > leftLimit) && (movePointBird.position.x + xInput < rightLimit))
            {
                movePointBird.Translate(Vector3.right * xInput);
                movePointJellyFish.Translate(Vector3.up * xInput);
            }    
        }
    }
}
