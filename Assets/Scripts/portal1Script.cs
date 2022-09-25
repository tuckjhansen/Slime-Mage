using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal1Script : MonoBehaviour
{
    public bool activated = false;
    public bool enteredPortal = false;
    private bool coolDownOver = true;
    private bool teleportToDesert = true;
    public GameObject Beatrix;
    public GameObject DesertPortal1;
    public GameObject RuinsPortal;
    private Vector3 DesertCoords;
    private Vector3 RuinsCoords;
    private portal1Script DesertPortalScript;
    private portal1Script RuinsPortalScript;


    void Start()
    {
        DesertCoords = DesertPortal1.transform.position;
        RuinsCoords = RuinsPortal.transform.position;
        DesertPortalScript = DesertPortal1.GetComponent<portal1Script>();
        RuinsPortalScript = RuinsPortal.GetComponent<portal1Script>();
    }
    
    void Update()
    {
        if (enteredPortal && Input.GetButton("Activate") && activated && teleportToDesert && coolDownOver)
        {
            Beatrix.transform.position = DesertCoords;
            teleportToDesert = false;
            DesertPortalScript.teleportToDesert = false;
            coolDownOver = false;
            StartCoroutine("Wait");
        }
        if (enteredPortal && Input.GetButton("Activate") && activated && !teleportToDesert && coolDownOver)
        {
            Beatrix.transform.position = RuinsCoords;
            teleportToDesert = true;
            RuinsPortalScript.teleportToDesert = true;
            coolDownOver = false;
            StartCoroutine("Wait");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            enteredPortal = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            enteredPortal = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
        coolDownOver = true;
    }
}
