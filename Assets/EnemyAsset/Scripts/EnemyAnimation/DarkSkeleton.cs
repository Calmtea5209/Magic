using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSkeleton : MonoBehaviour
{
    Animator animator;

    public Transform Player;
    private float range = 2.3f;
    private float play_Rate = 2f;
    private float timer = 0;

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
    }
}
