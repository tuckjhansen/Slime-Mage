using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDetectorScript : MonoBehaviour
{
    public GameObject Boss;
    public Rigidbody2D TrapDoor1;
    public Rigidbody2D TrapDoor2;
    private QuantumBossController quantumBossController;
    public bool Activated = false;
    public GameObject QuantumBoss;

    void Start()
    {
        quantumBossController = Boss.GetComponent<QuantumBossController>();
    }

    void Update()
    {
        if (quantumBossController.Health <= 0 && Activated)
        {
            TrapDoor1.gravityScale = -1;
            TrapDoor2.gravityScale = -1;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player" && !Activated)
        {
            Boss.SetActive(true);
            TrapDoor1.gravityScale = 1;
            TrapDoor2.gravityScale = 1;
            Activated = true;
        }
    }
}
