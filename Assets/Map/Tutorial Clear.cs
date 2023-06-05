using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialClear : MonoBehaviour
{
    public bool[] isClear = new bool[7];
    public bool[] isLocked = new bool[7];

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
            GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle + Random.Range(-75f, -50f), 0f);
            GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle + Random.Range(50f, 75f), 0f);
        }
        else
        {
            GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle, 0f);
            GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
    
    void Start()
    {
        Door("1in", 0f, true);
    }

    
    void Update()
    {
        float x = PlayerMovemen.PlayerPosision.x;
        float z = PlayerMovemen.PlayerPosision.z;

        // Room[1] lock
        if (!isClear[1] && !isLocked[1] && z > 20f)
        {
            Door("1in", 0f, false);
            isLocked[1] = true;
            Debug.Log("Room [1] is loked");
        }

        // Room[1] clear condition
        if (!isClear[1] && isLocked[1] && z > 25f)
        {
            isClear[1] = true;
            Debug.Log("Room [1] is clear");
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

        // Room[2] clear condition
        if (!isClear[2] && isLocked[2] && z > 46f)
        {
            isClear[2] = true;
            Debug.Log("Room [2] is clear");
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

        // Room[3] clear condition
        if (!isClear[3] && isLocked[3] && x > 40f)
        {
            isClear[3] = true;
            Debug.Log("Room [3] is clear");
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

        // Room[4] clear condition
        if (!isClear[4] && isLocked[4] && z < 26f)
        {
            isClear[4] = true;
            Debug.Log("Room [4] is clear");
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

        // Room[5] clear condition
        if (!isClear[5] && isLocked[5] && x < 20f)
        {
            isClear[5] = true;
            Debug.Log("Room [5] is clear");
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

        // Room[6] clear condition
        if (!isClear[6] && isLocked[6] && z > 26f)
        {
            isClear[6] = true;
            Debug.Log("Room [6] is clear");
        }

        // Room[6] unlock
        if (isClear[6] && isLocked[6])
        {
            Door("6in", 0f, true);
            GameObject.Find("end").transform.rotation = Quaternion.Euler(0f, -80f, 0f);
            isLocked[6] = false;
        }
    }
}
