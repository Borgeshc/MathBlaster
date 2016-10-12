using UnityEngine;

public class AsteroidID : MonoBehaviour
{
    public int ID;
	public int answer;

	// Use this for initialization
	void Start ()
    {
		answer = Camera.main.GetComponent<EquationWindow> ().Answer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
