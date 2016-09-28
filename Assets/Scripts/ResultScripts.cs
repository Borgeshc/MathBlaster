using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScripts : MonoBehaviour
{
	public Text resultScore;
	public Text resultWave;
	public Text resultCorrect;
	public Text resultEquations;
	public Text resultCombo;
    public Text resultLevel;

	Score scoreManager;
	void Awake ()
	{
        //displays all the stats
        resultScore.text = "Score: " + PlayerPrefs.GetInt("Score"); 
		resultWave.text = "Wave: " + PlayerPrefs.GetInt("Wave");
        resultCorrect.text = "Correct: " + PlayerPrefs.GetInt("Correct");
		resultEquations.text = "Total: " + PlayerPrefs.GetInt("Total");

        switch (PlayerPrefs.GetInt("Difficulty"))
        {
            case 0:
                resultLevel.text = "Difficulty: Easy";
                break;
            case 1:
                resultLevel.text = "Difficulty: Medium";
                break;
            case 2:
                resultLevel.text = "Difficulty: Hard";
                break;
            case 3:
                resultLevel.text = "Difficulty: Insane";
                break;
            default:
                resultLevel.text = "Stop hacking the game";
                break;
        }
		resultCombo.text = "Combo: " + PlayerPrefs.GetInt("Combo"); 
	}
}
