using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public void StartEasy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
    }
    public void StartMedium()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
    }
    public void StartHard()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
    }
    public void StartInsane()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
    }
}
