using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RectContainer : MonoBehaviour
{
    static System.Random random = new System.Random();
    System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
    Color[] usedColors = {Color.red, Color.blue, Color.green, Color.cyan, Color.gray, Color.yellow, Color.black, Color.magenta};
    List<RectangleBehaviour> rectangles;
    Vector2 minSize = new Vector2(2f, 2f);
    Vector2 maxSize = new Vector2(20f, 20f);
    void Start()
    {
        int n = 3;
        rectangles = new List<RectangleBehaviour>();
        StartGame(n);
    }

    void StartGame(int n) {
        var gameObjectPattern = Resources.Load("Rectangle", typeof(RectangleBehaviour));
        
        for(int i = 0; i < n; i++) {
            var gameObject = Instantiate(gameObjectPattern) as RectangleBehaviour;
            rectangles.Add(gameObject);
            Vector2 newSize = getRandomVector(minSize, maxSize);
            gameObject.transform.localScale = newSize;
            var cameraY = Camera.main.orthographicSize * 2f;
            var cameraX = cameraY * Camera.main.aspect;
            Vector2 minOffset = new Vector2(-cameraX/2 + newSize.x/2, -cameraY/2 + newSize.y/2);
            Vector2 max0ffset = new Vector2(cameraX/2 - newSize.x/2, cameraY/2 - newSize.y/2);
            Vector2 moveVector = getRandomVector(minOffset, max0ffset);
            gameObject.transform.position = moveVector;
            gameObject.GetComponent<Renderer>().material.color = getRandomColor();
            gameObject.NextColor = getRandomColor();
            gameObject.timeTillDisapear = getRandom(0f, 0.5f);
        }
    }

    private int GetEnabledNumber() {
        int sum = 0;
        foreach(var rectangle in rectangles) {
            if(rectangle.IsEnabled) {
                sum += 1;
            }
        }
        return sum;
    }

    void Update()
    {
        var sum = GetEnabledNumber();
        GameObject.Find("LeftCount").GetComponent<Text>().text = $"Left: {sum}";
        GameObject.Find("Timer").GetComponent<Text>().text = $"Time: {watch.Elapsed.ToString(@"m\:ss\.ff")}";
        if(sum == 0) {
            watch.Stop();
        }
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
