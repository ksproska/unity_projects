using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // public static int allDisplayed = 0;
    public static List<Card> DisplayedCards = new List<Card>();
    public int MatchingId {get; set;}
    public bool IsDisplayed {get; set;}
    void Start()
    {
        gameObject.GetComponentInChildren<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(string text) {
        gameObject.GetComponentInChildren<Text>().text = text;
    }

    public void OnClick() {
        if(DisplayedCards.Count < 2 && !DisplayedCards.Contains(this)) {
            gameObject.GetComponentInChildren<Text>().enabled = true;
            DisplayedCards.Add(this);
        }
    }

    public void Hide() {
        gameObject.GetComponentInChildren<Text>().enabled = false;
    }

    public void Remove() {
        gameObject.SetActive(false);
    }
}
