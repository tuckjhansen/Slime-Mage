using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    Animator myAnimator;
    const string OpenDoorAnimation = "OpenDoor";
    private bool DoorOpen = false;
    private bool okToMoveOn = true;
    public BoxCollider2D BoxColliderOff2D;
    public Rigidbody2D OpenDoorComponent;
    public bool enteredDoor = false;
    

    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D plyr)
    {
        if (plyr.tag == "player")
        {
            enteredDoor = true;
        }
    }
    void OnTriggerExit2D(Collider2D plyr)
    {
        if (plyr.tag == "player")
        {
            enteredDoor = false;
        }
    }

    public void Update()
    {
        if (enteredDoor && Input.GetButton("Activate"))
        {
            ActivateDoor();
        }
    }

    public void ActivateDoor()
    {
            myAnimator.SetTrigger(OpenDoorAnimation);
            BoxColliderOff2D.enabled = false;
            if (DoorOpen && Input.GetButton("Activate") && okToMoveOn)
            {
                OpenDoorComponent.gravityScale = -1;
                DoorOpen = false;
                okToMoveOn = false;
                StartCoroutine("DoCheck");
            }

            else if (!DoorOpen && Input.GetButton("Activate") && okToMoveOn)
            {
                OpenDoorComponent.gravityScale = 1;
                DoorOpen = true;
                okToMoveOn = false;
                StartCoroutine("DoCheck");
            }
    }
    private void Test()
    {
        okToMoveOn = true;
    }
    IEnumerator DoCheck()
    {
        while (!okToMoveOn)
        {
            
            yield return new WaitForSeconds(1f);
            Test();
        }
    }
}
