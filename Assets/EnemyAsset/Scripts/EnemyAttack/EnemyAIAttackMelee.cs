using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIAttackMelee : MonoBehaviour
{
    public Transform Player;
    public float AttackRange = 1.8f;
    public GameObject Melee;
    private float attack_Timer = 0;
    private float attack_Rate = 2;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        attack_Timer += Time.deltaTime;
        
        float Dist = Vector3.Distance(Player.position, transform.position);
        if(Dist <= AttackRange && attack_Timer >= attack_Rate)
        {
            Instantiate(Melee, transform.position, transform.rotation);
            
            attack_Timer = 0f;
        }
    }
}
