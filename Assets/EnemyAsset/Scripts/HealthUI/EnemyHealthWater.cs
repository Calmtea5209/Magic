using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthWater : MonoBehaviour
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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerAttackDark")//�������a
        {
            TakeDamage(20);
        }

        if (other.gameObject.tag == "PlayerAttackWater")//�������a
        {
            TakeDamage(10);
        }

        if (other.gameObject.tag == "PlayerAttackLight")//�������a
        {
            TakeDamage(20);
        }

        if (other.gameObject.tag == "PlayerAttackFlora")//�������a
        {
            TakeDamage(30);
        }

        if (other.gameObject.tag == "PlayerAttackFire")//�������a
        {
            TakeDamage(2);
        }

        if (other.gameObject.tag == "PlayerAttackDirt")//�������a
        {
            TakeDamage(30);
        }
    }
}
