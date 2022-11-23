using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarrSpear : MonoBehaviour
{

    [Header("AttackUpAndDown")]
    public float attackMoveSpeed;
    public Vector2 attackMoveDirection;
    [Header("Other")]
    public Transform CeilingCheck;
    public Transform GroundCheck;
    public Transform WallCheck;
    public float GroundCheckRadius;
    public LayerMask GroundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private Rigidbody2D rb;
    private bool goingUp = true;
    private bool facingLeft = true;
    private float Health = 10;
    private QuantumBossController quantumBossController;

    void Start()
    {
        attackMoveDirection.Normalize();
        rb = GetComponent<Rigidbody2D>();
        quantumBossController = FindObjectOfType<QuantumBossController>();
        StartCoroutine("lifeTimer");
    }
    void Update()
    {
        isTouchingUp = Physics2D.OverlapCircle(CeilingCheck.position, GroundCheckRadius, GroundLayer);
        isTouchingDown = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, GroundLayer);
        isTouchingWall = Physics2D.OverlapCircle(WallCheck.position, GroundCheckRadius, GroundLayer);
        AttackUpDown();
        if (Health <= 0)
        {
            Health = 0;
            quantumBossController.QuantumSpikeBallNumLimit -= 1;
            Destroy(gameObject);
        }
    }
    void AttackUpDown()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }
        rb.velocity = attackMoveSpeed * attackMoveDirection;
    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        attackMoveDirection.y *= -1;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(CeilingCheck.position, GroundCheckRadius);
        Gizmos.DrawWireSphere(GroundCheck.position, GroundCheckRadius);
        Gizmos.DrawWireSphere(WallCheck.position, GroundCheckRadius);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime")
        {
            Health -= 5;
        }
    }
    IEnumerator lifeTimer()
    {
        yield return new WaitForSeconds(5f);
        Health = 0;
    }
}
