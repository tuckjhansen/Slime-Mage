using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChamber : MonoBehaviour
{
    public Rigidbody2D TarrSpikeDoor1;
    public Rigidbody2D TarrSpikeDoor2;
    public bool trapActivated = false;
    public BoxCollider2D Enemy11Collider;
    /*public BoxCollider2D Enemy12Collider;
    public BoxCollider2D Enemy13Collider;
    public BoxCollider2D Enemy14Collider;*/
    public AudioSource ThoseRainbows;
    public AudioSource AncientRuins;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (trapActivated)
        {
            TarrSpikeDoor1.gravityScale = 1;
            TarrSpikeDoor2.gravityScale = 1;
            Enemy11Collider.enabled = false;
            /*Enemy12Collider.enabled = false;
            Enemy13Collider.enabled = false;
            Enemy14Collider.enabled = false;*/
            StartCoroutine("Round2EnemysTimer");
            ThoseRainbows.enabled = true;
            AncientRuins.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D Activater)
    {
        if (Activater.tag == "player")
        {
            trapActivated = true;
        }
    }

    IEnumerator Round2EnemysTimer()
    {
        yield return new WaitForSeconds(10f);
    }
}
