using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent (typeof (AudioSource))]
public class HoverSound : MonoBehaviour
{
    AudioSource mySource;

    void Awake()
    {
        if(!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
    }
	// Use this for initialization
	void Start ()
    {
        mySource = GetComponent<AudioSource>();
	}
    public void PlayHoverSound(AudioClip myClip)
    {
        mySource.clip = myClip;
        print("On Mouse Hover");
        mySource.Play();
    }
    public void PlaySelectSound(AudioClip myClip)
    {
        mySource.clip = myClip;
        print("On Submit");
        mySource.Play();
    }

}
