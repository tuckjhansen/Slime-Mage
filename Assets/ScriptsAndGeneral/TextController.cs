using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public Text pushActivateButtonText;
    public Text pushRestBenchButtonText;
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
        }
        if (xboxOneController <= 0)
        {
            pushActivateButtonText.text = "Push S to Activate";
            pushRestBenchButtonText.text = "Push S to Rest";
        }




    }
}
