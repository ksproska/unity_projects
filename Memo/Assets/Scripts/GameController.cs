using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static int SizeId { get; set; }
    private int score = 0, rowsNr = 2, colsNr = 2;
    private Card[] cards;

    private Card gameObjectPattern;
    private bool TempBlock = false;
    private Text scoreText, gameEndText;

    private static System.Random random = new System.Random();

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        gameEndText = GameObject.Find("GameEndText").GetComponent<Text>();
        if(SizeId >= 1) { colsNr = 4; }
        if(SizeId >= 2) { rowsNr = 4; }
        SetupCards();
        setNewGame();
    }

    private void SetupCards() {
        cards = new Card[rowsNr * colsNr];
        gameObjectPattern = Resources.Load("Card", typeof(Card)) as Card;
        // var cameraY = Camera.main.orthographicSize * 2f;
        // var cameraX = cameraY * Camera.main.aspect;
        var canvas = GameObject.Find("GameCanvas");
        Canvas cameraMiddle = canvas.GetComponent<Canvas>();
        Vector2 vectorUp = new Vector2(0, 120 + 5);
        Vector2 vectorRight = new Vector2(85 + 5, 0);
        Vector2 vectorAngleUp = (vectorRight + vectorUp) / 2;
        Vector2 vectorAngleDown = (vectorRight - vectorUp) / 2;

        Vector2[] setupVectors = new Vector2[]{
            vectorAngleUp, vectorAngleDown, -vectorAngleUp, -vectorAngleDown,
            vectorAngleUp + vectorRight, vectorAngleDown + vectorRight, -vectorAngleUp - vectorRight, -vectorAngleDown - vectorRight,
            vectorAngleUp*3, -vectorAngleUp*3, vectorAngleDown*3, -vectorAngleDown*3,
            vectorAngleUp + vectorUp, -vectorAngleUp - vectorUp, vectorAngleDown - vectorUp, -vectorAngleDown + vectorUp,
        };

        for(int i = 0; i < rowsNr * colsNr; i++) {
            cards[i] = Instantiate(gameObjectPattern) as Card;
            cards[i].transform.SetParent (canvas.transform, false);
            cards[i].transform.position = setupVectors[i] + (Vector2) cameraMiddle.transform.position;
        }
    }

    private void setNewGame() {
        Card.DisplayedCards = new List<Card>();
        cards = cards.OrderBy(x => random.Next()).ToArray();
        for(int i = 0; i < cards.Count(); i++) {
            cards[i].MatchingId = i % (cards.Count() / 2);
            cards[i].Reset();
        }
    }

    void Update()
    {
        if(score <= -10) {
            EndLost();
        }
        else if(cards.Where(x => !x.WasGuessed).Count() == 0)
        {
            EndWon();
        }
        else {
            runGame();
        }
    }

    private void EndLost() {
        foreach (var item in cards)
            {
                item.gameObject.SetActive(false);
            }
            scoreText.text = $"Score: {score}";
            gameEndText.text = $"You lost";
    }

    private void EndWon() {
        gameEndText.text = $"You won!";
    }

    private void runGame() {
        scoreText.text = $"Score: {score}";
        if(Card.DisplayedCards.Count == 2 && !TempBlock) {
                var chosen = Card.DisplayedCards;
                // Debug.Log($"{chosen[0].MatchingId} {chosen[1].MatchingId}");
            if(chosen.Count() > 0 
            && chosen.Where(x => x.MatchingId == chosen[0].MatchingId).Count() == chosen.Count()) {
                TempBlock = true;
                StartCoroutine(WaitToRemove(chosen.ToArray(), 0.5f));
            }
            else
            {
                TempBlock = true;
                StartCoroutine(WaitToHide(chosen.ToArray(), 1f));
            }
        }
    }

    IEnumerator WaitToHide(Card[] chosen, float timeTillDisapear) {
        score -= 2;
        yield return new WaitForSeconds(timeTillDisapear);
        foreach(var item in chosen) {
            item.Hide();
        }
        Card.DisplayedCards = new List<Card>();
        TempBlock = false;
    }
    IEnumerator WaitToRemove(Card[] chosen, float timeTillDisapear) {
        score += 10;
        yield return new WaitForSeconds(timeTillDisapear);
        foreach(var item in chosen) {
            item.Remove();
        }
        Card.DisplayedCards = new List<Card>();
        TempBlock = false;
    }

    public void BackButtonPressed() {
        SceneManager.LoadScene("MenuScene");
    }
}
