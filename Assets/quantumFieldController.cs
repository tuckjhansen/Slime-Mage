using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quantumFieldController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("lifeTime");
    }
    void Update()
    {
        gameObject.transform.localScale = new Vector3(transform.localScale.x + .3f, transform.localScale.y + .3f, 0); // .3 is standard
    }
    IEnumerator lifeTime()
    {
        yield return new WaitForSeconds(3.5f); // 3.5 is standard
        Destroy(gameObject);
    }
}
