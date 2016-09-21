using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    //Stores the difficulty into the Player Prefs throughout the screens
    int difficulty;

    public void Easy()
    {
        PlayerPrefs.SetInt("Difficulty", 0);
        return;
    }
    public void Medium()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        return;
    }
    //public void Hard()
    //{
    //    PlayerPrefs.SetInt("Difficulty", 2);
    //    return;
    //}
}
