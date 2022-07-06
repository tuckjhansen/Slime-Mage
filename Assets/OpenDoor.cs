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

    private void awake()
    {
        OpenDoorComponent = transform.GetComponent<Rigidbody2D>();
        BoxColliderOff2D = transform.GetComponent<BoxCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1")){
            myAnimator.SetTrigger(OpenDoorAnimation);
            BoxColliderOff2D.enabled = false;
            if (DoorOpen && (Input.GetButton("Fire1") && okToMoveOn))
            {
                OpenDoorComponent.gravityScale = -1;
                DoorOpen = false;
                okToMoveOn = false;
                StartCoroutine("DoCheck");
            }

            if (!DoorOpen && (Input.GetButton("Fire1") && okToMoveOn))
            {
                OpenDoorComponent.gravityScale = 1;
                DoorOpen = true;
                okToMoveOn = false;
                StartCoroutine("DoCheck");
            }
            
        }
    }
    void Test()
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
