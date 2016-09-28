using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultScripts : MonoBehaviour {

	public GameObject pannel;
	public GameObject score;
	public GameObject health;
	public GameObject wave;

	public Text resultScore;
	public Text resultWave;
	public Text resultLevel;
	public Text resultLives;
	public Text resultMissed;
	public Text resultCorrect;
	public Text resultEquations;
	public Text resultCombo;

	public Animator anim;

	Score scoreManager;
	// Use this for initialization

	void Awake ()
	{
		scoreManager = Camera.main.GetComponent<Score> ();

		pannel.SetActive (false);
		score.SetActive (false);
		health.SetActive (false);
		wave.SetActive (false);

		resultScore.text = "Score: " + scoreManager.score; //displaying all the stats
		resultLives.text = "Lives: " + scoreManager.health; 
		resultWave.text = "Wave: " + wave; 
		resultCorrect.text = "Correct: " + wave; 
		resultMissed.text = "Missed: " + wave; 
		resultEquations.text = "Total: " + wave; 
		resultCombo.text = "Combo: " + scoreManager.maxCombo; 
		anim.SetTrigger ("SetResults");
	}
	
	// Update is called once per frame
	void Update () {
		//lifeText.text = "Health: " + health; 
	}
}
