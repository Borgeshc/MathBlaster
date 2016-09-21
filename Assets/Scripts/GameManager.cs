using UnityEngine;
using System.Collections;

/* * * * * * * * * * * * * * * * * * * * * * * * * * *
 *                                                   *
 *   This class will only set the difficulty upon    *
 *   the PlayerPrefs which are assigned on the menu  *
 *   at the start of the game.                       *
 *                                                   *
 * * * * * * * * * * * * * * * * * * * * * * * * * * */

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
