using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
   // public string loseScene;
    public int health;
    Score score;

    void Start()
    {
        score = Camera.main.GetComponent<Score>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Asteroid")
        {
            health--;
            score.LoseLife(other.gameObject);
//            if (health < 0)
//            {
//                SceneManager.LoadScene(loseScene);
//            }
        }
    }
}
