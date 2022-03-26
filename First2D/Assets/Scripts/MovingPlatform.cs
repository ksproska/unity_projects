using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    public float speed = 1.5f;
    Rigidbody2D platform;
    float startPosition;
    float endPosition;
    [SerializeField]
    public float widthMovementOffset = 3f;
    bool moveRight = true;
    void Awake()
    {
        platform = gameObject.GetComponent<Rigidbody2D>();
        startPosition = platform.position.x - widthMovementOffset/2;
        endPosition = startPosition + widthMovementOffset/2;
    }
    
    private void FixedUpdate() {
        if(moveRight) {
            platform.velocity = new Vector2(speed, platform.velocity.y);
            if (platform.position.x > endPosition)
            {
                moveRight = false;
            }
        }
        else
        {
            platform.velocity = new Vector2(-speed, platform.velocity.y);
            if (platform.position.x < startPosition)
            {
                moveRight = true;
            }

        }
    }
}
