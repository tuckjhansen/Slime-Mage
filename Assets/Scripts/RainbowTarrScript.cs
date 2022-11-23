using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTarrScript : MonoBehaviour
{
    public int tarrhealth = 20;
    public int maxHealht = 20;
    private SpriteRenderer tarrSpriteRenderer;
    public EdgeCollider2D tarrCollider1;
    public BoxCollider2D tarrCollider2;
    private GameObject Beatrix;
    private float speed = 2;
    private float distance;
    private BeatrixController BeatrixController;
    private Rigidbody2D tRigidbody2D;
    private Vector3 respawnPoint;
    private bool loaded = false;
    private bool deadBefore = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime")
        {
            tarrhealth -= 5;
            tarrSpriteRenderer.color = Color.red;
            StartCoroutine("UnRed");
        }
    }
    void Update()
    {
        StartCoroutine("LoadWait");
        if (tarrhealth <= 0)
        {
            tarrhealth = 0;
            tarrSpriteRenderer.enabled = false;
            tarrCollider1.enabled = false;
            tarrCollider2.enabled = false;
        }
        if (tarrhealth <= 0 && !deadBefore)
        {
            deadBefore = true;
            BeatrixController.money += Random.Range(3, 5);
        }
        if (loaded) 
        {
            tRigidbody2D.constraints = RigidbodyConstraints2D.None;
            tRigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            distance = Vector2.Distance(transform.position, Beatrix.transform.position);
            Vector2 direction = Beatrix.transform.position - transform.position;
            if (distance <= 15)
            {
                transform.position = Vector2.MoveTowards(this.transform.position, Beatrix.transform.position, speed * Time.deltaTime);
            }
        }
        
        if (BeatrixController.BeatrixHealth <= 0)
        {
            tarrhealth = maxHealht;
            tarrSpriteRenderer.enabled = true;
            tarrCollider1.enabled = true;
            tarrCollider2.enabled = true;
            gameObject.transform.position = respawnPoint;
            tarrSpriteRenderer.color = Color.white;
            loaded = false;
            deadBefore = false;
        }
        if (tRigidbody2D.velocity.x > -1)
        {
            transform.Rotate(0, 180, 0);
            /*rigidbody2D.angularVelocity = -rigidbody2D.angularVelocity; */
        }
        else 
        {
            transform.Rotate(0, 0, 0);
            /*rigidbody2D.angularVelocity = -rigidbody2D.angularVelocity;*/
        }
    }
    private void Start()
    {
        tarrCollider1 = GetComponent<EdgeCollider2D>();
        tarrCollider2 = GetComponent<BoxCollider2D>();
        tarrSpriteRenderer = GetComponent<SpriteRenderer>();
        Beatrix = GameObject.FindGameObjectWithTag("player");
        BeatrixController = FindObjectOfType<BeatrixController>();
        respawnPoint = new Vector3(transform.position.x, transform.position.y);
        tRigidbody2D = GetComponent<Rigidbody2D>();
        tRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;
        tRigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
    IEnumerator UnRed()
    {
        yield return new WaitForSeconds(.2f);
        tarrSpriteRenderer.color = Color.white;
    }
    IEnumerator LoadWait()
    {
        while (!loaded)
        {
            yield return new WaitForSeconds(1.6f);
            loaded = true;
        }
    }
}
