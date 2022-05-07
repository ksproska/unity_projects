using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{
    public Camera camera;
    private float rayDistance = 2F;
    public AudioSource collectSound;
    CursorLockMode cursorLock;
    private int currentPoints;

    void Start () {
        currentPoints = 0;
    }

    void Update () {
        Pickup ();
    }

    void Pickup (){
        RaycastHit hit;
        //Ray ray = camera.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, rayDistance)) {
            // Debug.Log ("You hit a something");
            if (hit.collider.tag == "Collectable") {
                Debug.Log ("You hit a Collectable");
                AnimationScript collectable = hit.collider.gameObject.GetComponent<AnimationScript>();
                currentPoints += 1;
                collectable.collect();
                collectSound.Play();
            }
        }
    }
}
