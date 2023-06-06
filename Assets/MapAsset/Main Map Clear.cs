using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMapClear : MonoBehaviour
{
    static public bool[] isClear_m = new bool[8];
    static public bool[] isLocked_m = new bool[8];

    bool PrevIsClear(int n)
    {
        bool b = true;
        for (int i = 1; i < n; i++)
        {
            b &= isClear_m[i];
        }
        return b;
    }

    void Door(string door, int num, float angle, bool open)
    {
        if (open)
        {
            if (num == 2)
            {
                GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle + Random.Range(-75f, -50f), 0f);
                GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle + Random.Range(50f, 75f), 0f);
            }
            else if (num == 0)
                GameObject.Find(door).transform.rotation = Quaternion.Euler(0f, angle + Random.Range(-100f, -80f), 0f);

            else if (num == 1)
                GameObject.Find(door).transform.rotation = Quaternion.Euler(0f, angle + Random.Range(80f, 100f), 0f);
        }
        else
        {
            if (num == 2)
            {
                GameObject.Find(door + "L").transform.rotation = Quaternion.Euler(0f, angle, 0f);
                GameObject.Find(door + "R").transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            else
                GameObject.Find(door).transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
    }
    
    void Start()
    {
        Door("1in", 2, 0f, true);
    }
    
    void Update()
    {
        float x = PlayerMovement.PlayerPosision.x;
        float z = PlayerMovement.PlayerPosision.z;

        // Level[1] lock
        if (!isClear_m[1] && !isLocked_m[1] && z > 16f)
        {
            Door("1in", 2, 0f, false);
            isLocked_m[1] = true;
            Debug.Log("Level [1] is loked");
        }

        // Level[1] clear condition
        if (!isClear_m[1] && isLocked_m[1] && z > 21f)
        {
            isClear_m[1] = true;
            Debug.Log("Level [1] is clear");
        }

        // Level[1] unlock
        if (isClear_m[1] && isLocked_m[1])
        {
            Door("1in", 2, 0f, true);
            Door("1out", 1, 90f, true);
            Door("2in", 0, 0f, true);
            isLocked_m[1] = false;
        }

        // Level[2] lock
        if (PrevIsClear(2) && !isClear_m[2] && !isLocked_m[2] && z > 30f)
        {
            Door("2in", 0, 0f, false);
            isLocked_m[2] = true;
            Debug.Log("Level [2] is loked");
        }

        // Level[2] clear condition
        if (!isClear_m[2] && isLocked_m[2] && x > 22f)
        {
            isClear_m[2] = true;
            Debug.Log("Level [2] is clear");
        }

        // Level[2] unlock
        if (isClear_m[2] && isLocked_m[2])
        {
            Door("2in", 0, 0f, true);
            Door("2out", 0, 0f, true);
            isLocked_m[2] = false;
        }

        // Level[3] lock
        if (PrevIsClear(3) && !isClear_m[3] && !isLocked_m[3] && z > 38f)
        {
            Door("2out", 0, 0f, false);
            isLocked_m[3] = true;
            Debug.Log("Level [3] is loked");
        }

        // Level[3] clear condition
        if (!isClear_m[3] && isLocked_m[3] && z > 45f)
        {
            isClear_m[3] = true;
            Debug.Log("Level [3] is clear");
        }

        // Level[3] unlock
        if (isClear_m[3] && isLocked_m[3])
        {
            Door("2out", 0, 0f, true);
            Door("3out", 1, 0f, true);
            Door("4in", 0, 0f, true);
            isLocked_m[3] = false;
        }

        // Level[4] lock
        if (PrevIsClear(4) && !isClear_m[4] && !isLocked_m[4] && z < 36f)
        {
            Door("4in", 0, 0f, false);
            isLocked_m[4] = true;
            Debug.Log("Level [4] is loked");
        }

        // Level[4] clear condition
        if (!isClear_m[4] && isLocked_m[4] && z < 20f)
        {
            isClear_m[4] = true;
            Debug.Log("Level [4] is clear");
        }

        // Level[4] unlock
        if (isClear_m[4] && isLocked_m[4])
        {
            Door("4in", 0, 0f, true);
            Door("4out", 2, 0f, true);
            Door("5in", 1, 180f, true);
            isLocked_m[4] = false;
        }

        // Level[5] lock
        if (PrevIsClear(5) && !isClear_m[5] && !isLocked_m[5] && x > -18 && z > 8f)
        {
            Door("5in", 1, 180f, false);
            isLocked_m[5] = true;
            Debug.Log("Level [5] is loked");
        }

        // Level[5] clear condition
        if (!isClear_m[5] && isLocked_m[5] && LeverControl.pulled[0] && true)
        {
            isClear_m[5] = true;
            Debug.Log("Level [5] is clear");
        }

        // Level[5] unlock
        if (isClear_m[5] && isLocked_m[5])
        {
            Door("5in", 1, 180f, true);
            Door("6in", 1, 90f, true);
            isLocked_m[5] = false;
        }

        // Level[6] lock
        if (PrevIsClear(6) && !isClear_m[6] && !isLocked_m[6] && x > 13)
        {
            Door("6in", 1, 90f, false);
            isLocked_m[6] = true;
            Debug.Log("Level [6] is loked");
        }

        // Level[6] clear condition
        if (!isClear_m[6] && isLocked_m[6] && LeverControl.pulled[1] && true)
        {
            isClear_m[6] = true;
            Debug.Log("Level [6] is clear");
        }

        // Level[6] unlock
        if (isClear_m[6] && isLocked_m[6])
        {
            Door("6in", 1, 90f, true);
            Door("6out", 1, 90f, true);
            Door("7in", 0, 0f, true);
            isLocked_m[6] = false;
        }

        // Level[7] lock
        if (PrevIsClear(7) && !isClear_m[7] && !isLocked_m[7] && z > 24)
        {
            Door("7in", 0, 0f, false);
            isLocked_m[7] = true;
            Debug.Log("Level [7] is loked");
        }

        // Level[7] clear condition
        if (!isClear_m[7] && isLocked_m[7] && LeverControl.pulled[2] && true)
        {
            isClear_m[7] = true;
            Debug.Log("Level [7] is clear");
        }

        // Level[7] unlock
        if (isClear_m[7] && isLocked_m[7])
        {
            Door("7in", 0, 0f, true);
            isLocked_m[7] = false;
        }
    }
}