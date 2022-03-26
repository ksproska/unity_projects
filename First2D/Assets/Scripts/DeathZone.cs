using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene ("Level1");
        if (other.tag == "Player") {
            SceneManager.LoadScene ("Level1");
        }
    }
}
