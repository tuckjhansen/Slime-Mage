using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumBossController : MonoBehaviour
{
    public float Health = 10; // 300 is max health
    private SpriteRenderer BossRenderer;
    private BoxCollider2D BossCollider;
    void Start()
    {
        BossRenderer = GetComponent<SpriteRenderer>();
        BossCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (Health <= 0) 
        {
            Health = 0;
            BossRenderer.enabled = false;
            BossCollider.enabled = false;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime") 
        {
            Health -= 5;
            Debug.Log("Quantum Boss Health: " + Health);
        }
            
    }
}
