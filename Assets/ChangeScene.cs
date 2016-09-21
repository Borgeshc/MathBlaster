using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {	
	//  This calles up a new GUI with the start menu Options
	public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
        //Application.LoadLevel(SceneName);
    }
}
