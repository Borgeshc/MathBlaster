using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    AudioSource myAudioSource;

	void Start ()
    {
        myAudioSource = GetComponent<AudioSource>();
        myAudioSource.Play();

        Destroy(gameObject, 1);
	}
}
