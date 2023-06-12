using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public GameObject BossDeath;
    public int maxHealth = 1000;
    public int currentHealth;
    private bool thereAreCrystals = false;

    public HealthBar healthBar;

    static public bool BossIsDead = false;
    static public Vector3 BossDeadPoint;

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
            BossDeadPoint = gameObject.transform.position;
            BossIsDead = true;

            Instantiate(BossDeath , transform.position, transform.rotation);
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
            if (other.gameObject.tag == "PlayerAttackDark")//�������a
            {
                TakeDamage(20);
            }

            if (other.gameObject.tag == "PlayerAttackWater")//�������a
            {
                TakeDamage(40);
            }

            if (other.gameObject.tag == "PlayerAttackLight")//�������a
            {
                TakeDamage(20);
            }

            if (other.gameObject.tag == "PlayerAttackFlora")//�������a
            {
                TakeDamage(5);
            }

            if (other.gameObject.tag == "PlayerAttackFire")//�������a
            {
                TakeDamage(1);
            }

            if (other.gameObject.tag == "PlayerAttackDirt")//�������a
            {
                TakeDamage(25);
            }
        }
    }

}
