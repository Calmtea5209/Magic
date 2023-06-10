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

    void TakeDamage(int damage, string attribute)
    {
        //currentHealth -= damage;
        //healthBar.SetHealth(currentHealth);
        damage -= GameObject.Find("ControlDefence").GetComponent<PlayerDefence>().DecreaseDamage(attribute);
        HPbar.hp -= damage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (Array.IndexOf(EnemyAttack, other.gameObject.tag) != -1)
        {
            TakeDamage(20,Attribute[Array.IndexOf(EnemyAttack, other.gameObject.tag)]);
        }

        /* if(other.gameObject.tag == "EnemyAttackMelee")
        {
            TakeDamage(30);
        }*/
    }
}
