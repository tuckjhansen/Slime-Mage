using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Rigidbody2D FloorCollider;
    Animator myAnimator;
    const string OpenDoorAnimation2 = "Triggered?";
    public Rigidbody2D RoofCollider;
    public Rigidbody2D WindowCollider;
    public Rigidbody2D InvisBarrierCollider;
    private bool goingDown = true;
    private bool okToMoveOn = true;
    private bool Activated = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Sets up Collision with player makes it activatable
    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.tag == "player")
        {
            Activated = true;

        }
    }

    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.tag == "player")
        {
            Activated = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Activated && Input.GetButton("Fire1"))
        {
            ActivateElevator();
        }
    }
    void ActivateElevator()
    {
        if (Input.GetButton("Fire1"))
        {
            myAnimator.SetTrigger(OpenDoorAnimation2);
            if (goingDown && okToMoveOn)
            {
                FloorCollider.gravityScale = -2;
                RoofCollider.gravityScale = -2;
                WindowCollider.gravityScale = -2;
                InvisBarrierCollider.gravityScale = -2;
                okToMoveOn = false;
                goingDown = false;
                StartCoroutine("DoCheck2");
            }
            if (!goingDown && okToMoveOn)
            {
                FloorCollider.gravityScale = 1;
                RoofCollider.gravityScale = 1;
                WindowCollider.gravityScale = 1;
                InvisBarrierCollider.gravityScale = 1;
                okToMoveOn = false;
                goingDown = true;
                StartCoroutine("DoCheck2");
            }
        }
    }

    void Test()
    {
        okToMoveOn = true;
    }

    IEnumerator DoCheck2()
    {
        while (!okToMoveOn)
        {

            yield return new WaitForSeconds(1f);
            Test();
        }
    }
}

