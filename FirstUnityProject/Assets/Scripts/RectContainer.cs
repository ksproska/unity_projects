using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectContainer : MonoBehaviour
{
    static System.Random random = new System.Random();
    Color[] usedColors = {Color.red, Color.blue, Color.green, Color.cyan, Color.gray, Color.yellow, Color.black, Color.magenta};
    Vector2 minSize = new Vector2(0.2f, 0.2f);
    Vector2 maxSize = new Vector2(2f, 2f);
    void Start()
    {
        int n = 5;
        var gameObjectPattern = Resources.Load("Rectangle", typeof(GameObject));
        
        for(int i = 0; i < n; i++) {
            var gameObject = Instantiate(gameObjectPattern) as GameObject;

            Vector2 newSize = getRandomVector(minSize, maxSize);
            gameObject.transform.localScale = newSize;
            var cameraY = Camera.main.orthographicSize * 2f;
            var cameraX = cameraY * Camera.main.aspect;
            Vector2 minOffset = new Vector2(-cameraX/2 + newSize.x/2, -cameraY/2 + newSize.y/2);
            Vector2 max0ffset = new Vector2(cameraX/2 - newSize.x/2, cameraY/2 - newSize.y/2);
            Vector2 moveVector = getRandomVector(minOffset, max0ffset);
            gameObject.transform.position = moveVector;
            gameObject.GetComponent<Renderer>().material.color = getRandomColor();
        }
    }

    void Update()
    {
        
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
