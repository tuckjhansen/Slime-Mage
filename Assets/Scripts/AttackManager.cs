using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Power
{

}

public class SlimeSlot
{
    public SlimeSlot(string name, bool isSelected, Sprite imageSprite)
    {
        this.name = name;
        this.isSelected = isSelected;
        this.imageSprite = imageSprite;
    }

    public string name;
    public Sprite imageSprite;
    public Power power;
    public bool isSelected;
}




public class AttackManager : MonoBehaviour
{
    public SlimeSlot SlimeSlot1 = new SlimeSlot(null, true, null);
    public SlimeSlot SlimeSlot2 = new SlimeSlot(null, false, null);
    public SlimeSlot SlimeSlot3 = new SlimeSlot(null, false, null);
    public SlimeSlot SlimeSlot4 = new SlimeSlot(null, false, null);

    public RectTransform SlimeSlot1RectTransform;
    public Image SlimeSlot1Image;
    public Image SlimeSlot2Image;
    public Image SlimeSlot3Image;
    public Image SlimeSlot4Image;
    public RectTransform SlimeSlot2RectTransform;
    public RectTransform SlimeSlot3RectTransform;
    public RectTransform SlimeSlot4RectTransform;
    private int SlimeSlotSelectedInt = 1;
    private Vector3 notSelectedScale = new Vector3(.7f, .7f, 1);
    private Vector3 selectedScale = new Vector3(1, 1, 1);

    public Camera mainCam;
    private Vector3 mousePos;
    public GameObject pinkSlimeProjectile;
    public Transform projectileTransform;
    private bool canFireSlime = true;

    public Sprite EmptySlotImage;
    public Sprite PinkSlimeSlotImage;
    public Sprite RockSlimeSlotImage;
    public Slider ManaSlider;
    public float Mana = 100;
    public float MaxMana = 100;
    public Text ManaText;
    private BeatrixController beatrixController;
    private bool canRegenMana = true;
    private bool attacking = false;
    public bool touchingQuantumGiver = false;
    public Sprite quantumSlotSprite;
    private bool slowTime = false;
    public Text timeSpeedText;
    public Image timeSpeedBackground;
    public GameObject quantumField;
    public bool hasQuantumSlime = false;

    // 0 = empty, 1 = pinkslime, 2 = tabbyslime, 3 = rockslime, 4 = phosphorslime, 5 = puddleslime, 6 = boomslime, 7 = honeyslime, 8 = hunterslime
    // 9 = luckyslime, 10 = goldslime, 11 = radslime, 12 = crystalslime, 13 = quantumslime, 14 = dervishslime, 15 = mosaicslime, 16 = tangleslime, 17 = fireslime
    // 18 = tactuslime, 19 = amberslime, 20 = iceslime, 21 = snowslime, 22 = saberslime, 23 = quicksilverslime, 24 = glitchslime, 25 = starslime, 26 = cloudslime
    // 27 = lightningslime, 28 = voidslime, 29 = rainbowtarrslime, 30 = oceanslime
    void Start()
    {
        SlimeSlot1 = new SlimeSlot("pinkSlime", true, PinkSlimeSlotImage);
        SlimeSlot2 = new SlimeSlot("empty", false, EmptySlotImage);
        SlimeSlot3 = new SlimeSlot("empty", false, EmptySlotImage);
        SlimeSlot4 = new SlimeSlot("empty", false, EmptySlotImage);
        beatrixController = FindObjectOfType<BeatrixController>();
    }

