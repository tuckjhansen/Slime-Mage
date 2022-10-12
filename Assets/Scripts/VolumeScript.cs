using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;
    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat("MyExposedParam", Mathf.Log10(sliderValue) * 20);
    }
    
    public void BackButtonFuntion()
    {
        PauseMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }
        
}
