using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyTarr : MonoBehaviour
{
    public float babyTarrMoveSpeed;
    public Rigidbody2D babyTarrRB;
    public GameObject groundCheck;
    public LayerMask groundLayer;
    public bool facingRight;
    public bool isGrounded;
    public float circleRadiusGroundCheck;
    /*public GameObject babyTarr;*/



    // Start is called before the first frame update
    void Start()
    {
        /*babyTarrRB = GetComponent<Rigidbody2D>();*/
    }

    // Update is called once per frame
    void Update()
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
}