    void Update()
    {
        if (slowTime)
        {
            Time.timeScale = .6f;
            timeSpeedText.text = "Time Speed: " + Time.timeScale * 100 + "%";
        }
        if (!slowTime)
        {
            Time.timeScale = 1f;
            beatrixController.speed = 1;
            timeSpeedText.text = "Time Speed: " + Time.timeScale * 100 + "%";
        }
        if (touchingQuantumGiver && Input.GetButton("Activate"))
        {
            if (SlimeSlot2.name == "empty")
            {
                SlimeSlot2.name = "quantumSlime";
                SlimeSlot2.imageSprite = quantumSlotSprite;
                SlimeSlot2RectTransform.localScale = new Vector2(10f, 10f);
                timeSpeedText.enabled = true;
                timeSpeedBackground.enabled = true;
                hasQuantumSlime = true;
            }
        }
        if (SlimeSlot2.name == "empty" && hasQuantumSlime)
        {
            SlimeSlot2.name = "quantumSlime";
            SlimeSlot2.imageSprite = quantumSlotSprite;
            SlimeSlot2RectTransform.localScale = new Vector2(10f, 10f);
            timeSpeedText.enabled = true;
            timeSpeedBackground.enabled = true;
            hasQuantumSlime = true;
        }
        mousePos.x += Input.GetAxis("Mouse X");
        mousePos.y += Input.GetAxis("Mouse Y");
        if (beatrixController.BeatrixHealth >= 70 && canRegenMana)
        {
            StartCoroutine("ManaRegen");
            /*canRegenMana = false;*/
            
        }
        if (Mana >= MaxMana)
        {
            Mana = MaxMana;
        }
        ManaSlider.value = Mana / 100;
        ManaText.text = Mana.ToString();
        SlimeSlot1Image.sprite = SlimeSlot1.imageSprite;
        SlimeSlot2Image.sprite = SlimeSlot2.imageSprite;
        SlimeSlot3Image.sprite = SlimeSlot3.imageSprite;
        SlimeSlot4Image.sprite = SlimeSlot4.imageSprite;
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
        if (Input.GetButton("Attack"))
        {
            if (canFireSlime && Mana >= 1)
            {
                if (SlimeSlot1.isSelected)
                {
                    if (SlimeSlot1.name == "pinkSlime")
                    {
                        canFireSlime = false;
                        Instantiate(pinkSlimeProjectile, projectileTransform.position, Quaternion.identity);
                        Mana -= 1;
                        canRegenMana = false;
                        attacking = true;
                        StartCoroutine("ShootWait");
                    }
                }
                if (SlimeSlot2.isSelected)
                {
                    if (SlimeSlot2.name == "quantumSlime" && Mana >= 30)
                    {
                        canFireSlime = false;
                        Mana -= 30;
                        slowTime = true;
                        beatrixController.speed = 2;
                        canRegenMana = false;
                        attacking = true;
                        StartCoroutine("ShootWait");
                        StartCoroutine("quantumTimer");
                        Instantiate(quantumField, transform.position, transform.rotation);
                    }
                }
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            SlimeSlotSelectedInt++;
        } // scrollers \/
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            SlimeSlotSelectedInt--;
        }
        if (Input.GetButtonDown("BumperRight"))
        {
            SlimeSlotSelectedInt++;
        }
        if (Input.GetButtonDown("BumperLeft"))
        {
            SlimeSlotSelectedInt--;
        }

        if (SlimeSlotSelectedInt <= 0)
        {
            SlimeSlotSelectedInt = 4;
        }
        if (SlimeSlotSelectedInt >= 5)
        {
            SlimeSlotSelectedInt = 1;
        }
        if (SlimeSlotSelectedInt == 1)
        {
            SlimeSlot1RectTransform.localScale = selectedScale;
            SlimeSlot2RectTransform.localScale = notSelectedScale;
            SlimeSlot3RectTransform.localScale = notSelectedScale;
            SlimeSlot4RectTransform.localScale = notSelectedScale;
            SlimeSlot1.isSelected = true;
            SlimeSlot2.isSelected = false;
            SlimeSlot3.isSelected = false;
            SlimeSlot4.isSelected = false;
        } // scrollers \//\
        if (SlimeSlotSelectedInt == 2)
        {
            SlimeSlot1RectTransform.localScale = notSelectedScale;
            SlimeSlot2RectTransform.localScale = selectedScale;
            SlimeSlot3RectTransform.localScale = notSelectedScale;
            SlimeSlot4RectTransform.localScale = notSelectedScale;
            SlimeSlot1.isSelected = false;
            SlimeSlot2.isSelected = true;
            SlimeSlot3.isSelected = false;
            SlimeSlot4.isSelected = false;
        }
        if (SlimeSlotSelectedInt == 3)
        {
            SlimeSlot1RectTransform.localScale = notSelectedScale;
            SlimeSlot2RectTransform.localScale = notSelectedScale;
            SlimeSlot3RectTransform.localScale = selectedScale;
            SlimeSlot4RectTransform.localScale = notSelectedScale;
            SlimeSlot1.isSelected = false;
            SlimeSlot2.isSelected = false;
            SlimeSlot3.isSelected = true;
            SlimeSlot4.isSelected = false;
        }
        if (SlimeSlotSelectedInt == 4)
        {
            SlimeSlot1RectTransform.localScale = notSelectedScale;
            SlimeSlot2RectTransform.localScale = notSelectedScale;
            SlimeSlot3RectTransform.localScale = notSelectedScale;
            SlimeSlot4RectTransform.localScale = selectedScale;
            SlimeSlot1.isSelected = false;
            SlimeSlot2.isSelected = false;
            SlimeSlot3.isSelected = false;
            SlimeSlot4.isSelected = true;
        } // scrollers/\

    }
    IEnumerator ShootWait()
    {
        while (!canFireSlime)
        {
            yield return new WaitForSeconds(.6f);
            canFireSlime = true;
        }
        while (!canRegenMana && !attacking)
        {
            yield return new WaitForSeconds(5f);
            canRegenMana = true;
        }
        while (attacking)
        {
            yield return new WaitForSeconds(5f);
            attacking = false;
        }
        
    }
    IEnumerator ManaRegen()
    {
        {
            while (Mana <= MaxMana && beatrixController.BeatrixHealth >= 70 && canRegenMana)
            {
                yield return new WaitForSeconds(.5f);
                Mana += 1;
            }
        }
    }
    IEnumerator quantumTimer()
    {
        yield return new WaitForSeconds(3.5f);
        slowTime = false;
    }
}
