using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject OptionsMenu;
    /*public GameObject AchieveMentsMenu;*/
    public GameObject SaveMenu;

    public void PlayGame()
    {
        MainMenuObject.SetActive(false);
        OptionsMenu.SetActive(false);
        /*AchieveMentsMenu.SetActive(false);*/
        SaveMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

