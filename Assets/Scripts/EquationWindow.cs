using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class EquationWindow : MonoBehaviour
{
    public EquationBank equBank;
    ObjectPooling myPool;

    string[] equations;
	string equation;

    public static List<string> Equations;
    public static List<string> EquationResult;
    List<string> usedEquations;
    int indexedEquation;

    public InputField myInputField;
    private object EventSystemManager;
    GameObject astManager;
    int asteroidCount;
	public int answer; //We'll be using this this for the answer -- which we will use to be displayed on the asteroid
	bool isAnswered;

	public int difficulty;

	public string Equation
	{
		get{return equation;}
		set{equation = value;}
	}

	public int Answer
	{
		get{return answer;}
		set{answer = value;}
	}

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
		//difficulty = 												//Get the difficulty from Prefs GO

		if (DifficultyChosen.difficultyChosen == 1) 						//easy
		{ 		
			print ("Happened");
			EasyEquation ();
		} 
		else if  (DifficultyChosen.difficultyChosen == 2) 						//medium
		{ 		
			print ("Happened");
			mediumEquation ();
		} 

		else if (DifficultyChosen.difficultyChosen == 3) 						//hard
		{ 		
			print ("Happened");
			EasyEquation ();
		} 


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

    public void ListEquations()
    {
        /*
         * //List<string> usedEquations = new List<string>(equations);
        int indexedEquation = UnityEngine.Random.Range(0, equations.Length);

        if (!usedEquations.Contains(equBank.GetEquations(indexedEquation)))
        {
            usedEquations.Add(equBank.GetEquations(indexedEquation));
        }
        return indexedEquation;
		*/


    }
	//display correct answer
    public string WriteEquation(string index)
    {
		return index;
    }
    public void UnlistEquations(int equationInt)
    {
        usedEquations.Remove(equBank.GetEquations(equationInt));
    }

	//this is the function that will randomize the easy equations
	public void EasyEquation()
	{
		print ("Easy Equations was called");
		//randomizing whether we are adding or subtracting
		//this variable (int) acts as a random bool (1== true and 0 == false)
		int adding = Random.Range (0, 1);

		//here we are randomizing both integers
		int randomInt1 = Random.Range (0, 10);
		int randomInt2 = Random.Range (0, 10);

		print ("First int is: " + randomInt1 + "Second int is: " + randomInt2);
		//if bool is true
		if (adding == 1) 
		{
			//determining the outcome based on whether adding is 1 or 0 (true or false)
			answer = randomInt1 + randomInt2;
			Answer = answer;
			print (answer);
			//turning our answer into a string
			equation = randomInt1 + randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " + " + randomInt2.ToString ();
			print (equation);
		} 
		else //if bool is false
		{
			//making sure that we do not recieve a negative number in case of subtraction
			randomInt2 = Random.Range (0, randomInt1);
			//if adding is false
			answer = randomInt1 - randomInt2;
			Answer = answer;
			print (answer);
			equation = randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " - " + randomInt2.ToString ();
			print (equation);
		}
	}
	//medium level function
	public void mediumEquation()
	{
		//randomizing whether we are adding, subtracting, multiplying, or dividing
		//this variable (int) acts as a random bool (0 is add, 1 is subtract, 2 is multiply, and 3 is divide))
		int adding = Random.Range (0, 3);
		print (adding);
		//here we are randomizing both integers
		int randomInt1 = Random.Range (0, 20);
		int randomInt2 = Random.Range (0, 20);

		print ("First int is: " + randomInt1 + "Second int is: " + randomInt2);
		//if bool is true
		if (adding == 0) 
		{
			//determining the outcome based on whether adding is 1 or 0 (true or false)
			answer = randomInt1 + randomInt2;
			Answer = answer;
			print (answer);
			//turning our answer into a string
			equation = randomInt1 + randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " + " + randomInt2.ToString ();
		} 
		else if (adding == 1) 
		{
			randomInt1 = Random.Range (0, 50);
			randomInt2 = Random.Range (0, 50);
			//making sure that we do not recieve a negative number in case of subtraction
			randomInt2 = Random.Range (0, randomInt1);
			//if adding is false
			answer = randomInt1 - randomInt2;
			Answer = answer;
			print (answer);
			equation = randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " - " + randomInt2.ToString ();
		}
		else if (adding == 2) 
		{
			randomInt1 = Random.Range (0, 12);
			randomInt2 = Random.Range (0, 12);
			//making sure that we do not recieve a negative number in case of subtraction
			randomInt2 = Random.Range (0, randomInt1);
			//if adding is false
			answer = randomInt1 * randomInt2;
			Answer = answer;
			print (answer);
			equation = randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " x " + randomInt2.ToString ();
		}
		else if (adding == 3) 
		{
			//making sure that we do not recieve a negative number in case of subtraction
			randomInt1 = Random.Range (1, 12);
			randomInt2 = Random.Range (1, 12);
			//if adding is false
			answer = randomInt1 * 12 / randomInt2;
			Answer = answer;
			print (answer);
			equation = randomInt2.ToString (); //turning the equation into a string
			Equation = randomInt1.ToString ()+  " - " + randomInt2.ToString ();
		}
	}
}