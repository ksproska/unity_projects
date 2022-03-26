using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float speed = 1.5f;
    Rigidbody2D platform;
    float startPosition;
    float endPosition;
    float widthMovement = 3f;
    bool moveRight = true;
    void Awake()
    {
        platform = gameObject.GetComponent<Rigidbody2D>();
        startPosition = platform.position.x - widthMovement/2;
        endPosition = startPosition + widthMovement/2;
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
