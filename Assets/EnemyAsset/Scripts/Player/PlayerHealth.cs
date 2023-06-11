using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    //public int currentHealth;

    //public HealthBar healthBar;
    // Start is called before the first frame update

    private string[] EnemyAttack = {"EnemyAttackDark","EnemyAttackLight","EnemyAttackWater","EnemyAttackFire","EnemyAttackDirt","EnemyAttackFlora"};
    private float[] EnemyAttackDamage = {10f, 5f, 5f, 10f, 10f, 8f};

    private string[] Attribute = {"Dark","Light","Water","Fire","Dirt","Flora"};
    void Start()
    {
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        /*if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    void TakeDamage(float damage, string attribute)
    {
        //currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        damage = GameObject.Find("ControlDefence").GetComponent<PlayerDefence>().DecreaseDamage(attribute,damage);
        HPbar.hp -= damage;
        if(HPbar.hp < 0)
        {
            HPbar.hp = 0;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        int idx = Array.IndexOf(EnemyAttack, other.gameObject.tag);
        if (idx != -1)
        {
            TakeDamage(EnemyAttackDamage[idx] ,Attribute[idx]);
        }

        /* if(other.gameObject.tag == "EnemyAttackMelee")
        {
            TakeDamage(30);
        }*/
    }
}
