using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject loadingScreen;

    private void Awake()
    {
        instance = this;

        SceneManager.LoadSceneAsync((int)SceneIndexes.MenuScreen, LoadSceneMode.Additive);
    }
    
    public void LoadGame()
    {
        SceneManager.UnloadSceneAsync((int)SceneIndexes.MenuScreen);
        SceneManager.LoadSceneAsync((int)SceneIndexes.Map, LoadSceneMode.Additive);
        SceneManager.LoadSceneAsync((int)SceneIndexes.Game, LoadSceneMode.Additive);
    }
}
