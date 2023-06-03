using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 1000;
    public int currentHealth;
    private bool thereAreCrystals = false;

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
        if(GameObject.FindWithTag("BossCrystal") != null)
        {
            thereAreCrystals = true;
        }
        else
        {
            thereAreCrystals= false;
        }

        if (currentHealth <= 0)
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
        if (thereAreCrystals == false)
        {
            if (other.gameObject.tag == "PlayerAttackDark")//打中玩家
            {
                TakeDamage(20);
            }

            if (other.gameObject.tag == "PlayerAttackWater")//打中玩家
            {
                TakeDamage(40);
            }

            if (other.gameObject.tag == "PlayerAttackLight")//打中玩家
            {
                TakeDamage(20);
            }

            if (other.gameObject.tag == "PlayerAttackFlora")//打中玩家
            {
                TakeDamage(5);
            }

            if (other.gameObject.tag == "PlayerAttackFire")//打中玩家
            {
                TakeDamage(1);
            }

            if (other.gameObject.tag == "PlayerAttackDirt")//打中玩家
            {
                TakeDamage(25);
            }
        }
    }

}
