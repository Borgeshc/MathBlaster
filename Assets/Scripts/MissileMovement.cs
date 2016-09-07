using UnityEngine;
using System.Collections;
public class MissileMovement : MonoBehaviour
{
    GameObject player;      //Player gameobject
    public float missileSpeed;     //Speed of the missile

	// Use this for initialization
	void Start ()
    {
        player = GameObject.Find("Player");     //Find the player 
	}
	void Update ()
    {
        transform.Translate(Vector2.right * missileSpeed * Time.deltaTime);    //Move to the right based on speed and time.
	}
}
