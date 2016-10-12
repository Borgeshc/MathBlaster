using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    //Stores the difficulty into the Player Prefs throughout the screens
    int difficulty;

    public void Easy()                          //When called uses the first text document of equations
    {
        ColorChosen.colorChosen = 1;
        PlayerPrefs.SetInt("Difficulty", 0);
        return;
    }
    public void Medium()                        //When called uses the second text document of equations
    {
        ColorChosen.colorChosen = 2;
        PlayerPrefs.SetInt("Difficulty", 1);
        return;
    }
    public void Hard()
    {
        ColorChosen.colorChosen = 3;
        PlayerPrefs.SetInt("Difficulty", 2);
        return;
    }
}
