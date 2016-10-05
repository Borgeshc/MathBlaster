using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class StartPlayScript : MonoBehaviour
{
    AudioSource mySource;

	// Use this for initialization
	void Start ()
    {
        mySource = GetComponent<AudioSource>();
        if(!mySource.isPlaying)
        {
            mySource.Play();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
