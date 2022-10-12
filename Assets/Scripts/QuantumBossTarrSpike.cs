using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumBossTarrSpike : MonoBehaviour
{
    private Rigidbody2D rb;
    private QuantumBossTarrSpike quantumBossTarrSpikeScript;
    private int speed = 6;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        quantumBossTarrSpikeScript = FindObjectOfType<QuantumBossTarrSpike>();
        rb.rotation = 90;
    }
    
    void Update()
    {
        rb.velocity = new Vector2(0f, -speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
