using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainbowTarrScript : MonoBehaviour
{
    public int tarrhealth = 20;
    private SpriteRenderer tarrSpriteRenderer;
    public EdgeCollider2D tarrCollider1;
    public BoxCollider2D tarrCollider2;
    private GameObject Beatrix;
    private float speed = 2;
    private float distance;
    private BeatrixController BeatrixController;
    private Vector3 respawnPoint;

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
        if (tarrhealth <= 0)
        {
            tarrhealth = 0;
            tarrSpriteRenderer.enabled = false;
            tarrCollider1.enabled = false;
            tarrCollider2.enabled = false;
        }
        distance = Vector2.Distance(transform.position, Beatrix.transform.position);
        Vector2 direction = Beatrix.transform.position - transform.position;
        if (distance <= 15)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Beatrix.transform.position, speed * Time.deltaTime);
        }
        if (BeatrixController.BeatrixHealth <= 0)
        {
            tarrhealth = 20;
            tarrSpriteRenderer.enabled = true;
            tarrCollider1.enabled = true;
            tarrCollider2.enabled = true;
            gameObject.transform.position = respawnPoint;
            tarrSpriteRenderer.color = Color.white;
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
    }
    IEnumerator UnRed()
    {
        yield return new WaitForSeconds(.2f);
        tarrSpriteRenderer.color = Color.white;
    }
}
