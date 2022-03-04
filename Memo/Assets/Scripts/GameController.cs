using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int SizeId { get; set; }
    private int score = 0;
    private int rowsNr = 2;
    private int colsNr = 2;
    private Card[] cards;

    private Card gameObjectPattern;
    private Vector2 vectorUp;
    private Vector2 vectorRight;
    private Vector2 vectorAngleUp;
    private Vector2 vectorAngleDown;
    private Vector2[] setupVectors;
    private bool TempBlock = false;

    private static System.Random random = new System.Random();
    void Awake()
    {
        Card.DisplayedCards = new List<Card>();
        if(SizeId >= 1) {
            colsNr = 4;
        }
        if(SizeId >= 2) {
            rowsNr = 4;
        }
        cards = new Card[rowsNr * colsNr];
        gameObjectPattern = Resources.Load("Card", typeof(Card)) as Card;
        var cameraY = Camera.main.orthographicSize * 2f;
        var cameraX = cameraY * Camera.main.aspect;
        
        Canvas cameraMiddle = GameObject.Find("GameCanvas").GetComponent<Canvas>();
        vectorUp = new Vector2(0, 120);
        vectorRight = new Vector2(85, 0);
        vectorAngleUp = (vectorRight + vectorUp) / 2;
        vectorAngleDown = (vectorRight - vectorUp) / 2;

        setupVectors = new Vector2[]{
            vectorAngleUp, vectorAngleDown, -vectorAngleUp, -vectorAngleDown,
            vectorAngleUp + vectorRight, vectorAngleDown + vectorRight, -vectorAngleUp - vectorRight, -vectorAngleDown - vectorRight,
            vectorAngleUp*3, -vectorAngleUp*3, vectorAngleDown*3, -vectorAngleDown*3,
            vectorAngleUp + vectorUp, -vectorAngleUp - vectorUp, vectorAngleDown - vectorUp, -vectorAngleDown + vectorUp,
        };
        for(int i = 0; i < rowsNr * colsNr; i++) {
            cards[i] = Instantiate(gameObjectPattern) as Card;
            cards[i].transform.SetParent (GameObject.Find("GameCanvas").transform, false);
            cards[i].transform.position = setupVectors[i] + (Vector2) cameraMiddle.transform.position;
        }
        cards = cards.OrderBy(x => random.Next()).ToArray();
        for(int i = 0; i < cards.Count(); i++) {
            cards[i].MatchingId = i % (cards.Count() / 2);
            cards[i].SetText($"{i % (cards.Count() / 2)}");
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Card.allDisplayed);
        if(Card.DisplayedCards.Count == 2 && !TempBlock) {
            var chosen = Card.DisplayedCards;
            Debug.Log($"{chosen[0].MatchingId} {chosen[1].MatchingId}");
            if(chosen[0].MatchingId == chosen[1].MatchingId) {
                TempBlock = true;
                score += 10;
                StartCoroutine(WaitToRemove(chosen.ToArray(), 0.5f));
            }
            else
            {
                TempBlock = true;
                score -= 2;
                StartCoroutine(WaitToHide(chosen.ToArray(), 1f));
            }
        }
        GameObject.Find("ScoreText").GetComponent<Text>().text = $"Score: {score}";
    }

    IEnumerator WaitToHide(Card[] chosen, float timeTillDisapear) {
        yield return new WaitForSeconds(timeTillDisapear);
        chosen[0].Hide();
        chosen[1].Hide();
        Card.DisplayedCards = new List<Card>();
        TempBlock = false;
    }
    IEnumerator WaitToRemove(Card[] chosen, float timeTillDisapear) {
        yield return new WaitForSeconds(timeTillDisapear);
        chosen[0].Remove();
        chosen[1].Remove();
        Card.DisplayedCards = new List<Card>();
        TempBlock = false;
    }

    public void BackButtonPressed() {
        SceneManager.LoadScene("MenuScene");
    }
}
