using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

public class SaveSystem /* : MonoBehaviour*/
{
    public static void Save()
    {
        string dataPath = Application.persistentDataPath + "/GameSave1.sav";
        var serializer = new XmlSerializer(typeof(GameData));
        var stream = new FileStream(dataPath, FileMode.OpenOrCreate);
        serializer.Serialize(stream, dataPath);
        stream.Close();
        Debug.Log("Saved");
    }
}

[System.Serializable]
public class GameData : MonoBehaviour
{
    private BeatrixController beatrixController;
    private AttackManager attackManager;
    private BossDetectorScript bossDetectorScript;
    public float MaxHealth;
    public float MaxMana;
    public float[] LastSavedPosition;
    public bool QuantumBossDead;

    void Start()
    {
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        MaxHealth = beatrixController.MaxHealth;
        MaxMana = attackManager.MaxMana;
        LastSavedPosition = new float[3];
        LastSavedPosition[0] = beatrixController.lastSavedLocation[0];
        LastSavedPosition[2] = beatrixController.lastSavedLocation[2];
        LastSavedPosition[3] = beatrixController.lastSavedLocation[3];
        QuantumBossDead = bossDetectorScript.QuantumBossDead;
    }
}


