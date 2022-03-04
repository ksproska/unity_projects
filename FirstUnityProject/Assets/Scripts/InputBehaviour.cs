using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputBehaviour : MonoBehaviour
{
    private int minVal = 1;
    private int maxVal = 10;
    private InputField input;
    private Button nextButton;
    public int N { get; set; }
    
    void Awake()
    {
        input = GameObject.Find("InputField").GetComponent<InputField>();
        nextButton = GameObject.Find("NextButton").GetComponent<Button>();
        N = -1;
    }

    public void OnInputPut(string inputString) {
        int inputInt = -1;
        try
        {
            inputInt = System.Int32.Parse(inputString);
        }
        catch (System.FormatException e)
        {
            GameObject.Find("ErrorText").GetComponent<Text>().text = $"Wrong input format, must be number.";
            return;
        }
        if(inputInt < minVal || inputInt > maxVal) {
            GameObject.Find("ErrorText").GetComponent<Text>().text = $"{inputInt} is not in the range <{minVal}, {maxVal}>";
            return;
        }
        N = inputInt;
        GameObject.Find("ErrorText").GetComponent<Text>().text = $"";
    }
    public void OnMouseDown()
    {
        if(N == -1) {
            GameObject.Find("ErrorText").GetComponent<Text>().text = $"Value not set.";
            return;
        }
        RectContainer.N = N;
        SceneManager.LoadScene("GameScene");
    }
}
