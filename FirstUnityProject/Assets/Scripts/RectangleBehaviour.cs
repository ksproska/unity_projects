using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RectangleBehaviour : MonoBehaviour
{
    public Color NextColor { set; get; }
    public float timeTillDisapear { set; get; }
    public bool IsEnabled {get; set; }
    void Start() {
        IsEnabled = true;
    }

    void Update() {

    }

    private void OnMouseDown()
    {
        // Debug.Log("works");
        StartCoroutine(AfterClickRectangleBehaviour(NextColor, timeTillDisapear));
    }

    IEnumerator AfterClickRectangleBehaviour(Color chosenColor, float timeTillDisapear = 0.5f) {
        GetComponent<Renderer>().material.color = chosenColor;
        yield return new WaitForSeconds(timeTillDisapear);
        GetComponent<Renderer>().enabled = false;
        IsEnabled = false;
    }
}
