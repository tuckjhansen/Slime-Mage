using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuantumScript : MonoBehaviour
{
    private int ChanceOfAction;
    private bool notDoingSomething = true;
    private bool notMovingYet = true;
    private int ChanceOfMoveLeft;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (notDoingSomething == true)
        {
            ChanceOfAction = Random.Range(0, 101);
            notDoingSomething = false;
            StartCoroutine("HungryTimer");
        }

        if (ChanceOfAction <= 33.333)
        {
            if (notMovingYet == true)
            {
                notMovingYet = false;
                ChanceOfMoveLeft = Random.Range(0, 2);
            }
            if (ChanceOfMoveLeft == 0)
            {
                transform.Translate(-.3f *10f * Time.deltaTime, 0f, 0f);
            }
            if (ChanceOfMoveLeft == 1)
            {
                transform.Translate(.3f * 10f * Time.deltaTime, 0f, 0f);
            }
            
        }
        if (ChanceOfAction > 33.333 && ChanceOfAction <= 66.666)
        {

        }
        if (ChanceOfAction > 66.666 && ChanceOfAction <= 100)
        {

        }
    }

    IEnumerator HungryTimer()
    {
        yield return new WaitForSeconds(100f);
        HungryQuantum();
    }

    void HungryQuantum()
    {
        
    }
}
