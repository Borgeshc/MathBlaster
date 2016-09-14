using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayTimeAndscore : MonoBehaviour
{
    float totalPoints = 6969;
    float timeTaken = 30.2f;
    public Text things;
	// Update is called once per frame
	public void OnGUI ()
    {
     things.text = ("You scored:" + " " + totalPoints + " points and you took:" + " " + timeTaken + " seconds long to complete");
	}
}
