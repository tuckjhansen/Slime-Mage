using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
     
public class SaveSystem : MonoBehaviour
{
    public bool ReadyToSave = false;
    private string SavePath;
    private BeatrixController beatrixController;
    private AttackManager attackManager;
    private BossDetectorScript bossDetectorScript;
    private reactorScript reactorController;
    private KeyController keyController;

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
        }

        if (!File.Exists(SavePath))
        {
            File.Create(SavePath);
            File.WriteAllText(SavePath, Json);
        }
        ReadyToSave = false;
    }
    public void Loading()
    {
        GameData gameData = FindObjectOfType<GameData>();
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        reactorController = FindObjectOfType<reactorScript>();
        keyController = FindObjectOfType<KeyController>();
        if (File.Exists(SavePath))
        {
            string saveData = File.ReadAllText(SavePath);
            SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveData);
            beatrixController.MaxHealth = saveObject.MaxHealth;
            attackManager.MaxMana = saveObject.MaxMana;
            beatrixController.lastSavedLocation[0] = saveObject.LastSavedPosition[0];
            beatrixController.lastSavedLocation[1] = saveObject.LastSavedPosition[1];
            beatrixController.lastSavedLocation[2] = saveObject.LastSavedPosition[2];
            bossDetectorScript.QuantumBossDead = saveObject.QuantumBossDead;
            reactorController.Activated = saveObject.ReactorActivated;
            keyController.Opened = saveObject.QuantumDoorOpened;
            beatrixController.money = saveObject.money;
            attackManager.hasQuantumSlime = saveObject.quantumSlimePower;
        }
    }
    void Update()
    {
        if (ReadyToSave)
        {
            Saving();
        }
    }
    
    
    private class SaveObject
    {
        public float MaxHealth;
        public float MaxMana;
        public float[] LastSavedPosition;
        public bool QuantumBossDead;
        public bool ReactorActivated;
        public bool QuantumDoorOpened;
        public float money;
        public bool quantumSlimePower;
    }
}
