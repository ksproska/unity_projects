using UnityEngine;

public class ThrowThrowable : MonoBehaviour
{
    private Transform player;
    private Rigidbody2D throwable;
    private void Awake() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        throwable = gameObject.GetComponent<Rigidbody2D>();
        throwable.position = player.position;
    }

    void Start()
    {
        throwable.AddForce(new Vector2(1, 1)*2f, ForceMode2D.Impulse);
        Destroy(gameObject, 3);
    }

    void Update()
    {
        throwable.position += new Vector2(1, 1)*2f * Time.deltaTime;
    }
}
