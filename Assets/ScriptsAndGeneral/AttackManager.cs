using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SlimeSlots
{
    public string name { get; set; }
    public string[] powers { get; set; }
}

public class AttackManager : MonoBehaviour
{
    public Image SlimeSlot1;
    public bool SlimeSlot1Activated = true;


    public Image SlimeSlot2;
    public bool SlimeSlot2Activated = false;

    public Image SlimeSlot3;
    public bool SlimeSlot3Activated = false;

    public Image SlimeSlot4;
    public bool SlimeSlot4Activated = false;

    


// 0 = empty, 1 = pinkslime, 2 = tabbyslime, 3 = rockslime, 4 = phosphorslime, 5 = puddleslime, 6 = boomslime, 7 = honeyslime, 8 = hunterslime
// 9 = luckyslime, 10 = goldslime, 11 = radslime, 12 = crystalslime, 13 = quantumslime, 14 = dervishslime, 15 = mosaicslime, 16 = tangleslime, 17 = fireslime
// 18 = tactuslime, 19 = amberslime, 20 = iceslime, 21 = snowslime, 22 = saberslime, 23 = quicksilverslime, 24 = glitchslime, 25 = starslime, 26 = cloudslime
// 27 = lightningslime, 28 = voidslime, 29 = rainbowtarrslime, 30 = oceanslime
void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
