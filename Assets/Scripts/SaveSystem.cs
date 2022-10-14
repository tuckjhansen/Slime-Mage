using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    public bool ReadyToSave = false;
    public bool ReadyToLoad = false;
    private string SavePath;

    private void Start()
    {
        SavePath = Application.persistentDataPath + "/GameSave1.Json";
    }
    public void Saving()
    {
        var gameData = FindObjectOfType<GameData>();
        string Json = JsonUtility.ToJson(gameData);
        if (File.Exists(SavePath))
        {
            File.WriteAllText(SavePath, Json);
            Debug.Log("Saved");
        }

        if (!File.Exists(SavePath))
        {
            File.Create(SavePath);
            File.WriteAllText(SavePath, Json);
            Debug.Log("Save File 1 did not exist");
        }
        ReadyToSave = false;
    }
    public void Loading()
    {
        GameData gameData = FindObjectOfType<GameData>();
        BeatrixController beatrixController = FindObjectOfType<BeatrixController>();
        AttackManager attackManager = FindObjectOfType<AttackManager>();
        BossDetectorScript bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        if (File.Exists(SavePath))
        {
            string SaveData = File.ReadAllText(SavePath);
            GameData LoadData = JsonUtility.FromJson<GameData>(SaveData);
            beatrixController.MaxHealth = LoadData.MaxHealth;
            attackManager.MaxMana = LoadData.MaxMana;
            beatrixController.lastSavedLocation[0] = LoadData.LastSavedPosition[0];
            beatrixController.lastSavedLocation[1] = LoadData.LastSavedPosition[1];
            beatrixController.lastSavedLocation[2] = LoadData.LastSavedPosition[2];
            bossDetectorScript.QuantumBossDead = LoadData.QuantumBossDead;
        }
        ReadyToLoad = false;
    }
    void Update()
    {
        if (ReadyToSave)
        {
            Saving();
        }
        if (ReadyToLoad)
        {
            Loading();
        }
    }
}