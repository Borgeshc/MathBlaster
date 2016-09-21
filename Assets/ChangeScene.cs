using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

/* * * * * * * * * * * *
 *                     *
 *   Self-Explanatory  *
 *                     *
 * * * * * * * * * * * */

public class ChangeScene : MonoBehaviour
{	
	public void LoadScene (string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
