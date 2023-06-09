using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAwake_T : MonoBehaviour
{
    public int level;
    public GameObject[] enemyList;
    bool[] visit = new bool[7];

    bool IsWin()
    {
        bool b = false;
        foreach (GameObject obj in enemyList)
            b |= obj;

        return !b;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TutorialClear.isLocked[level] && !visit[level])
        {
            foreach (GameObject obj in enemyList)
                obj.SetActive(true);

            visit[level] = true;
        }

        if (IsWin() && !TutorialClear.isClear[level])
        {
            TutorialClear.isClear[level] = true;
            Debug.Log("level [" + level + "] is clear.");
        }
    }
}
