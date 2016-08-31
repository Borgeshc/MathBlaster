using UnityEngine;
using System;
using System.Collections;


public class AsteroidMovement : MonoBehaviour
{
    GameObject asteroidManager; //Used to reference the AsteroidManager gameobject.
    public float speed; //The speed at which the asteroid will move.

    void Start()
    {
        asteroidManager = GameObject.Find("AsteroidManager");   //Reference the Asteroid Manager gameobject.
        print(asteroidManager);
        print((0 - (Screen.width / 2)));
    }
	void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed); //Moves the asteroid to the left.
	}

    public void QuadNum(int quadNum)
    {
        //Tells the ObjectPooling script that the quad that the asteroid is currently on is availible for use.
        try
        {
            switch (quadNum)
            {
                case 1:
                    if (transform.position.x <= (0 - (Screen.width / 2)))
                        asteroidManager.GetComponent<ObjectPooling>().quad1InUse = false;
                    break;
                case 2:
                    if (transform.position.x <= (0 - (Screen.width / 2)))
                        asteroidManager.GetComponent<ObjectPooling>().quad2InUse = false;
                    break;
                case 3:
                    if (transform.position.x <= (0 - (Screen.width / 2)))
                        asteroidManager.GetComponent<ObjectPooling>().quad3InUse = false;
                    break;
                case 4:
                    if (transform.position.x <= (0 - (Screen.width / 2)))
                        asteroidManager.GetComponent<ObjectPooling>().quad4InUse = false;
                    break;
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
