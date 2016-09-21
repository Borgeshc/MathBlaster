using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public GameObject waveCompleteImage;        //Wave completed image
    public GameObject asteroidManager;          //Reference to the asteroid manager

    [HideInInspector]
    public int destroyedAsteroids;              //This keeps track of the destroyed asteroid count

    [Tooltip("How many asteroids need to be destroyed before Wave is comepleted.")]   //number of destroyed asteroids till complete
    int waveComplete = 2;
    [Tooltip("This is the number of how many more asteroids spawn after each wave.")]
    public int spawnIncreaseAmount;
    [Tooltip("How much the speed of the asteroids go up by at the end of each wave.")]
    public int speedIncreaseAmount;

    ObjectPooling objectPooling;

    void Start()
    {
        objectPooling = asteroidManager.GetComponent<ObjectPooling>();
    }

    public void AsteroidDestroyed()
    {
        destroyedAsteroids++;                      //Adds to the number of destroyed asteroids.
        print(destroyedAsteroids + " asteroids destroyed!");

        if (destroyedAsteroids == waveComplete)    //if the number of destroyed asteroid reaches the wave complete number
        {
            StartCoroutine(WaveCompleted());
        }
    }

    IEnumerator WaveCompleted()     
    {
        spawnIncreaseAmount = spawnIncreaseAmount * 2;
        waveComplete = waveComplete + spawnIncreaseAmount;                      //Increase the spawn amount each wave.

        foreach (GameObject go in objectPooling.pooledObjects)
        {
            go.GetComponent<AsteroidMovement>().speed = go.GetComponent<AsteroidMovement>().speed + speedIncreaseAmount;
        }
        objectPooling.stopSpawning = true;      //Stops the manager from spawning
        waveCompleteImage.SetActive(true);                                      //turns on the comepleted wave image
        yield return new WaitForSeconds(3);                                     //waits for 5 seconds
        waveCompleteImage.SetActive(false);                                     //turns the completed wave image off
        objectPooling.stopSpawning = false;     //turns on the spawning
    }
}
