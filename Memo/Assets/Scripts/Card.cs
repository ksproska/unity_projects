using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static List<Card> DisplayedCards = new List<Card>();
    public int MatchingId {get; set;}
    public bool WasGuessed { get; set; }

    private static Sprite back;

    void Awake()
    {
        back = Resources.Load("Cards/back", typeof(Sprite)) as Sprite;
    }

    void Start()
    {
        gameObject.GetComponentInChildren<Text>().enabled = false;
        WasGuessed = false;
    }

    private Sprite getFront() {
        return Resources.Load($"Cards/{MatchingId}", typeof(Sprite)) as Sprite;
    }

    public void OnClick() {
        if(DisplayedCards.Count < 2 && !DisplayedCards.Contains(this)) {
            gameObject.GetComponent<Button>().image.sprite = getFront();
            DisplayedCards.Add(this);
        }
    }

    public void Hide() {
        gameObject.GetComponent<Button>().image.sprite = back;
    }

    public void Remove() {
        gameObject.SetActive(false);
        WasGuessed = true;
    }

    public void Reset() {
        gameObject.GetComponent<Button>().image.sprite = back;
        gameObject.SetActive(true);
        WasGuessed = false;
    }
}
