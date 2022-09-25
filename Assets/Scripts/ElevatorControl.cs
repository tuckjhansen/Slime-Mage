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
    public ElevatorControl elevatorControl;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        elevatorFloor = GameObject.Find("Floor");
        elevatorControl = GameObject.FindObjectOfType<ElevatorControl>();
    }

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

    void Update()
    {
        if (Activated && Input.GetButton("Activate"))
        {
            ActivateElevator();
        }
    }
    void ActivateElevator()
    {
        if (Input.GetButton("Activate"))
        {
            myAnimator.SetTrigger(OpenDoorAnimation2);
            if (atBottom && okToMoveOn)
            {
                FloorCollider.gravityScale = -4;
                okToMoveOn = false;
                elevatorControl.atBottom = false;
                atBottom = false;
                StartCoroutine("DoCheck2");
            }
            if (!atBottom && okToMoveOn)
            {
                FloorCollider.gravityScale = 1;
                okToMoveOn = false;
                elevatorControl.atBottom = true;
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

