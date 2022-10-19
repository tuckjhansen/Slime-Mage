using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuantumBossController : MonoBehaviour
{
    public float Health = 300;
    private SpriteRenderer BossRenderer;
    private BoxCollider2D BossCollider;
    private bool Activated = false;
    private BossDetectorScript bossDetectorScript;
    public float NextAttack;
    private bool Idle = true;
    public GameObject QuantumBossTarrSpike;
    private GameObject Beatrix;
    public bool Attacking = false;
    private BeatrixController beatrixController;
    private bool Attack1 = false;
    private bool Attack2 = false;
    private bool Attack3 = false;
    private bool Attack4 = false;
    public GameObject QuantumBossTarrBubble;
    private Rigidbody2D rb;
    public float TarrBubbleNum;
    public GameObject QuantumSpikeBall;
    public float QuantumSpikeBallNumLimit;
    private Vector2 RespawnPoint;

    void Start()
    {
        BossRenderer = GetComponent<SpriteRenderer>();
        BossCollider = GetComponent<BoxCollider2D>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
        Beatrix = GameObject.FindGameObjectWithTag("player");
        StartCoroutine("Wait");
        beatrixController = Beatrix.GetComponent<BeatrixController>();
        rb = GetComponent<Rigidbody2D>();
        RespawnPoint = transform.position;
    }
    
    void Update()
    {
        if (Health <= 0)
        {
            gameObject.SetActive(false);
            Health = 0;
        }
        if (beatrixController.BeatrixHealth <= 0)
        {
            Activated = false;
            Attacking = false;
            NextAttack = 0;
            Idle = true;
            Health = 300;
            bossDetectorScript.Activated = false;
            TarrBubbleNum = 0;
            QuantumSpikeBallNumLimit = 0;
            transform.position = RespawnPoint;
        }
        if (!Activated && Idle)
        {
            NextAttack = Random.Range(1, 100);
            Idle = false;
        }
        if (NextAttack >= 1 && NextAttack <= 25 && !Attacking && !Idle)
        {
            Instantiate(QuantumBossTarrSpike, new Vector3(Beatrix.transform.position.x, transform.position.y + 6, transform.position.z), Quaternion.identity);
            Instantiate(QuantumBossTarrSpike, new Vector3(Beatrix.transform.position.x + 5, transform.position.y + 6, transform.position.z), Quaternion.identity);
            Instantiate(QuantumBossTarrSpike, new Vector3(Beatrix.transform.position.x - 5, transform.position.y + 6, transform.position.z), Quaternion.identity);
            Attacking = true;
            Attack1 = true;
            Attack2 = false;
            Attack3 = false;
            Attack4 = false;
            StartCoroutine("Wait2");
        }
        if (NextAttack >= 26 && NextAttack <= 50 && !Attacking && !Idle && TarrBubbleNum <= 6)
        {
            Attack1 = false;
            Attack2 = true;
            Attack3 = false;
            Attack4 = false;
            Attacking = true;
            Instantiate(QuantumBossTarrBubble, new Vector2(Random.Range(285, 311), Random.Range(-118, -126)), Quaternion.identity);
            Instantiate(QuantumBossTarrBubble, new Vector2(Random.Range(285, 311), Random.Range(-118, -126)), Quaternion.identity);
            Instantiate(QuantumBossTarrBubble, new Vector2(Random.Range(285, 311), Random.Range(-118, -126)), Quaternion.identity);
            StartCoroutine("Wait3");
            TarrBubbleNum += 3;
        }
        if (NextAttack >= 51 && NextAttack <= 75 && !Attacking && !Idle)
        {
            Attack1 = false;
            Attack2 = false;
            Attack3 = true;
            Attack4 = false;
            Attacking = true;
            transform.position = new Vector3(Beatrix.transform.position.x, Beatrix.transform.position.y + 5, transform.position.z);
            rb.gravityScale = 0;
            StartCoroutine("Wait4");
            StartCoroutine("Wait5");
        }
        if (NextAttack >= 76 && NextAttack <= 100 && !Attacking && !Idle && QuantumSpikeBallNumLimit <= 2)
        {
            Attack1 = false;
            Attack2 = false;
            Attack3 = false;
            Attack4 = true;
            Attacking = true;
            Instantiate(QuantumSpikeBall, new Vector2(Random.Range(285, 311), Random.Range(-118, -126)), Quaternion.identity);
            StartCoroutine("Wait6");
            QuantumSpikeBallNumLimit += 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime") 
        {
            Health -= 5;
        }
            
    }
    IEnumerator Wait()
    {
        while (bossDetectorScript.Activated)
        {
            yield return new WaitForSeconds(3f);
            Activated = true;
        }
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1f);
        Attacking = false;
        while (Attack1)
        {
            yield return new WaitForSeconds(Random.Range(2, 8));
            NextAttack = Random.Range(1, 100);
            Attacking = false;
        }
    }
    IEnumerator Wait3() 
    { 
        while (Attack2)
        {
            yield return new WaitForSeconds(2f);
            NextAttack = Random.Range(1, 100);
            Attacking = false;
        }
    }
    IEnumerator Wait4()
    {
        while (Attack3)
        {
            yield return new WaitForSeconds(4f);
            NextAttack = Random.Range(1, 100);
            Attacking = false;
        }
    }
    IEnumerator Wait5()
    {
        yield return new WaitForSeconds(.5f);
        rb.gravityScale = 6;
    }
    IEnumerator Wait6()
    {
        while (Attack4)
        {
            yield return new WaitForSeconds(.5f);
            NextAttack = Random.Range(1, 100);
            Attacking = false;
        }
    }
}
