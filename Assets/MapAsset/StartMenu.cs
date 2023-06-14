using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Start() {
        GameObject.Find("ControlCanvas").GetComponent<ControlCanvas>().Pause();
    }
    public void StartGame()
    {
        GameObject.Find("ControlCanvas").GetComponent<ControlCanvas>().Resume();
        DontDestroyOnLoad(GameObject.Find("PlayerSetting"));
        
        SceneManager.LoadScene(1);
    }
    public void CloseGame()
    {
        Application.Quit();
    }
}
