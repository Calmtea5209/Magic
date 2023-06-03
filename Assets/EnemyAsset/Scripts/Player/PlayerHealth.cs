using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
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
        /*if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }*/
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyAttackProjectile")//¥´¤¤ª±®a
        {
            TakeDamage(20);
        }

         if(other.gameObject.tag == "EnemyAttackMelee")
        {
            TakeDamage(30);
        }
    }
}
