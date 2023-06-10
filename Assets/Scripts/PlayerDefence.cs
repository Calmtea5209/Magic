using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDefence : MonoBehaviour
{
    public int Decrease = 10;

    private string[] Defence = {"PlayerDefenceLight","PlayerDefenceDark","PlayerDefenceDirt","PlayerDefenceWater","PlayerDefenceFlora"};
    public int DecreaseDamage(string EnemyAttribute)
    {
        GameObject RestraintDefence = null;
        GameObject NormalDefence = null;

        if(EnemyAttribute == "Dark")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceLight");
        }
        else if(EnemyAttribute == "Light")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceDark");
        }
        else if(EnemyAttribute == "Water")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceDirt");
        }
        else if(EnemyAttribute == "Fire")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceWater");
        }
        else if(EnemyAttribute == "Dirt")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceFlora");
        }
        else if(EnemyAttribute == "Flora")
        {
            RestraintDefence = GameObject.FindGameObjectWithTag("PlayerDefenceFire");
        }

        if(RestraintDefence != null)
        {
            return Decrease;
        }
        foreach (var DefenceTag in Defence)
        {
            NormalDefence = GameObject.FindGameObjectWithTag(DefenceTag);
            if (NormalDefence != null)
            {
                return Decrease / 5;
            }
        }

        return 0;
    }
}
