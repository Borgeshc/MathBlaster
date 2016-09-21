using UnityEngine;
using System.Collections;
using System;

public class ChangeScene : MonoBehaviour {	
	//  This calles up a new GUI with the start menu Options
	public void LoadScene (string SceneName)
    {

        Application.LoadLevel(SceneName);
    }
}
