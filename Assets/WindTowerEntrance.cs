using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindTowerEntrance : MonoBehaviour
{
    public GameObject Beatrix;
    public Text ActivateText;
    private WindTowerEntrance windTowerEntrance;
    private bool touchingEntrance = false;
    private bool InsideTower = false;
    private bool coolDownOver = true;

    private void Start()
    {
        ActivateText.enabled = false;
        windTowerEntrance = FindObjectOfType<WindTowerEntrance>();
    }
    private void Update()
    {
        if (Input.GetButton("Activate") && touchingEntrance && !InsideTower && coolDownOver)
        {
            Beatrix.transform.position = new Vector3(1457.42f, -177.17f, 0);
            InsideTower = true;
            windTowerEntrance.InsideTower = true;
            windTowerEntrance.coolDownOver = false;
            windTowerEntrance.StartCoroutine("Wait");
            coolDownOver = false;
            StartCoroutine("Wait");
        }
        if (Input.GetButton("Activate") && touchingEntrance && InsideTower && coolDownOver)
        {
            Beatrix.transform.position = new Vector3(1479.7f, -221.09f, 0);
            InsideTower = false;
            windTowerEntrance.InsideTower = false;
            windTowerEntrance.coolDownOver = false;
            windTowerEntrance.StartCoroutine("Wait");
            coolDownOver = false;
            StartCoroutine("Wait");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ActivateText.enabled = true;
            touchingEntrance = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ActivateText.enabled = false;
            touchingEntrance = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(.4f);
        coolDownOver = true;
    }
}

