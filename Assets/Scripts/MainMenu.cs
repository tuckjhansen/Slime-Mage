using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObject;
    public GameObject OptionsMenu;
    public GameObject SaveMenu;
    private SaveSystem saveSystem;
    public Text ContinueText;
    public Button ContinueButton;

    private void Start()
    {
        saveSystem = FindObjectOfType<SaveSystem>();
        if (!File.Exists(Application.persistentDataPath + "/GameSave1.Json"))
        {
            ContinueText.color = Color.gray;
            ContinueButton.interactable = false;
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void ContinueGame() 
    {
        if (File.Exists(Application.persistentDataPath + "/GameSave1.Json"))
        {
            SceneManager.LoadScene("Game");
            saveSystem.ReadyToLoad = true;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

