using UnityEngine;
using System.Collections;

public class AsteroidMovement : MonoBehaviour
{
    public float speed;

	void Update ()
    {
        transform.Translate(Vector2.left * Time.deltaTime * speed);
	}
}
