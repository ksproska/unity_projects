using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    private float speed = 2f;
    private Rigidbody2D body;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            body.velocity = new Vector2(body.velocity.x, speed);
        if (Input.GetKey(KeyCode.RightArrow))
            body.velocity = new Vector2(speed, body.velocity.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.velocity = new Vector2(-speed, body.velocity.y);
    }
}
