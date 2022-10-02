using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class QuantumBossController : MonoBehaviour
{
    public float Health = 300;
    private SpriteRenderer BossRenderer;
    private BoxCollider2D BossCollider;
    private bool Activated = false;
    private BossDetectorScript bossDetectorScript;
    
    void Start()
    {
        BossRenderer = GetComponent<SpriteRenderer>();
        BossCollider = GetComponent<BoxCollider2D>();
        bossDetectorScript = FindObjectOfType<BossDetectorScript>();
    }
    
    void Update()
    {
        StartCoroutine("Wait");
        if (Health <= 0) 
        {
            Health = 0;
            BossRenderer.enabled = false;
            BossCollider.enabled = false;
        }
        if (Activated)
        {
            
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime") 
        {
            Health -= 5;
        }
            
    }
    IEnumerator Wait()
    {
        if (bossDetectorScript.Activated)
        {
            yield return new WaitForSeconds(5);
            Activated = true;
        }
    }
}
