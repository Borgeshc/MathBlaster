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
            StartMyCoroutine();
            targetFound = false;
        }
	}

    void StartMyCoroutine()
    {
        StartCoroutine(WaitUntilFinished());
    }

    IEnumerator WaitUntilFinished()
    {
        yield return new WaitUntil(MoveTo);
    }
    bool MoveTo()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, target.transform.position.y), speed * Time.deltaTime);
        if (transform.position.y == target.transform.position.y)
        {
            return true;
        }
        return false;
    }
}
