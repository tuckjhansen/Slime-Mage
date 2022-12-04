using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatrixController : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    private bool facingRight = true;
    private float moveDirection;
    public float BeatrixHealth;
    public float MaxHealth = 100;
    public Text BeaHealthText;
    private bool TouchingSlimeSea = false;
    public Camera CamAlive;
    public Camera CamDead;
    public Canvas canvasToTurnOff;
    public Canvas DeadCanvas;
    public SpriteRenderer BeaSpriteRenderer;
    private bool touchingTarr = false;
    private bool hurtWaitOver = true;
    public Slider HealthSlider;
    public Image beatrixOwchImage;
    public Transform beatrixPosition;
    public Vector3 lastSavedLocation = new Vector3(-5.66f, 6.95f);
    private bool touchingBench;
    public Vector3 currentLocation;
    public Image BeatrixRestImage;
    private AttackManager attackManager;
    private bool SavedBefore = false;
    private bool Loadable = true;
    private SaveSystem saveSystem;
    private GameData gameData;
    public bool LoadGame = false;
    public int speed = 1;
    public float money = 0;
    public Text moneyText;
    private bool touchingTarrSpikePlatform = false;
    private Vector3 lastMiniSavedPosition;
    private bool touchingMiniSavePoint = false;
    private bool ableToGetHurtFromTarrSpikes = true;
    public bool playingGameSave1;
    public bool playingGameSave2;
    
    void Start()
    {
        BeaHealthText.text = BeatrixHealth.ToString();
        attackManager = FindObjectOfType<AttackManager>();
        saveSystem = FindObjectOfType<SaveSystem>();
        gameData = FindObjectOfType<GameData>();
    }

    void Update()
    {
        if (touchingTarrSpikePlatform && ableToGetHurtFromTarrSpikes)
        {
            BeatrixHealth -= 10;
            transform.position = lastMiniSavedPosition;
            ableToGetHurtFromTarrSpikes = false;
            StartCoroutine("spikeHurtWait");
        }
        if (touchingMiniSavePoint)
        {
            lastMiniSavedPosition = currentLocation;
        }
        moneyText.text = money.ToString();
        if (LoadGame)
        {
            LoadGame = false;
            saveSystem.Loading();
            BeatrixHealth = MaxHealth;
            transform.position = lastSavedLocation;
        }
        currentLocation = new Vector3(beatrixPosition.position.x, beatrixPosition.position.y);
        BeaHealthText.text = BeatrixHealth.ToString();
        transform.Translate(Input.GetAxis("Move") * 10f * Time.deltaTime * speed, 0f, 0f);
        moveDirection = Input.GetAxis("Move");
        HealthSlider.value = BeatrixHealth / 100;
        if (moveDirection < 0 && facingRight)
        {
            Flip();
        }
        else if (moveDirection > 0 && !facingRight)
        {
            Flip();
        }

        if (Input.GetButton("Jump") && IsGrounded())
        {
            transform.Translate(0f, 14.55f * Time.deltaTime, 0f);
        }

        if (TouchingSlimeSea)
        {
            TouchSlimeSea();
        }

        if (BeatrixHealth <= 0)
        {
            BeatrixHealth = 0;
            CamAlive.enabled = false;
            CamDead.enabled = true;
            canvasToTurnOff.enabled = false;
            DeadCanvas.enabled = true;
            attackManager.Mana = attackManager.MaxMana;
            if (Input.GetButton("Activate"))
            {
                BeatrixHealth = 100;
                transform.position = lastSavedLocation;
                CamAlive.enabled = true;
                CamDead.enabled = false;
                canvasToTurnOff.enabled = true;
                DeadCanvas.enabled = false;
                /*HealthSlider.value = HealthSlider.maxValue;*/
            }
        }
        if (touchingTarr)
        {
            UpdateHealth();
            TouchTarr();
        }
        if (touchingBench && Input.GetButton("Activate"))
        {
            BeatrixHealth = MaxHealth;
            attackManager.Mana = attackManager.MaxMana;
            /*HealthSlider.value = HealthSlider.maxValue;*/
            lastSavedLocation = currentLocation;
            UpdateHealth();
            BeatrixRestImage.enabled = true;
            StartCoroutine("RestImageOffTimer");
            if (!SavedBefore)
            {
                SaveDataFunction();
            }
        }
        if (LoadGame) 
        {
            saveSystem.Loading();
        }
    }

    private bool IsGrounded()
    {
        float extraHeightText = .1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + extraHeightText);
        Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }

        Debug.DrawRay(boxCollider2D.bounds.center, Vector2.down * (boxCollider2D.bounds.extents.y + extraHeightText));

        return raycastHit.collider != null;
    }

    void Flip()
    {
        facingRight = !facingRight;
        BeaSpriteRenderer.flipX = !BeaSpriteRenderer.flipX;
    }

    void OnTriggerEnter2D(Collider2D colliderOfEnemiesAndBenches)
    {
        if (colliderOfEnemiesAndBenches.tag == "Slime Sea")
        {
            TouchingSlimeSea = true;
        }
        if (colliderOfEnemiesAndBenches.tag == "Tarr")
        {
            touchingTarr = true;
        }
        if (colliderOfEnemiesAndBenches.tag == "Bench")
        {
            touchingBench = true;
        }
        if (colliderOfEnemiesAndBenches.tag == "SlimeGiver")
        {
            if (colliderOfEnemiesAndBenches.gameObject.name == "QuantumSlimeGiver")
            {
                attackManager.touchingQuantumGiver = true;
            }
        }
        if (colliderOfEnemiesAndBenches.tag == "TarrSpike")
        {
            touchingTarrSpikePlatform = true;
        }
        if (colliderOfEnemiesAndBenches.tag == "miniSavePoint")
        {
            touchingMiniSavePoint = true;
        }
    }

    void OnTriggerExit2D(Collider2D colliderOfEnemiesAndBenches)
    {
        if (colliderOfEnemiesAndBenches.tag == "Slime Sea")
        {
            TouchingSlimeSea = false;
        }
        if (colliderOfEnemiesAndBenches.tag == "Tarr")
        {
            touchingTarr = false;
        }
        if (colliderOfEnemiesAndBenches.tag == "Bench")
        {
            touchingBench = false;
        }
        if (colliderOfEnemiesAndBenches.tag == "SlimeGiver")
        {
            if (colliderOfEnemiesAndBenches.gameObject.name == "QuantumSlimeGiver")
            {
                attackManager.touchingQuantumGiver = false;
            }
        }
        if (colliderOfEnemiesAndBenches.tag == "TarrSpike")
        {
            touchingTarrSpikePlatform = false;
        }
        if (colliderOfEnemiesAndBenches.tag == "miniSavePoint")
        {
            touchingMiniSavePoint = false;
        }
    }
    void TouchSlimeSea()
    {
        BeatrixHealth = 0;
        BeaHealthText.text = BeatrixHealth.ToString();

    }
    void UpdateHealth()
    {
        BeaHealthText.text = BeatrixHealth.ToString();
    }
    void TouchTarr()
    {
        if (hurtWaitOver == true)
        {
            BeatrixHealth -= 10;
            /*HealthSlider.value -= 0.1f;*/
            hurtWaitOver = false;
            StartCoroutine("DoCheck");
            beatrixOwchImage.enabled = true;
            StartCoroutine("PainCoolDown");
        }
    }
    IEnumerator DoCheck()
    {
        while (hurtWaitOver == false)
        {

            yield return new WaitForSeconds(.7f);
            TarrOwchAgain();
        }
    }
    IEnumerator PainCoolDown()
    {
        yield return new WaitForSeconds(.3f);
        ScreenPainBeatrixOff();
    }
    void TarrOwchAgain()
    {
        hurtWaitOver = true;
    }
    void ScreenPainBeatrixOff()
    {
        beatrixOwchImage.enabled = false;
    }
    void RestImageOff()
    {
        BeatrixRestImage.enabled = false;
    }

    IEnumerator RestImageOffTimer()
    {
        yield return new WaitForSeconds(0.5f);
        RestImageOff();
    }
    public void SaveDataFunction()
    {
        if (!SavedBefore)
        {
            gameData.GameDataVarSetter();
            saveSystem.ReadyToSave = true;
            SavedBefore = true;
            StartCoroutine("SaveWait");
        }
    }
    
    IEnumerator SaveWait()
    {
        yield return new WaitForSeconds(3f);
        SavedBefore = false;
    }
    IEnumerator spikeHurtWait()
    {
        yield return new WaitForSeconds(.5f);
        ableToGetHurtFromTarrSpikes = true;
    }
}
