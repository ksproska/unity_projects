using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public Image heart1, heart2, heart3;
    private Image[] hearts;
    private static Sprite fullHealth, noneHealth;
    private int currentHealth;
    void Start()
    {
        currentHealth = 3;
        hearts = new Image[]{heart1, heart2, heart3};
        fullHealth = Resources.Load("mini-heart/miniheart_0", typeof(Sprite)) as Sprite;
        noneHealth = Resources.Load("mini-heart/miniheart_1", typeof(Sprite)) as Sprite;
    }

    void Update()
    {
        
    }

    void subHealth() {
        currentHealth -= 1;
        hearts[currentHealth].sprite = noneHealth;
    }
}
