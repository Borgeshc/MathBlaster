using UnityEngine;
using System.Collections;

public class ClearPrefs : MonoBehaviour
{
	void Awake ()
    {
        PlayerPrefs.DeleteAll();
	}
}
