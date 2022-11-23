using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyController : MonoBehaviour
{
    private bool QuantumKeyHeld = false;
    public Animator QuantumGateAnimator;
    public BoxCollider2D QuantumGateCollider;
    public SpriteRenderer QuantumGateRenderer;
    private bool touchingQuantumGate = false;
    public bool Opened = false;
    private bool OpenedBefore = false;
    public Image quantumKeyImage;

    void Update()
    {
        if (touchingQuantumGate)
        {
            if (Input.GetButton("Activate"))
            {
                QuantumGateAnimator.SetTrigger("UseQuantumSlimeKey");
                QuantumKeyHeld = false;
                quantumKeyImage.enabled = false;
                Opened = true;
                StartCoroutine("TurnOffSlimeGateRenderer");
            }
        }
        if (Opened && !OpenedBefore)
        {
            QuantumGateAnimator.SetTrigger("UseQuantumSlimeKey");
            QuantumKeyHeld = false;
            quantumKeyImage.enabled = false;
            OpenedBefore = true;
            StartCoroutine("TurnOffSlimeGateRenderer");
        }
    }

    void OnTriggerEnter2D(Collider2D KeyCollider)
    {
        if (KeyCollider.tag == "Key")
        {
            if (KeyCollider.gameObject.name == "QuantumSlimeKey")
            {
                KeyCollider.gameObject.SetActive(false);
                QuantumKeyHeld = true;
                quantumKeyImage.enabled = true;

            }
        }
        if (KeyCollider.tag == "SlimeGate")
        {
            if (KeyCollider.gameObject.name == "QuantumSlimeGate")
            {
                if (QuantumKeyHeld)
                {
                    touchingQuantumGate = true;
                }
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D KeyCollider)
    {
        if (KeyCollider.tag == "SlimeGate")
        {
            if (KeyCollider.gameObject.name == "QuantumSlimeGate")
            {
                if (QuantumKeyHeld)
                {
                    touchingQuantumGate = false;
                }
            }

        }
    }

    IEnumerator TurnOffSlimeGateRenderer()
    {
        yield return new WaitForSeconds(1.583f);
        TurningOffSlimeGateRenderer();
    }

    void TurningOffSlimeGateRenderer()
    {
        QuantumGateRenderer.enabled = false;
        QuantumGateCollider.enabled = false;
    }


}
