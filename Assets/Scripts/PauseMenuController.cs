using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool Paused = false;
    private Canvas MenuCanvas;
    private BeatrixController beatrixController;
    private AttackManager attackManager;
    public GameObject PauseMenu;
    public GameObject OptionsMenu;

    void Start()
    {
        MenuCanvas = FindObjectOfType<Canvas>();
        beatrixController = FindObjectOfType<BeatrixController>();
        attackManager = FindObjectOfType<AttackManager>();
    }
    
    void Update()
    {
        if (!Paused)
        {
            MenuCanvas.enabled = false;
            Time.timeScale = 1f;
            attackManager.enabled = true;
            beatrixController.enabled = true;
        }
        if (Paused)
        {
            MenuCanvas.enabled = true;
            Time.timeScale = 0f;
            beatrixController.enabled = false;
            attackManager.enabled = false;
        }
        if (Input.GetButton("Cancel"))
        {
            Paused = true;
        }
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Resume()
    {
        Paused = false;
    }
    public void Options()
    {
        PauseMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
