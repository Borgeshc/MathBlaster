using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetColor : MonoBehaviour
{
    public Sprite green;
    public Sprite yellow;
    public Sprite red;

    public int color;

	// Use this for initialization
	void Start ()
    {
        color = ColorChosen.colorChosen;
        switch (color)
        {
            case 1:
                GetComponent<Image>().sprite = green;
                break;
            case 2:
                GetComponent<Image>().sprite = yellow;
                break;
            case 3:
                GetComponent<Image>().sprite = red;
                break;
        }
	}
}
