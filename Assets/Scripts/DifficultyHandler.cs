using UnityEngine;

public class DifficultyHandler : MonoBehaviour
{
    //Stores the difficulty into the Player Prefs throughout the screens
    int difficulty;

    public void Easy()                          //When called uses the first text document of equations
    {
		print ("CALL DAMN IT");
		DifficultyChosen.difficultyChosen = 1;
        return;
    }
    public void Medium()                        //When called uses the second text document of equations
    {
		DifficultyChosen.difficultyChosen = 2;
        return;
    }
    public void Hard()
    {
		DifficultyChosen.difficultyChosen = 3;
        return;
    }
}
