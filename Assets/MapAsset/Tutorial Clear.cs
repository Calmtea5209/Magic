using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TutorialClear : MonoBehaviour
{
    static public bool[] isClear;
    static public bool[] isLocked;
    public float timer;

    void Start()
    {
        isClear = new bool[7];
        isLocked = new bool[7];
        timer = 0.0f;
        StartCoroutine(OpenDoorDelayed());
    }
    IEnumerator OpenDoorDelayed()
    {
        yield return new WaitForSeconds(1f);

        Door("1in", 0f, true);
    }

    bool PrevIsClear(int n)
    {
        bool b = true;
        for (int i = 1; i < n; i++)
        {
            b &= isClear[i];
        }
        return b;
    }

    void Door(string door, float angle, bool open)
    {    
        if (open)
        {
            GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle + UnityEngine.Random.Range(-75f, -50f), 0f);
            GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle + UnityEngine.Random.Range(50f, 75f), 0f);
            GameObject.Find("Player").GetComponent<Shooter>().playSoundEffect(7);
        }
        else
        {
            GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle, 0f);
            GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle, 0f);
            GameObject.Find("Player").GetComponent<Shooter>().playSoundEffect(6);
        }

    }
    
    void Update()
    {
        float x = PlayerMovement.PlayerPosision.x;
        float z = PlayerMovement.PlayerPosision.z;

        // Level[1] lock
        if (!isClear[1] && !isLocked[1] && z > 20f)
        {
            Door("1in", 0f, false);
            isLocked[1] = true;
            Debug.Log("Level [1] is loked");
        }

        // Room[1] unlock
        if (isClear[1] && isLocked[1])
        {
            Door("1in", 0f, true);
            Door("1out", 0f, true);
            Door("2in", 0f, true);
            isLocked[1] = false;
        }

        // Room[2] lock
        if (PrevIsClear(2) && !isClear[2] && !isLocked[2] && z > 40f)
        {
            Door("2in", 0f, false);
            isLocked[2] = true;
            Debug.Log("Room [2] is loked");
        }

        // Room[2] unlock
        if (isClear[2] && isLocked[2])
        {
            Door("2in", 0f, true);
            Door("2out", 90f, true);
            Door("3in", 90f, true);
            isLocked[2] = false;
        }

        // Room[3] lock
        if (PrevIsClear(3) && !isClear[3] && !isLocked[3] && x > 34f)
        {
            Door("3in", 90f, false);
            isLocked[3] = true;
            Debug.Log("Room [3] is loked");
        }

        // Room[3] unlock
        if (isClear[3] && isLocked[3])
        {
            Door("3in", 90f, true);
            Door("3out", 180f, true);
            Door("4in", 180f, true);
            isLocked[3] = false;
        }

        // Room[4] lock
        if (PrevIsClear(4) && !isClear[4] && !isLocked[4] && z < 32f)
        {
            Door("4in", 180f, false);
            isLocked[4] = true;
            Debug.Log("Room [4] is loked");
        }

        // Room[4] unlock
        if (isClear[4] && isLocked[4])
        {
            Door("4in", 180f, true);
            Door("4out", 180f, true);
            Door("5in", -90f, true);
            isLocked[4] = false;
        }

        // Room[5] lock
        if (PrevIsClear(5) && !isClear[5] && !isLocked[5] && x < 26f)
        {
            Door("5in", -90f, false);
            isLocked[5] = true;
            Debug.Log("Room [5] is loked");
        }

        // Room[5] unlock
        if (isClear[5] && isLocked[5])
        {
            Door("5in", -90f, true);
            Door("5out", 0f, true);
            Door("6in", 0f, true);
            isLocked[5] = false;
        }

        // Room[6] lock
        if (PrevIsClear(6) && !isClear[6] && !isLocked[6] && z > 20f)
        {
            Door("6in", 0f, false);
            isLocked[6] = true;
            Debug.Log("Room [6] is loked");
        }

        // Room[6] unlock
        if (isClear[6] && isLocked[6])
        {
            Door("6in", 0f, true);
            GameObject.Find("end").transform.rotation = Quaternion.Euler(0f, -80f, 0f);
            isLocked[6] = false;
        }

        if (Vector3.Distance(PlayerMovement.PlayerPosision, new Vector3(20f, 1.11f, 38f)) <= 0.5)
        {
            if (timer == 0f)
                GameObject.Find("Player").GetComponent<Shooter>().playSoundEffect(10);

            timer += Time.deltaTime;
            if (timer >= 6f)
            {
                HPbar.hp = 100;
                GameObject tmp = GameObject.FindWithTag("Player");
                tmp.SetActive(false);
                tmp.transform.position = new Vector3(0f,1.11f,0f);
                tmp.SetActive(true);
                DontDestroyOnLoad(GameObject.Find("PlayerSetting"));
                
                SceneManager.LoadScene(2);
            }
        }
    }
}
