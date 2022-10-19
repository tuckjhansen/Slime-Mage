using UnityEngine;

[System.Serializable]
public class GameData : MonoBehaviour
{
    private BeatrixController beatrixController;
    private AttackManager attackManager;
    private BossDetectorScript bossDetectorScript;
    private reactorScript reactorController;
    private SignController signController1;
    private SignController signController2;
    private SignController signController3;
    public float MaxHealth;
    public float MaxMana;
    public float[] LastSavedPosition;
    public bool QuantumBossDead;
    public int MusicVolume;
    public bool Lore1Read;
    public bool Lore2Read;
    public bool Lore3Read;
    public bool ReactorActivated;
    

    public void GameDataVarSetter()
    {
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        reactorController = FindObjectOfType<reactorScript>();
        signController1 = FindObjectOfType<GameObject>().GetComponent<SignController>();

        MaxHealth = beatrixController.MaxHealth;
        MaxMana = attackManager.MaxMana;
        LastSavedPosition = new float[3];
        LastSavedPosition[0] = beatrixController.lastSavedLocation[0];
        LastSavedPosition[1] = beatrixController.lastSavedLocation[1];
        LastSavedPosition[2] = beatrixController.lastSavedLocation[2];
        QuantumBossDead = bossDetectorScript.QuantumBossDead;
        ReactorActivated = reactorController.Activated;
    }
}


