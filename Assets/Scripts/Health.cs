using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public string loseScene;
    public int health;
    Score score;
    GameObject asteroidManager;
    ObjectPooling pooling;
    void Start()
    {
        score = Camera.main.GetComponent<Score>();
        asteroidManager = GameObject.Find("AsteroidManager");
        pooling = asteroidManager.GetComponent<ObjectPooling>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Asteroid")
        {
            health--;
            score.LoseLife(other.gameObject);
            if (health <= 0)
            {
                PlayerPrefs.SetInt("Score", score.score);
                PlayerPrefs.SetInt("Combo", score.maxCombo);
                PlayerPrefs.SetInt("Correct", pooling.correctAnswers);
                PlayerPrefs.SetInt("Total", pooling.totalQuestions);
                PlayerPrefs.SetInt("Wave", Camera.main.GetComponent<WaveManager>().waveCount);
                SceneManager.LoadScene(loseScene);
            }
        }
    }
}
