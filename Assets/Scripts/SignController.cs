using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SignController : MonoBehaviour
{
    public Text LoreText;
    public Image readibilityImage;
    public Text PushButtonToRead;
    private bool EnteredMessage = false;
    private bool read = false;
    public Sprite ReadSprite;
    private SpriteRenderer SpriteRenderer;
    void Start()
    {
        PushButtonToRead.enabled = false;
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (EnteredMessage == false)
        {
            PushButtonToRead.enabled = false;
            readibilityImage.enabled = false;
            LoreText.enabled = false;
        }
        if (EnteredMessage == true && Input.GetButton("Activate"))
        {
            LoreText.enabled = true;
            readibilityImage.enabled = true;
            read = true;
        }
        if (EnteredMessage == true)
        {
            PushButtonToRead.enabled = true;
        }
        if (read == true)
        {
            SpriteRenderer.sprite = ReadSprite;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            EnteredMessage = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            EnteredMessage = false;
        }
    }
}
