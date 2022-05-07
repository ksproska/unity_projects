using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectPoints : MonoBehaviour
{
    public Camera camera;
    public Text pointsCounter;
    private float rayDistance = 2F;
    public AudioSource collectSound;
    CursorLockMode cursorLock;
    private int currentPoints;
    private int currentMaxPoints = 16;

    void Start () {
        currentPoints = 0;
        pointsCounter.text = $"Score: {currentPoints}";
    }

    void Update() {
        Collect();
    }

    void Collect() {
        RaycastHit hit;
        //Ray ray = camera.ScreenPointToRay (Input.mousePosition);

        if (Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, rayDistance)) {
            if (hit.collider.tag == "Collectable") {
                AnimationScript collectable = hit.collider.gameObject.GetComponent<AnimationScript>();
                if (!collectable.isBeingCollected)
                {
                    currentPoints += 1;
                    collectable.collect();
                    pointsCounter.text = $"Score: {currentPoints}";
                    collectSound.Play();
                    HealthController.addHealth();
                }
                if (currentPoints == currentMaxPoints)
                {
                    MenuController.textToSet = "You won!";
                    SceneManager.LoadScene("Menu");
                }
            }
        }
    }
}
