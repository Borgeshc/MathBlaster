using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

public class EquationBank
{
    List<EquationUnit> theEquations = new List<EquationUnit>();
    List<string> differentEquationResult = new List<string>();
    //FileInfo sourceFile;

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
        if (temp == 0)
        {
            path = "Assets/Scripts/Equations1.txt";
        }
        else if (temp == 1)
        {
            path = "Assets/Scripts/Equations2.txt";
        }
        else if (temp == 2)
        {
            path = "Assets/Scripts/Equations3.txt";
        }

        if(File.Exists(path))
        {
            try
            {
                var fileContent = File.ReadAllLines(path);

                foreach (var line in fileContent)
                {
                    anEquation = new EquationUnit();

                    if (line != "")
                    {
                        string[] splitString = line.Split('$');
                        anEquation.Equations = splitString[0];
                        anEquation.EquationResult = splitString[1];

                        theEquations.Add(anEquation);
                        }
                    }
                }
            catch(Exception ex)
            {
                Debug.Log(ex);
                success = false;
            }
        }
        return success;
    }

    private int CheckDifficulty()
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
    }
}
