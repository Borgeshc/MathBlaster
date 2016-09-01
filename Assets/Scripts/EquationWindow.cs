using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

public class EquationWindow : MonoBehaviour
{
    EquationBank equBank;

    string[] equations;

    public static List<string> Equations;
    public static List<string> EquationResult;
    List<string> usedEquations;
    int indexedEquation;
    public int numOfAsteroids = 4;

    //private static StreamReader myStreamReader;
    //private static StreamWriter myStreamWriter;

    public InputField myInputField;
    private object EventSystemManager;

    void Awake()
    {
        equBank = new EquationBank();

        //Populate the bank of Equations from the .txt file
        //bool success;
        //success = equBank.PopulateList();

        equations = new string[equBank.GetNumOfEquations];

        /*if (success)
        {
            for (int i = 0; i < equBank.GetNumOfEquations; i++)
            {
                string shortEquations = equBank.GetEquations(i);
            }
        }*/
    }
    void Start()
    {
        usedEquations = new List<string>(equations);
    }

    void OnGUI()
    {
        EventSystem.current.SetSelectedGameObject(myInputField.gameObject, null);
        myInputField.OnPointerClick(new PointerEventData(EventSystem.current));

        if (myInputField.isFocused && myInputField.text != null && Input.GetKey(KeyCode.Return))
        {
            Debug.Log("Test the Text entered : " + myInputField.text);
            for(int i = 0; i < equBank.GetNumOfEquations; i++)
            {
                Debug.Log("Equation is: " + equBank.GetEquations(i));
                Debug.Log("Equation Result is: " + equBank.GetEquationResult(i));
            }
        }
        
    }

    public int ListEquations()
    {
        //List<string> usedEquations = new List<string>(equations);
        int indexedEquation = UnityEngine.Random.Range(0, equations.Length);

        if (!usedEquations.Contains(equBank.GetEquations(indexedEquation)))
        {
            usedEquations.Add(equBank.GetEquations(indexedEquation));
        }
        return indexedEquation;
    }
    public string WriteEquation(int index)
    {
        return equBank.GetEquations(index);
    }
    public void UnlistEquations(int equationInt)
    {
        usedEquations.Remove(equBank.GetEquations(equationInt));
    }

}