using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed = 2f;
    private Rigidbody2D body;
    private Rigidbody2D throwable;

    // private void OnEnable() {
    //     gameplayActions.Enable();
    // }

    // private void OnDisable() {
    //     gameplayActions.Disable();
    // }
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        throwable = Resources.Load("Throwable", typeof(Rigidbody2D)) as Rigidbody2D;
    }
 
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.UpArrow))
            body.velocity = new Vector2(body.velocity.x, speed);
        if (Input.GetKey(KeyCode.RightArrow))
            body.velocity = new Vector2(speed, body.velocity.y);
        if (Input.GetKey(KeyCode.LeftArrow))
            body.velocity = new Vector2(-speed, body.velocity.y);
        if (Input.GetButtonDown("Fire1")) { //left ctrl
            var throwed = Instantiate(throwable) as Rigidbody2D;
        }
    }
}
