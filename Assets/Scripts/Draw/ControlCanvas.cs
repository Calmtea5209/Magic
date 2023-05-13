using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Start()
    {
        pauseMenuUI.SetActive(GameIsPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
        GameObject.Find("Player").GetComponent<Shooter>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("PlayerCamara").GetComponent<PlayerCamara>().enabled = true;
        GameObject.Find("wand").GetComponent<WeaponSway>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        GameIsPaused = true;
        GameObject.Find("Player").GetComponent<Shooter>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("PlayerCamara").GetComponent<PlayerCamara>().enabled = false;
        GameObject.Find("wand").GetComponent<WeaponSway>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = true;

    }

}
