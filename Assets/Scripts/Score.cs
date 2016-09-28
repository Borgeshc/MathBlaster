using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text lifeText;
    public Text correctAnswer;
    public GameObject chatBubble;
    public int score;
	private int combo;
    private GameObject player;
    public float health;

    void Start()
    {
        player = GameObject.Find("Player");
        health = player.GetComponent<Health>().health;
        lifeText.text = "Health: " + health;
    }
	public void AddScore ()
	{
		score += 1 + combo;
		combo += 1;

        scoreText.text = "Score: " + score;
	}
	public void LoseLife (GameObject other)
	{
        health = player.GetComponent<Health>().health;
        combo = 0;
        lifeText.text = "Health: " + health;
        StartCoroutine(AnswerDisplay(other));
	}

    IEnumerator AnswerDisplay(GameObject other)
    {
        chatBubble.SetActive(true);
        correctAnswer.enabled = true;
        correctAnswer.text = "Correct Answer: " + other.GetComponent<AsteroidID>().answer;
        yield return new WaitForSeconds(2);
        chatBubble.SetActive(false);
    }
}
