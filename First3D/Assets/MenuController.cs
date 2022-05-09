using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button startGameButton;
    public Text infoText;
    public static string textToSet = "";
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        infoText.text = textToSet;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        SceneManager.LoadScene("Game");
    }
}
