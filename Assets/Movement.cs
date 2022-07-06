using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using Trace;

public class Movement : MonoBehaviour {
    public BoxCollider2D boxCollider2D;
    private bool facingRight = true;
    private float moveDirection;

    // awake is called after all objects are initialized. Called in random order.
    private void awake(){

        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        
    }

    // start is called before first frame
    void start(){

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * 10f * Time.deltaTime, 0f, 0f);
        /*moveDirection = Input.GetAxis("Horizontal");*/
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
            transform.Translate(0f, .02f, 0f);
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
        transform.Rotate(0f, 180f, 0f);
    }
}