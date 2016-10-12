using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class EquationWindow : MonoBehaviour
{
    public EquationBank equBank;
    ObjectPooling myPool;

    string[] equations;

    public static List<string> Equations;
    public static List<string> EquationResult;
    List<string> usedEquations;
    int indexedEquation;

    public InputField myInputField;
    private object EventSystemManager;
    GameObject astManager;
    int asteroidCount;

    
    void Awake()
    {
        equBank = new EquationBank();

        //Populate the bank of Equations from the .txt file
        bool success;
        success = equBank.PopulateList();

        equations = new string[equBank.GetNumOfEquations];

    }
    void Start()
    {
        usedEquations = new List<string>(equations);
        astManager = GameObject.Find("AsteroidManager");
    }

    void OnGUI()
    {
        EventSystem.current.SetSelectedGameObject(myInputField.gameObject, null);
        myInputField.OnPointerClick(new PointerEventData(EventSystem.current));

        string userEnterText;

        if (myInputField.isFocused && myInputField.text != null && Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
        {
            userEnterText = myInputField.text;
            astManager.GetComponent<ObjectPooling>().CompareAnswers(userEnterText);
            myInputField.text = "";
        }
    }
    /*int CompareResults(string text)
    {
        int temp = -1;

        for(int i = 0; i < astManager.GetComponent<ObjectPooling>().pooledObjects.Count; i++)
        {
            if(text == astManager.GetComponent<ObjectPooling>().pooledObjects[i].GetComponent<AsteroidID>().answer.ToString())
            {
                temp = astManager.GetComponent<ObjectPooling>().pooledObjects[i].GetComponent<AsteroidID>().ID;
                break;
            }
        }

        return temp;
        
    }*/

    public void ClearInputField()
    {
        myInputField.text = null;
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