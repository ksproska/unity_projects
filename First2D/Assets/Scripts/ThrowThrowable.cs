using UnityEngine;

public class ThrowThrowable : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D throwable;
    private Vector2 movement = new Vector2(1, 0)*2f;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        throwable = gameObject.GetComponent<Rigidbody2D>();
        throwable.position = player.position;
    }

    void Start()
    {
        Destroy(gameObject, 2);
        if(player.localRotation != Quaternion.Euler(0, 0, 0)) {
            movement = -movement;
        }
        throwable.AddForce(movement, ForceMode2D.Impulse);
    }

    void Update()
    {
        throwable.position += movement * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "BadGuy") {
            Destroy(gameObject, 0.1f);
        }
    }
}
