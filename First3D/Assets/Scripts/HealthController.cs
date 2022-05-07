using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    private static Image[] hearts;
    private static int currentHealth;
    private static int maxCurrentHealth = 3;
    void Start()
    {
        currentHealth = maxCurrentHealth;
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
        if (currentHealth == 0)
        {
            MenuController.textToSet = "You lost!";
            SceneManager.LoadScene("Menu");
        }
    }
    public static void addHealth() {
        if (currentHealth < maxCurrentHealth)
        {
            hearts[currentHealth].enabled = true;
            currentHealth += 1;
        }
    }
}
