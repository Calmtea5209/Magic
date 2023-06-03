using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpitFire : MonoBehaviour
{
 // public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    public float AttackRange;
    public float BigFireBallRange;
    public GameObject Projectile;
    public GameObject BigFireBall;
    private float attack_Timer = 0;
    private float attack_Rate = 1;
    private float bigFireBallTimer = 0;
    private float bigFireBallRate = 30;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        attack_Timer += Time.deltaTime;
        bigFireBallTimer += Time.deltaTime;
        gameObject.transform.LookAt(Player.position);

        float Dist = Vector3.Distance(Player.position, transform.position);

        if (bigFireBallTimer < bigFireBallRate)
        {
            if (Dist <= AttackRange && attack_Timer > attack_Rate)
            {
                Instantiate(Projectile, transform.position, transform.rotation);
                Instantiate(Projectile, transform.position, transform.rotation * Quaternion.Euler(0f, 10f, 0f));
                Instantiate(Projectile, transform.position, transform.rotation * Quaternion.Euler(0f, -10f, 0f));
                Instantiate(Projectile, transform.position, transform.rotation * Quaternion.Euler(0f, 20f, 0f));
                Instantiate(Projectile, transform.position, transform.rotation * Quaternion.Euler(0f, -20f, 0f));
                attack_Timer = 0f;
            }
        }
        else
        {
            if (Dist <= BigFireBallRange)
            {
                Instantiate(BigFireBall, transform.position, transform.rotation);
                bigFireBallTimer = 0f;
            }
        }
    }
}
