using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIAttackShoot: MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public float AttackRange = 10;
    public GameObject Projectile;
    private float attack_Timer = 0;
    public float attack_Rate = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        attack_Timer += Time.deltaTime;
 
        
        gameObject.transform.LookAt(Player.position);
        float Dist = Vector3.Distance(Player.position, transform.position);
        if(Dist <= AttackRange && attack_Timer > attack_Rate)
        {
            Instantiate(Projectile, transform.position, transform.rotation);
            attack_Timer = 0f;
        }
    }
}
