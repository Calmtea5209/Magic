using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{

    public GameObject MenuRoot;
    public Slider VolumnSlider;
    public Toggle DrawMouseToggle;
    public Toggle DrawHandToggle;
    public ControlCanvas controlCanvas;
    public GameObject ControlImage;
    public GameObject MagicImage;
    void Start()
    {
        DrawMouseToggle.isOn = LineGenerator.choose == 0;
        DrawHandToggle.isOn = LineGenerator.choose == 1;
        DrawMouseToggle.onValueChanged.AddListener(OnDrawMouseChanged);
        DrawHandToggle.onValueChanged.AddListener(OnDrawHandChanged);
    }

    void Update()
    {
        /*if (ControlCanvas.SettingMenuStatus && !MenuRoot.activeSelf && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CloseSettingMenu();
        }*/

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }*/
        
    }
    public void OpenSettingMenu()
    {
        SetSettingMenuActivation(true);
    }

    public void CloseSettingMenu()
    {
        SetSettingMenuActivation(false);
    }


    void SetSettingMenuActivation(bool active)
    {
        MenuRoot.SetActive(active);

        if (MenuRoot.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
            EventSystem.current.SetSelectedGameObject(null);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            ControlCanvas.SettingMenuStatus = false;
            controlCanvas.Resume();
            Time.timeScale = 1f;
        }

    }

    void OnDrawMouseChanged(bool newValue)
    {
        if(newValue == true)
        {
            DrawHandToggle.isOn = false;
            LineGenerator.choose = 0;
        }
        else if(newValue == false && DrawHandToggle.isOn == false)
        {
            DrawMouseToggle.isOn = true;
            DrawHandToggle.isOn = false;
            LineGenerator.choose = 0;
        }
        Debug.Log("Choose"+LineGenerator.choose);
    }

    void OnDrawHandChanged(bool newValue)
    {
        if(newValue == true)
        {
            DrawMouseToggle.isOn = false;
            LineGenerator.choose = 1;
        }
        else if(newValue == false && DrawMouseToggle.isOn == false)
        {
            DrawHandToggle.isOn = true;
            DrawMouseToggle.isOn = false;
            LineGenerator.choose = 1;
        }
        Debug.Log("Choose"+LineGenerator.choose);
    }
    public void OnShowControlButtonClicked(bool show)
    {
        ControlImage.SetActive(show);
    }

    public void OnShowMagicButtonClicked(bool show)
    {
        MagicImage.SetActive(show);
    }

}
