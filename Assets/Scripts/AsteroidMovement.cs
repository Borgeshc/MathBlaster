using UnityEngine;
using System;
using System.Collections;


public class AsteroidMovement : MonoBehaviour
{
    GameObject asteroidManager; //Used to reference the AsteroidManager gameobject.
    public float speed; //The speed at which the asteroid will move.
    Rect windowSize;
    //bool that identifies if the asteroid is inside the screen "Rectangle"
    public bool insideRect;
    //Stores the int to re-add the equation to the original list to re-use if possible
    int equationIndex;

    void Start()
    {
        asteroidManager = GameObject.Find("AsteroidManager");   //Reference the Asteroid Manager gameobject.
        print(asteroidManager);
        print((0 - (Screen.width / 2)));

        //Creates a rectangle that identifies the screen height / width
        windowSize = new Rect(0, 0, Screen.width, Screen.height);
        //Spawn points start outside the screen, so starts out as false
        insideRect = false;

    }
	void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed); //Moves the asteroid to the left.

        //Spawned asteroids collide with screen bounds (checks only once)
        if(!insideRect && windowSize.Contains(transform.position))
        {
            insideRect = true;
            WriteEquation();
        }
	}
    void WriteEquation()
    {
        equationIndex = Camera.main.GetComponent<EquationWindow>().ListEquations();
        gameObject.GetComponent<GUIText>().text = Camera.main.GetComponent<EquationWindow>().WriteEquation(equationIndex);
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
