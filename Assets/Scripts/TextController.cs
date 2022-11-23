using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text pushActivateButtonText;
    public Text pushRestBenchButtonText;
    public Text pushRestBenchButtonText2;
    public Text pushToPlayWhenDeadText;
    public Text enterWindTowerText;
    private int xboxOneController = 0;

    void Update()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            
            if (names[x].Length == 33)
            {
                xboxOneController = 1;

            }
            if (names[x].Length == 0)
            {
                xboxOneController = 0;
            }
        }


        if (xboxOneController == 1)
        {
            pushActivateButtonText.text = "Push Y to Activate";
            pushRestBenchButtonText.text = "Push Y to Rest";
            pushToPlayWhenDeadText.text = "Push Y to Play";
            pushRestBenchButtonText2.text = "Push Y to Rest";
            enterWindTowerText.text = "Push Y to Enter";
        }
        if (xboxOneController <= 0)
        {
            pushActivateButtonText.text = "Push E to Activate";
            pushRestBenchButtonText.text = "Push E to Rest";
            pushToPlayWhenDeadText.text = "Push E to Play";
            pushRestBenchButtonText2.text = "Push E to Rest";
            enterWindTowerText.text = "Push E to Enter";
        }
    }
}
