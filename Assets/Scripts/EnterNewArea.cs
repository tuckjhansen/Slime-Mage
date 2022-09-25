using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterNewArea : MonoBehaviour
{
    public Image AreaSymbol;
    public Sprite UnstableReactorSymbol;
    public Text AreaText;

    void Start()
    {
        StartCoroutine("DoCheck");
    }
    IEnumerator DoCheck()
    {
        if (AreaText.enabled == true || AreaSymbol.enabled == true)
        {
            yield return new WaitForSeconds(2f);
            AreaSymbol.enabled = false;
            AreaText.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            AreaText.enabled = true;
            AreaSymbol.enabled = true;
            AreaText.text = "Unstable Reactor";
            AreaSymbol.sprite = UnstableReactorSymbol;
            StartCoroutine("DoCheck");
        }
    }
}
