using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    private static Image[] hearts;
    private static int currentHealth;
    void Start()
    {
        currentHealth = 3;
        hearts = new Image[]{heart1, heart2, heart3};
    }

    void Update()
    {
        
    }

    public static void subHealth() {
        if (currentHealth >= 1)
        {
            currentHealth -= 1;
            hearts[currentHealth].enabled = false;
        }
    }
    public static void addHealth() {
        if (currentHealth < 3)
        {
            hearts[currentHealth].enabled = true;
            currentHealth += 1;
        }
    }
}
