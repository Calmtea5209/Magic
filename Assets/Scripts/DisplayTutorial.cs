using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayTutorial : MonoBehaviour
{


    public bool isAlreadyDisplay = false;

    public GameObject ControlImage;
    public GameObject MagicImage;

    void Update()
    {
        if (Vector3.Distance(PlayerMovement.PlayerPosision, new Vector3(1.65f, 1.1f, 18f)) <= 3f && !isAlreadyDisplay)
        {
            FindObjectOfType<ControlCanvas>().Pause();
            isAlreadyDisplay = true;
            ControlCanvas.SettingMenuStatus = true;
            OnShowControlButtonClicked(true);
        }
    }

    public void OnShowControlButtonClicked(bool show)
    {
        ControlImage.SetActive(show);
        if(show == false)
        {
            OnShowMagicButtonClicked(true);
        }
    }

    public void OnShowMagicButtonClicked(bool show)
    {
        MagicImage.SetActive(show);
        if(show == false)
        {
            FindObjectOfType<ControlCanvas>().Resume();
            ControlCanvas.SettingMenuStatus = false;
        }
    }
}
