using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FinishLineHandler : MonoBehaviour
{
    [SerializeField]
    public string nextSceneToLoad;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            SceneManager.LoadScene(nextSceneToLoad);
        }
    }

    private void FixedUpdate() {
        if(Input.GetKey(KeyCode.M)) {
            SceneManager.LoadScene("Menu");
        }
    }
}
