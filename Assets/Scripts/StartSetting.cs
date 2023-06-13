using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSetting : MonoBehaviour
{

    public GameObject CurrentPlayer;
    public GameObject PreviousPlayer;
    private int start = 1;

    void Update()
    {
        PreviousPlayer = GameObject.Find("Player");
        if(PreviousPlayer && start == 1)
        {
            Debug.Log("T");
            PreviousPlayer.transform.position = new Vector3(0,1.1f,0);
            start = 0;
        }
        else if(start == 1)
        {
            CurrentPlayer.SetActive(true);
            start = 0;
        }
    }
}
