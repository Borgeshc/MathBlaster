using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class AsteroidMovement : MonoBehaviour
{
    GameObject asteroidManager; //Used to reference the AsteroidManager gameobject.
    public float speed; //The speed at which the asteroid will move.
    Rect windowSize;
    //bool that identifies if the asteroid is inside the screen "Rectangle"
    public bool insideRect;
    //Stores the int to re-add the equation to the original list to re-use if possible
    int equationIndex;
    int inQuadNum;
    //EquationWindow myWindow;
    ObjectPooling objectPooling;
    EquationWindow myWindow;

    void Start()
    {
        asteroidManager = GameObject.Find("AsteroidManager");   //Reference the Asteroid Manager gameobject.
        objectPooling = asteroidManager.GetComponent<ObjectPooling>();
        //myWindow = new EquationWindow();

        //Creates a rectangle that identifies the screen height / width
        windowSize = new Rect(0, 0, Screen.width, Screen.height);
        //Spawn points start outside the screen, so starts out as false
        insideRect = false;

        myWindow = Camera.main.GetComponent<EquationWindow>();

    }
	void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed); //Moves the asteroid to the left.
        //Spawned asteroids collide with screen bounds (checks only once)
        if (!insideRect && windowSize.Contains(transform.position))
        {
            insideRect = true;
            WriteEquationOnAsteroid();
        }
        else if (insideRect && !windowSize.Contains(transform.position))
        {
            insideRect = false;
            switch(inQuadNum)   //Tells the asteroid manager what lane it is in and lets it know it is done using that lane.
            {
                case 1:
                    objectPooling.quad1InUse = false;
                    break;
                case 2:
                    objectPooling.quad2InUse = false;
                    break;
                case 3:
                    objectPooling.quad3InUse = false;
                    break;
                case 4:
                    objectPooling.quad4InUse = false;
                    break;
            }
            objectPooling.objectCount--;    //Reduces the count of active objects in the scene.
            gameObject.SetActive(false);    //Turns off the gameobject.
        }
    }
    void WriteEquationOnAsteroid()
    {
        equationIndex = Camera.main.GetComponent<EquationWindow>().ListEquations();
        //gameObject.GetComponentInChildren<Text>().text = "2 + 2 = ?";
        gameObject.GetComponentInChildren<Text>().text = Camera.main.GetComponent<EquationWindow>().WriteEquation(equationIndex);
        gameObject.GetComponent<AsteroidID>().answer = int.Parse(myWindow.equBank.GetEquationResult(equationIndex));
        //print("The answer attached to the asteroid is: " + gameObject.GetComponent<AsteroidID>().answer);
    }
    public void QuadNum(int quadNum)
    {
        inQuadNum = quadNum;    //Defines the lane the object is in.
    }
}
