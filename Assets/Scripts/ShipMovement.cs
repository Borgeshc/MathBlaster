using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour
{
    public Animator shipAnim;
    public GameObject target;   //This will be set when answer is correct.
    public float speed;         //How fast the ship will move to the y.

    [HideInInspector]
    public bool targetFound;           //Changed to true when the target has been found

    Vector3 lastPosition;

	void Start ()
    {
        lastPosition = transform.position;
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
        shipAnim.SetInteger("Move", 0);
    }
    bool MoveTo()
    {
        transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, target.transform.position.y), speed * Time.deltaTime);

        if (lastPosition.y < transform.position.y)
        {
            print("MovedUp");
            lastPosition = transform.position;
            shipAnim.SetInteger("Move", 0);
            shipAnim.SetInteger("Move", 1);
        }
        if (lastPosition.y > transform.position.y)
        {
            print("MovedDown");
            lastPosition = transform.position;
            shipAnim.SetInteger("Move", 0);
            shipAnim.SetInteger("Move", -1);
        }

        if (transform.position.y == target.transform.position.y)
        {
            shipAnim.SetInteger("Move", 0);
            return true;
        }
        return false;
    }
}
