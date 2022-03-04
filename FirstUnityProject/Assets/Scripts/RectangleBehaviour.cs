using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectangleBehaviour : MonoBehaviour
{
    System.Random random = new System.Random();
    Color[] usedColors = {Color.red, Color.blue, Color.green, Color.cyan};
    Vector2 minSize = new Vector2(0.2f, 0.2f);
    Vector2 maxSize = new Vector2(6f, 6f);
    
    void Start()
    {
        Vector2 newSize = getRandomVector(minSize, maxSize);
        gameObject.transform.localScale = newSize;
        Vector2 minOffset = new Vector2(-Screen.width/2 + newSize.x/2, -Screen.height/2 + newSize.y/2);
        Vector2 max0ffset = new Vector2(Screen.width/2 - newSize.x/2, Screen.height/2 - newSize.y/2);
        Vector2 moveVector = getRandomVector(minOffset, max0ffset);
        gameObject.transform.position = moveVector;
        Debug.Log($"{moveVector.x}, {moveVector.y}");
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            OnMouseDown();
        }
    }
    
    void OnMouseDown()
    {
        StartCoroutine(AfterClickRectangleBehaviour(getRandomColor()));
    }

    IEnumerator AfterClickRectangleBehaviour(Color chosenColor, float timeTillDisapear = 0.5f) {
        GetComponent<Renderer>().material.color = chosenColor;
        yield return new WaitForSeconds(timeTillDisapear);
        GetComponent<Renderer>().enabled = false;
    }

    float getRandom(float minValue, float maxValue) {
        float range = maxValue - minValue;
        double nextDouble = random.NextDouble();
        return (float) (nextDouble * range) + minValue;
    }

    Color getRandomColor() {
        return usedColors[random.Next(0, usedColors.Length)];
    }

    Vector2 getRandomVector(Vector2 minSize, Vector2 maxSize) {
        float newX = getRandom(minSize.x, maxSize.x);
        float newY = getRandom(minSize.y, maxSize.y);
        // Debug.Log($"{newX}, {newY}");
        return new Vector2(newX, newY);
    }
}
