using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Rigidbody2D FloorCollider;
    public Rigidbody2D RoofCollider;
    public Rigidbody2D WindowCollider;
    public Rigidbody2D InvisBarrierCollider;
    private bool goingDown = true;
    private bool okToMoveOn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (goingDown && okToMoveOn)
            {
                FloorCollider.gravityScale = -2;
                RoofCollider.gravityScale = -2;
                WindowCollider.gravityScale = -2;
                InvisBarrierCollider.gravityScale = -2;
                okToMoveOn = false;
                goingDown = false;
                StartCoroutine("DoCheck2");
            }
            if (!goingDown && okToMoveOn)
            {
                FloorCollider.gravityScale = 1;
                RoofCollider.gravityScale = 1;
                WindowCollider.gravityScale = 1;
                InvisBarrierCollider.gravityScale = 1;
                okToMoveOn = false;
                goingDown = true;
                StartCoroutine("DoCheck2");
            }
        }
    }
    private void Test()
    {
        okToMoveOn = true;
    }
    IEnumerator DoCheck2()
    {
        while (!okToMoveOn)
        {

            yield return new WaitForSeconds(1f);
            Test();
        }
    }
}

