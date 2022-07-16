using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// using Trace;

public class Movement : MonoBehaviour {
    public BoxCollider2D boxCollider2D;
    private bool facingRight = true;
    private float moveDirection;
    public float BeatrixHealth;
    public Text BeaHealthText;
    private bool TouchingSlimeSea = false;
    public Camera CamAlive;
    public Camera CamDead;
    public Canvas canvasToTurnOff;
    public Canvas DeadCanvas;
    public SpriteRenderer BeaSpriteRenderer;

    // awake is called after all objects are initialized. Called in random order.
    private void awake(){

        boxCollider2D = transform.GetComponent<BoxCollider2D>();
        
    }

    // start is called before first frame
    void Start(){
        BeaHealthText.text = BeatrixHealth.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        BeaHealthText.text = BeatrixHealth.ToString();
        transform.Translate(Input.GetAxis("Horizontal") * 10f * Time.deltaTime, 0f, 0f);
        moveDirection = Input.GetAxis("Horizontal");
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
            transform.Translate(0f, .025f, 0f);
        }

        if (TouchingSlimeSea == true)
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

    void OnTriggerEnter2D(Collider2D SlimeSea)
    {
        if (SlimeSea.tag == "Slime Sea")
        {
            TouchingSlimeSea = true;
        }
    }
    void OnTriggerExit2D(Collider2D SlimeSea)
    {
        if (SlimeSea.tag == "Slime Sea")
        {
            TouchingSlimeSea = false;
        }
    }
    void TouchSlimeSea()
    {
        BeatrixHealth = 0;
        BeaHealthText.text = BeatrixHealth.ToString();

    }
}

