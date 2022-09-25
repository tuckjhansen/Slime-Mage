using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingTarr : MonoBehaviour
{
    private float distance;
    private GameObject Beatrix;
    private float speed;
    public int WingTarrHealth = 15;
    private SpriteRenderer wingTarrSpriteRenderer;
    private BoxCollider2D wingTarrBoxCollider;
    private EdgeCollider2D wingTarrEdgeCollider;
    private BeatrixController beatrixController;
    private Vector3 respawnPoint;
        
    void Start()
    {
        Beatrix = GameObject.FindGameObjectWithTag("player");
        speed = Random.Range(1, 6);
        wingTarrSpriteRenderer = GetComponent<SpriteRenderer>();
        wingTarrBoxCollider = GetComponent<BoxCollider2D>();
        wingTarrEdgeCollider = GetComponent<EdgeCollider2D>();
        beatrixController = FindObjectOfType<BeatrixController>();
        respawnPoint = new Vector3(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (WingTarrHealth <= 0)
        {
            WingTarrHealth = 0;
            wingTarrSpriteRenderer.enabled = false;
            wingTarrBoxCollider.enabled = false;
            wingTarrEdgeCollider.enabled = false;
        }
        if (beatrixController.BeatrixHealth <= 0)
        {
            WingTarrHealth = 15;
            wingTarrSpriteRenderer.enabled = true;
            wingTarrBoxCollider.enabled = true;
            wingTarrEdgeCollider.enabled = true;
            transform.position = respawnPoint;
        }

        distance = Vector2.Distance(transform.position, Beatrix.transform.position);
        Vector2 direction = Beatrix.transform.position - transform.position;
        if (distance <= 20)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Beatrix.transform.position, speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime")
        {
            WingTarrHealth -= 5;
        }
        if (collision.tag == "PinkSlime")
        {
            WingTarrHealth -= 5;
            wingTarrSpriteRenderer.color = Color.red;
            StartCoroutine("UnRed");
        }
    }
    IEnumerator UnRed()
    {
        yield return new WaitForSeconds(.2f);
        wingTarrSpriteRenderer.color = Color.white;
    }
}
