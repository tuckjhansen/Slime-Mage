using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTarr : MonoBehaviour
{
    public float babyTarrMoveSpeed;
    public Rigidbody2D babyTarrRB;
    public GameObject groundCheck;
    private SpriteRenderer tarrSpriteRenderer;
    public EdgeCollider2D tarrCollider1;
    public LayerMask groundLayer;
    public bool facingRight;
    public bool isGrounded;
    public float circleRadiusGroundCheck;
    public bool Loaded = false;
    private int babyTarrHealth = 10;
    private BeatrixController BeatrixController;
    private Vector3 respawnPoint;
    private bool deadBefore = false;
    void Start()
    {
        tarrCollider1 = GetComponent<EdgeCollider2D>();
        tarrSpriteRenderer = GetComponent<SpriteRenderer>();
        BeatrixController = FindObjectOfType<BeatrixController>();
        respawnPoint = new Vector3(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (BeatrixController.BeatrixHealth <= 0)
        {
            babyTarrHealth = 10;
            tarrSpriteRenderer.enabled = true;
            tarrCollider1.enabled = true;
            transform.position = respawnPoint;
            tarrSpriteRenderer.color = Color.white;
            deadBefore = false;
        }
        StartCoroutine("LoadWait");
        if (Loaded)
        {
            babyTarrRB.velocity = Vector2.right * babyTarrMoveSpeed * Time.deltaTime;
            isGrounded = Physics2D.OverlapCircle(groundCheck.transform.position, circleRadiusGroundCheck, groundLayer);
            if (!isGrounded && facingRight)
            {
                Flip();
            }
            else if (!isGrounded && !facingRight)
            {
                Flip();
            }
        }
        if (babyTarrHealth <= 0)
        {
            babyTarrHealth = 0;
            tarrSpriteRenderer.enabled = false;
            tarrCollider1.enabled = false;
        }
        if (babyTarrHealth == 0 && !deadBefore)
        {
            deadBefore = true;
            BeatrixController.money += Random.Range(2, 3);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        babyTarrMoveSpeed = -babyTarrMoveSpeed;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.transform.position, circleRadiusGroundCheck);
    }
    IEnumerator LoadWait()
    {
        yield return new WaitForSeconds(1.6f);
        SettingLoadedToTrue();
    }
    void SettingLoadedToTrue()
    {
        Loaded = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime")
        {
            babyTarrHealth -= 5;
            tarrSpriteRenderer.color = Color.red;
            StartCoroutine("UnRed");
        }
    }
    IEnumerator UnRed()
    {
        yield return new WaitForSeconds(.2f);
        tarrSpriteRenderer.color = Color.white;
    }
}
