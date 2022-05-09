using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAttack : MonoBehaviour
{
    public AudioSource hurt;
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            HealthController.subHealth();
            hurt.Play();
        }
    }
}
