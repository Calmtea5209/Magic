using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthDirt : MonoBehaviour
{
    public GameObject DeadSmoke;
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
            Instantiate(DeadSmoke, transform.position, transform.rotation);
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
            TakeDamage(15);
        }

        if (other.gameObject.tag == "PlayerAttackWater")//�������a
        {
            TakeDamage(10);
        }

        if (other.gameObject.tag == "PlayerAttackLight")//�������a
        {
            TakeDamage(15);
        }

        if (other.gameObject.tag == "PlayerAttackFlora")//�������a
        {
            TakeDamage(25);
        }

        if (other.gameObject.tag == "PlayerAttackFire")//�������a
        {
            TakeDamage(15);
        }

        if (other.gameObject.tag == "PlayerAttackDirt")//�������a
        {
            TakeDamage(15);
        }


    }
}
