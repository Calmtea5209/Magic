using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttackDark")//打中玩家
        {
            TakeDamage(100);
        }

        if (other.gameObject.tag == "PlayerAttackWater")//打中玩家
        {
            TakeDamage(10);
        }

        if (other.gameObject.tag == "PlayerAttackLight")//打中玩家
        {
            TakeDamage(15);
        }

        if (other.gameObject.tag == "PlayerAttackFlora")//打中玩家
        {
            TakeDamage(25);
        }


    }
}
