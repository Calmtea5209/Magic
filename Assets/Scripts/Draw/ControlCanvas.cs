using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public static bool SettingMenuStatus = false;

    public GameObject pauseMenuUI;
    public SettingMenu settingMenu;

    void Start()
    {
        pauseMenuUI.SetActive(GameIsPaused);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && !SettingMenuStatus)
        {
            if (GameIsPaused)
            {
                Resume();
                pauseMenuUI.SetActive(false);
                GameIsPaused = false;
                GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = false;
                GameObject.FindWithTag("Hand").GetComponent<Camera>().enabled = false;
            }
            else
            {
                Pause();
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseMenuUI.SetActive(true);
                GameIsPaused = true;
                GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = true;
            }
        }
        else if(Input.GetKeyDown(KeyCode.Tab) && !GameIsPaused)
        {
            if(SettingMenuStatus)
            {
                Resume();
                settingMenu.CloseSettingMenu();
                SettingMenuStatus = false;
                Debug.Log("F");
            }
            else
            {
                Pause();
                settingMenu.OpenSettingMenu();
                SettingMenuStatus = true;
                Debug.Log("T");
            }
        }
    }

    public void Resume()
    {
        /*if(GameIsPaused && !SettingMenuStatus)
        {
            pauseMenuUI.SetActive(false);
            GameIsPaused = false;
            GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = false;
            GameObject.FindWithTag("Hand").GetComponent<Camera>().enabled = false;
        }
        else if(SettingMenuStatus)
        {
            settingMenu.CloseSettingMenu();
            SettingMenuStatus = false;
        }*/
        GameObject.Find("Player").GetComponent<Shooter>().enabled = true;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
        GameObject.Find("PlayerCamara").GetComponent<MouseCamLook>().enabled = true;
        GameObject.Find("wand").GetComponent<WeaponSway>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        /*if(!GameIsPaused && !SettingMenuStatus)
        {
            pauseMenuUI.SetActive(true);
            GameIsPaused = true;
            GameObject.FindWithTag("Draw").GetComponent<Camera>().enabled = true;
        }
        else if(!SettingMenuStatus)
        {
            settingMenu.OpenSettingMenu();
            SettingMenuStatus = true;
        }*/

        GameObject.Find("Player").GetComponent<Shooter>().enabled = false;
        GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        GameObject.Find("PlayerCamara").GetComponent<MouseCamLook>().enabled = false;
        GameObject.Find("wand").GetComponent<WeaponSway>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //GameObject.FindWithTag("Hand").GetComponent<Camera>().enabled = true;

    }

}
