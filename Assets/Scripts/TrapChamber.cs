using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapChamber : MonoBehaviour
{
    public Rigidbody2D TarrSpikeDoor1;
    public Rigidbody2D TarrSpikeDoor2;
    public bool trapActivated = false;
    public BoxCollider2D Round1Collider;
    public BoxCollider2D Round2Collider;
    public AudioSource ThoseRainbows;
    public AudioSource AncientRuins;
    public SpriteRenderer Enemy1;
    public SpriteRenderer Enemy2;
    public SpriteRenderer Enemy3;
    public SpriteRenderer Enemy4;
    public SpriteRenderer Enemy5;
    public SpriteRenderer Enemy6;
    public SpriteRenderer Enemy7;
    public SpriteRenderer Enemy8;
    public SpriteRenderer Enemy9;
    public SpriteRenderer Enemy10;
    public SpriteRenderer Enemy11;
    public SpriteRenderer Enemy12;
    public SpriteRenderer Enemy13;
    public SpriteRenderer Enemy14;
    public SpriteRenderer Enemy15;
    public SpriteRenderer Enemy16;
    public SpriteRenderer Enemy17;
    public SpriteRenderer Enemy18;
    public SpriteRenderer Enemy19;
    public SpriteRenderer Enemy20;
    public SpriteRenderer Enemy21;
    public SpriteRenderer Enemy22;
    private BeatrixController BeatrixController;

    void Start()
    {
        BeatrixController = FindObjectOfType<BeatrixController>();
    }

    void Update()
    {
        if (trapActivated && BeatrixController.BeatrixHealth == 0)
        {
            TarrSpikeDoor1.gravityScale = -1;
            TarrSpikeDoor2.gravityScale = -1;
            ThoseRainbows.enabled = false;
            AncientRuins.enabled = true;
            Round1Collider.enabled = true;
            Round2Collider.enabled = true;
            trapActivated = false;
        }
        if (trapActivated)
        {
            TarrSpikeDoor1.gravityScale = 1;
            TarrSpikeDoor2.gravityScale = 1;
            Round1Collider.enabled = false;
            StartCoroutine("Round2EnemysTimer");
            ThoseRainbows.enabled = true;
            AncientRuins.enabled = false;
        }
        // if all enemies are dead, then the trap is deactivated
        // if all enemies are dead, then the door gravity reverses
        // if all enemies are dead, then round1collider is enabled
        // if all enemies are dead, then round2collider is enabled
        // if all enemies are dead, then the rainbows audio is disabled
        // if all enemies are dead, then the ancient ruins audio is enabled
        if (Enemy1.enabled == false && Enemy2.enabled == false && Enemy3.enabled == false && Enemy4.enabled == false && Enemy5.enabled == false && Enemy6.enabled == false && Enemy7.enabled == false && Enemy8.enabled == false && Enemy9.enabled == false && Enemy10.enabled == false && Enemy11.enabled == false && Enemy12.enabled == false && Enemy13.enabled == false && Enemy14.enabled == false && Enemy15.enabled == false && Enemy16.enabled == false && Enemy17.enabled == false && Enemy18.enabled == false && Enemy19.enabled == false && Enemy20.enabled == false && Enemy21.enabled == false && Enemy22.enabled == false)
        {
            TarrSpikeDoor1.gravityScale = -1;
            TarrSpikeDoor2.gravityScale = -1;
            Round1Collider.enabled = true;
            Round2Collider.enabled = true;
            ThoseRainbows.enabled = false;
            AncientRuins.enabled = true;
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
        Round2();
    }
    void Round2()
    {
        Round2Collider.enabled = false;
    }
}
