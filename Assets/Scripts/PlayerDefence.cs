using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerDefence : MonoBehaviour
{
    public float DecreasePercentage = 0.5f;

    private string[] Defence = {"PlayerDefenceLight","PlayerDefenceDark","PlayerDefenceDirt","PlayerDefenceWater","PlayerDefenceFlora"};
    private float[] EnemyAttackDamage = {10f, 5f, 5f, 10f, 10f, 8f};
    public float DecreaseDamage(string EnemyAttribute, float damage)
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
            return damage * DecreasePercentage;
        }
        foreach (var DefenceTag in Defence)
        {
            NormalDefence = GameObject.FindGameObjectWithTag(DefenceTag);
            if (NormalDefence != null)
            {
                return damage * DecreasePercentage * 1.8f;
            }
        }

        return damage;
    }
}
