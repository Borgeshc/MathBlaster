using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *   This class is used to control the actual movement of the asteroids    *
 *   This uses a equation bank that populates a list of equations from a   *
 *   simple .txt file located in the build. When populating the list,      *
 *   each equation is stored in a class, as well as an array inside the    *
 *   bank. So the Equation Window's job is to locate the index of the      *
 *   bank to locate the correct answer. It connects here by retrieving     *
 *   the actual equation string, and stores it in the Text Asset attached  *
 *   to the child object.                                                  *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */
public class AsteroidMovement : MonoBehaviour
{
    GameObject asteroidManager;         //Used to reference the AsteroidManager gameobject.
    public float speed;                 //The speed at which the asteroid will move.
    Rect windowSize;
    
    public bool insideRect;             //bool that identifies if the asteroid is inside the screen "Rectangle"
    
    int equationIndex;                  //Stores the int to re-add the equation to the original list to re-use if possible
    int inQuadNum;

    ObjectPooling objectPooling;
    EquationWindow myWindow;

    void Start()
    {
        asteroidManager = GameObject.Find("AsteroidManager");               //Reference the Asteroid Manager gameobject.
        objectPooling = asteroidManager.GetComponent<ObjectPooling>();

        windowSize = new Rect(0, 0, Screen.width, Screen.height);           //Creates a rectangle that identifies the screen height / width
        
        insideRect = false;                                                 //Spawn points start outside the screen, so starts out as false
        myWindow = Camera.main.GetComponent<EquationWindow>();              //Instead of creating an instance, we're simply grabbing an instance

    }
	void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);         //Moves the asteroid to the left.
        
        if (!insideRect && windowSize.Contains(transform.position))         //Spawned asteroids collide with screen bounds (checks only once)
        {
            insideRect = true;                                              //Inside the Camera view
            WriteEquationOnAsteroid();                                      //Obtains equation from Equation Window, then sets the Test Asset string
        }
        else if (insideRect && !windowSize.Contains(transform.position))
        {
            insideRect = false;
            switch(inQuadNum)                                               //Tells the asteroid manager what lane it is in and lets it know it is done using that lane.
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
            objectPooling.objectCount--;                                    //Reduces the count of active objects in the scene.
            gameObject.SetActive(false);                                    //Turns off the gameobject.
        }
    }
    void WriteEquationOnAsteroid()
    {
        equationIndex = Camera.main.GetComponent<EquationWindow>().ListEquations();                                                     //Generates a Random number based on total possible equations
        gameObject.GetComponentInChildren<Text>().text = Camera.main.GetComponent<EquationWindow>().WriteEquation(equationIndex);       //Passes that random number to get an equation
        gameObject.GetComponent<AsteroidID>().answer = int.Parse(myWindow.equBank.GetEquationResult(equationIndex));                    //Sets the AsteroidID's answer int to the equation for assessment
    }
    public void QuadNum(int quadNum)
    {
        inQuadNum = quadNum;    //Defines the lane the object is in.
    }
}
