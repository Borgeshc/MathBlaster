using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public GameObject target;   //This will be set when answer is correct.
    public float speed;         //How fast the ship will move to the y.

    [HideInInspector]
    public bool targetFound;           //Changed to true when the target has been found
	void Start ()
    {
	
	}
	
	void Update ()
    {
        if (targetFound)
        {
            Vector2.MoveTowards(transform.position, new Vector2(target.transform.position.y, transform.position.x), speed * Time.deltaTime);
            targetFound = false;
        }
	}
}
