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
    public Text ContinueText;
    public Button ContinueButton;
    private BeatrixController beatrixController;
    public GameObject MainMenuCanvas;

    private void Start()
    {
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
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(MainMenuCanvas);
            SceneManager.LoadScene("Game");
            StartCoroutine("LoadWait");
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadWait()
    {
        yield return new WaitForSeconds(.05f);
        beatrixController = FindObjectOfType<BeatrixController>();
        beatrixController.LoadGame = true;
        Destroy(MainMenuCanvas);
    }
} 

