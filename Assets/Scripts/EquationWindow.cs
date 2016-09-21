using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

/* * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *                                                       *
 *   This class is what will handle the actual OnGUI()   *
 *   using the InputField.                               *
 *                                                       *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

public class EquationWindow : MonoBehaviour
{
    public EquationBank equBank;                                    //Name of the instance of the bank. The ONLY instance NEEDED
    ObjectPooling myPool;                                           //Used in reference for asteroid movement and ID

    string[] equations;                                             //Used to get a list of the equations in total. Only the length here is used

    //public static List<string> Equations;
    //public static List<string> EquationResult;
    int indexedEquation;                                            //This is the random number generator that tells us which equation to pull

    public InputField myInputField;                                 //This is the field where players input their answers
    private object EventSystemManager;                              //Used to set mouse focus to the text field from the start
    GameObject astManager;                                          //Grabs the reference of the Asteroid Manager object

    void Awake()
    {
        equBank = new EquationBank();                               //Actually make the Bank here
        
        bool success;                                               //Populate the bank of Equations from the .txt file
        success = equBank.PopulateList();

        equations = new string[equBank.GetNumOfEquations];          //Used to get the maximum index of equations

    }
    void Start()
    {
        astManager = GameObject.Find("AsteroidManager");            //Finds the Asteroid Manager
    }

    void OnGUI()
    {
        EventSystem.current.SetSelectedGameObject(myInputField.gameObject, null);           //Sets the focus of the mouse to the input field
        myInputField.OnPointerClick(new PointerEventData(EventSystem.current));             //Resets upon clicking elsewhere

        int temp = PlayerPrefs.GetInt("Difficulty");                                        //Testing purposes to check if PlayerPrefs are set correctly
        print(temp);

        string userEnterText;                                                                           //Obtain the players answer

        if (myInputField.isFocused && myInputField.text != null && Input.GetKey(KeyCode.KeypadEnter))        //If statement checking if focus is on the input field, and the text isn't null, upon Keypad enter
        {
            userEnterText = myInputField.text;                                                              //Sets the players answer
            astManager.GetComponent<ObjectPooling>().CompareAnswers(userEnterText);                         //Compares the answers in the ObjectPooling class
        }
    }

    public int ListEquations()
    {
        int indexedEquation = UnityEngine.Random.Range(0, equations.Length);                                //RNG

        return indexedEquation;
    }
    public string WriteEquation(int index)                                                                  //Takes the RNG and retrieves the Equation
    {
        return equBank.GetEquations(index);
    }
}