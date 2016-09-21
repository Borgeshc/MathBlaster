using UnityEngine;
using System.Collections;

public class WaveManager : MonoBehaviour
{
    public GameObject waveCompleteImage;
    public GameObject asteroidManager;

    [HideInInspector]
    public int destroyedAsteroids;

    [Tooltip("How many asteroids need to be destroyed before Wave 1 is comepleted.")]
    public int wave1Complete;
    public int wave2Complete;

    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {

    }

    public void AsteroidDestroyed()
    {
        destroyedAsteroids++;
        if (destroyedAsteroids == wave1Complete)
        {
            StartCoroutine(WaveCompleted());
        }
    }

    IEnumerator WaveCompleted()
    {
        asteroidManager.GetComponent<ObjectPooling>().stopSpawning = true;
        waveCompleteImage.SetActive(true);
        yield return new WaitForSeconds(5);
        waveCompleteImage.SetActive(false);
        asteroidManager.GetComponent<ObjectPooling>().stopSpawning = false;
    }
}
