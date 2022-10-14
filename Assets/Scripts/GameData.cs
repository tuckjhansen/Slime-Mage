using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    public void GameDataVarSetter()
    {
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        MaxHealth = beatrixController.MaxHealth;
        MaxMana = attackManager.MaxMana;
        LastSavedPosition = new float[3];
        LastSavedPosition[0] = beatrixController.lastSavedLocation[0];
        LastSavedPosition[1] = beatrixController.lastSavedLocation[1];
        LastSavedPosition[2] = beatrixController.lastSavedLocation[2];
        QuantumBossDead = bossDetectorScript.QuantumBossDead;
    }
    /*public class GameDataStuff
    {
        public float MaxHealth;
        public float MaxMana;
        public float[] LastSavedPosition;
        public bool QuantumBossDead;
    }*/
}


