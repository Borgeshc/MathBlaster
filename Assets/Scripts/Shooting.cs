using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{
    public GameObject missile;          //The missile prefab.
    public GameObject missileSpawn;     //Where the missile will spawn.
    public GameObject explosion;        //The explosoion prefab.

    [HideInInspector]
    public GameObject canvas;                  //Reference to the canvas.
    GameObject clone;                   //Clone to set the instantiated object o.

    void Start ()
    {
        canvas = GameObject.Find("Canvas");     //Set the canvas gameobject to the canvas in the hierarchy.
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))   //On mouse input
        {
            //Spawn the missile.
            clone = Instantiate(missile, missileSpawn.transform.position, missileSpawn.transform.rotation) as GameObject;
            clone.transform.SetParent(canvas.transform);
            //Child the missile to the canvas so that it gets rendered.
        }
	}
}
