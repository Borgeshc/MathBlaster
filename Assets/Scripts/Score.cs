using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Score : MonoBehaviour
{
    public string loseScene;
    
    public Text scoreText;
    public Text lifeText;
    public Text correctAnswer;
    public GameObject chatBubble;
    public int score;
    public int maxCombo;
    public int health;

    private GameObject player;
    private int combo;
    void Start()
    {
        player = GameObject.Find("Player"); //finding the player and assigigning the GameObject "Player"
        health = player.GetComponent<Health>().health; //getting the health
        lifeText.text = "Health: " + health; //displaying the health
    }

    void Update()
    {
        print(combo);
    }

    public void AddScore()
    {
        score += 1 + combo;  //adding 1 additional point per combo
        combo += 1; //and adding +1 to combo after each correct answer
        if (maxCombo < combo)
            maxCombo += 1;
        scoreText.text = "Score: " + score; //displaying the score
    }
    public void LoseLife(GameObject other)
    {
        //resetting the combo, subtracting one from lives, and displaying the correct answer
        health = player.GetComponent<Health>().health;
        combo = 0;
        lifeText.text = "Health: " + health;
        StartCoroutine(AnswerDisplay(other));
    }

    IEnumerator AnswerDisplay(GameObject other)
    {
        //displaying the correct awnser through a chat bubble
        chatBubble.SetActive(true);
        correctAnswer.enabled = true;
        correctAnswer.text = "Correct Answer: " + other.GetComponent<AsteroidID>().answer;
        yield return new WaitForSeconds(2);
        chatBubble.SetActive(false);
    }
}
