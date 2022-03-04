using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class RectangleBehaviour : MonoBehaviour
{
    void Start() {
        
    }

    void Update() {

    }

    private void OnMouseDown()
    {
        // Debug.Log("works");
        StartCoroutine(AfterClickRectangleBehaviour(Color.red));
    }

    IEnumerator AfterClickRectangleBehaviour(Color chosenColor, float timeTillDisapear = 0.5f) {
        GetComponent<Renderer>().material.color = chosenColor;
        yield return new WaitForSeconds(timeTillDisapear);
        GetComponent<Renderer>().enabled = false;
    }
}
