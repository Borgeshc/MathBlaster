using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class EquationBank
{
    List<EquationUnit> theEquations = new List<EquationUnit>();
    List<string> differentEquationResult = new List<string>();

    public int GetNumOfEquations
    {
        get { return theEquations.Count; }
    }
    public string GetEquations(int index)
    {
        return theEquations[index].Equations;
    }
    public string GetEquationResult(int index)
    {
        return theEquations[index].EquationResult;
    }
    public void SetEquationResult(int index, string category)
    {
        theEquations[index].EquationResult = category;
    }
    public bool PopulateList()
    {
        EquationUnit anEquation;
        bool success = true;
        string path = "";

        int temp = PlayerPrefs.GetInt("Difficulty");

        //Requires the PlayerPrefs int for difficulty
        if (temp == 0)                                                      //Easy Mode
        {
            path = "Assets/Scripts/Equations1.txt";
        }
        else if (temp == 1)                                                 //Normal Mode
        {
            path = "Assets/Scripts/Equations2.txt";
        }
        else if (temp == 2)                                                 //Hard Mode
        {
            path = "Assets/Scripts/Equations3.txt";
        }
        //else if (temp == 3)                                                 //Insane Mode
        //{
        //    path = "Assets/Scripts/Equations4.txt";
        //}
        if (File.Exists(path))                                              //Attempts to locate file listed above
        {
            try
            {
                var fileContent = File.ReadAllLines(path);                  //Reads all lines to find EoF

                foreach (var line in fileContent)                           //foreach loop to read each line individually
                {
                    anEquation = new EquationUnit();                        //Creating an instance of EquationUnit

                    if (line != "")                                         //Not finding EoF
                    {
                        string[] splitString = line.Split('$');             //Converts string to an array, based on the $
                        anEquation.Equations = splitString[0];              //First index of array is equation
                        anEquation.EquationResult = splitString[1];         //Second/Last index of array is result

                        theEquations.Add(anEquation);                       //Adds the finished equation to the Bank
                    }
                }
            }
            catch (Exception ex)                                             //If we hit this, error occurs with finding file most likely
            {
                Debug.Log(ex);                                              //Prints the actual error
                success = false;
            }
        }
        return success;
    }

    /*private int CheckDifficulty()
    {
        int temp = PlayerPrefs.GetInt("Difficulty");
        if (temp == 0)
        {
            return 0;
        }
        else if (temp == 1)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }*/
}
