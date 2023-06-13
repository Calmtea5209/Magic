using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{

    public GameObject CurrentPlayer;
    public GameObject PreviousPlayer;

    private int start = 1;

    void Update()
    {   if(start == 1)
        {
            PreviousPlayer = GameObject.Find("Player");
        }
        if(PreviousPlayer && start == 1)
        {
            Debug.Log("T");
            Invoke("ChangePosition",1f);
            start = 0;
        }
        else if(start == 1)
        {
            CurrentPlayer.SetActive(true);
            start = 0;
        }
    }

    void ChangePosition()
    {
        PreviousPlayer.transform.position = new Vector3(0,1.1f,0);
    }
}
