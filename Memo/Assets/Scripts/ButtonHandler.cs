using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void Set2x2() {
        GameController.SizeId = 0;
        SceneManager.LoadScene("GameScene");
    }
    public void Set2x4() {
        GameController.SizeId = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void Set4x4() {
        GameController.SizeId = 2;
        SceneManager.LoadScene("GameScene");
    }
}
