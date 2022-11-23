using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkSlime : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public Rigidbody2D rb;
    public float Speed = 12f;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);     
        Vector3 rotation = transform.position - mousePos;
        Vector3 direction = mousePos - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Speed;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * Speed;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        StartCoroutine("WaitForDeath");
    }

    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(4f); // 4 is standard
        DestroyImmediate(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Tarr")
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "player")
        {
            Destroy(gameObject);
        }
    }
}
