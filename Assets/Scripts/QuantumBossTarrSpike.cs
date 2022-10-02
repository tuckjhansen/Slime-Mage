using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumBossTarrSpike : MonoBehaviour
{
    private Rigidbody2D rb;
    private QuantumBossTarrSpike quantumBossTarrSpikeScript;
    private int speed = 4;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        quantumBossTarrSpikeScript = FindObjectOfType<QuantumBossTarrSpike>();
        rb.rotation = Random.Range(0, 360);
    }
    
    void Update()
    {
        rb.velocity = speed * Time.deltaTime * transform.up;
    }
}
