using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarrBubble : MonoBehaviour
{
    private BoxCollider2D BoxCollider2D;
    private QuantumBossController quantumBossController;
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        BoxCollider2D.enabled = false;
        StartCoroutine("TurnColliderOn");
        quantumBossController = FindObjectOfType<QuantumBossController>();
    }
    IEnumerator TurnColliderOn()
    {
        yield return new WaitForSeconds(1f);
        BoxCollider2D.enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PinkSlime")
        {
            quantumBossController.TarrBubbleNum -= 1;
            Destroy(gameObject);
        }
    }
}
