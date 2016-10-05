using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class WavePlayAudio : MonoBehaviour
{
    AudioSource mySource;
    public AudioClip myClip;

	// Use this for initialization
	void Awake ()
    {
        if (!GetComponent<AudioSource>())
            gameObject.AddComponent<AudioSource>();

        mySource = GetComponent<AudioSource>();
	}
	
	void OnEnable()
    {
        mySource.clip = myClip;
        mySource.Play();
    }
}
