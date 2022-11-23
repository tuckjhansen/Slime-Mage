using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorndaoScript : MonoBehaviour
{
    public GameObject beatrix;
    public bool touchingTornado;
    public bool horizontalPush = false;

    void Update()
    {
        if (touchingTornado && !horizontalPush)
        {
            beatrix.transform.position = new Vector2(beatrix.transform.position.x, beatrix.transform.position.y + .17f);
        }
        if (touchingTornado && horizontalPush)
        {
            beatrix.transform.position = new Vector2(beatrix.transform.position.x + .17f, beatrix.transform.position.y);
        }
        if (gameObject.tag == "HorizontalTornado")
        {
            horizontalPush = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            touchingTornado = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            touchingTornado = false;
        }
    }
}
