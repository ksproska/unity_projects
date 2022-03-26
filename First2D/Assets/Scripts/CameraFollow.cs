using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    private void Awake() {
        target = GameObject.Find("Player").GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
