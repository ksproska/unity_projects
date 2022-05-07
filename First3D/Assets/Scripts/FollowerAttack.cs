using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowerAttack : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            HealthController.subHealth();
        }
    }
}
