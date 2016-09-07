using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {


    //integers
    private int targetScore;
    [HideInInspector]
    public int score;
    [HideInInspector]
    public int vipScore;
    public int life;

	private int combo;
	private float bonusTime;


	//floats
    private float wait;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	public void Update ()
    {
         
        //once target score has been achieved, the next level will begin
    if (score >= targetScore)
        {
            //waiting five seconds before loading
            wait = Time.time + 5;
//            if (Time.time > wait)
//             SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        //once lives reaches 0, the game will end in defeat
        if (life <= 0)
        {
            //waiting five seconds before loading
            wait = Time.time + 5;
//            if (Time.time > wait)
//                 SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	
	}

	public void AddScore ()
	{
		score += 5 + combo;
		combo += 1;
		if (Time.time > bonusTime)
		bonusTime = Time.time + 3;

	}

	public void LoseLife ()
	{
		life -= 1;
		combo = 0;
		bonusTime = 0;

	}

	void OnGUI ()
	{
	}
}
