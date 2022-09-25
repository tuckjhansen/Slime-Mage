using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reactorScript : MonoBehaviour
{
    Animator myAnimator;
    Animator portalAnimator;
    Animator portal2Animator;
    public bool Activated = false;
    public bool enteredReactor = false;
    public GameObject Portal;
    public GameObject Portal2;
    private portal1Script PortalRuinsScript;
    private portal1Script PortalDesertScript;
    
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        portalAnimator = Portal.GetComponent<Animator>();
        portal2Animator = Portal2.GetComponent<Animator>();
        PortalRuinsScript = Portal.GetComponent<portal1Script>();
        PortalDesertScript = Portal2.GetComponent<portal1Script>();
    }

    void Update()
    {
        if (enteredReactor && Input.GetButton("Activate") && !Activated)
        {
            myAnimator.SetTrigger("ReactorActivated");
            portalAnimator.SetTrigger("PortalActivated");
            portal2Animator.SetTrigger("PortalActivated");
            Activated = true;
            PortalRuinsScript.activated = true;
            PortalDesertScript.activated = true;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            enteredReactor = true;
        }

    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            enteredReactor = false;
        }

    }
}
