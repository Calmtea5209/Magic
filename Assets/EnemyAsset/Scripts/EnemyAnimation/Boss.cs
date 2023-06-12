using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    Animator animator;

    public Transform Player;
    private float range = 30f;
    private float play_Rate = 4f;
    private float timer = 0;
    private float BigFireBallTimer = 0;
    private float bigFireBall_Rate = 30;
    private float bigFireBall_Range = 50;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        BigFireBallTimer += Time.deltaTime;

        float Dist = Vector3.Distance(Player.position, transform.position);

        if (Dist > range || timer < play_Rate)
        {
            animator.SetBool("isAttacking", false);
        }
        else
        {
            animator.SetBool("isAttacking", true);
            timer = 0;

        }

        if(BigFireBallTimer > bigFireBall_Rate && Dist <= bigFireBall_Range)
        {
            animator.SetBool("isAttacking", true);
            BigFireBallTimer = 0;
        }
    }
}
