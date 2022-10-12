using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFileController : MonoBehaviour
{
    public GameObject SaveGame1Object;
    public GameObject SaveGame2Object;
    public GameObject SaveGame3Object;

    void Start()
    {
        SaveGame1Object.SetActive(false);
        SaveGame2Object.SetActive(false);
        SaveGame3Object.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
    void Update() 
    {
        string path = Application.persistentDataPath + " GameSave1.sav";
        string path2 = Application.persistentDataPath + " GameSave2.sav";
        string path3 = Application.persistentDataPath + " GameSave3.sav";
        if (File.Exists(path))
        {
            SaveGame1Object.SetActive(true);
        }
        if (File.Exists(path2))
        {
            SaveGame2Object.SetActive(true);
        }
        if (File.Exists(path3))
        {
            SaveGame3Object.SetActive(true);
        }
    }
    /*public void LoadSave1()
    {
        SceneManager.LoadScene("Game");
        SaveSystem.LoadData();
    }*/
}
