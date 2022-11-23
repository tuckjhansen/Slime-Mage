using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    private BeatrixController beatrixController;
    private AttackManager attackManager;
    private BossDetectorScript bossDetectorScript;
    private reactorScript reactorController;
    private KeyController keyController;
    public float MaxHealth;
    public float MaxMana;
    public float[] LastSavedPosition;
    public bool QuantumBossDead;
    public bool ReactorActivated;
    public bool QuantumDoorOpened;
    public float money;
    public bool quantumSlimePower;

    public void GameDataVarSetter()
    {
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        reactorController = FindObjectOfType<reactorScript>();
        keyController = FindObjectOfType<KeyController>();

        MaxHealth = beatrixController.MaxHealth;
        MaxMana = attackManager.MaxMana;
        LastSavedPosition = new float[3];
        LastSavedPosition[0] = beatrixController.lastSavedLocation[0];
        LastSavedPosition[1] = beatrixController.lastSavedLocation[1];
        LastSavedPosition[2] = beatrixController.lastSavedLocation[2];
        QuantumBossDead = bossDetectorScript.QuantumBossDead;
        ReactorActivated = reactorController.Activated;
        QuantumDoorOpened = keyController.Opened;
        money = beatrixController.money;
        quantumSlimePower = attackManager.hasQuantumSlime;
    }
}


