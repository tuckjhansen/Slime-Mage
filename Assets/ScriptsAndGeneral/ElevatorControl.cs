using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
    public Rigidbody2D FloorCollider;
    Animator myAnimator;
    const string OpenDoorAnimation2 = "Triggered?";
    public bool atBottom = false;
    private bool okToMoveOn = true;
    private bool Activated = false;
    public GameObject elevatorFloor;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        elevatorFloor = GameObject.Find("Floor");

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
            if (/*elevatorFloor.GetComponent("atBottom")*/ atBottom && okToMoveOn)
            {
                FloorCollider.gravityScale = -2;
                okToMoveOn = false;
                /*elevatorFloor.GetComponent("atBottom")  = false;*/
                atBottom = false;
                StartCoroutine("DoCheck2");
            }
            if (/*!elevatorFloor.GetComponent("atBottom")*/ !atBottom && okToMoveOn)
            {
                FloorCollider.gravityScale = 1;
                okToMoveOn = false;
                atBottom = true;
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

