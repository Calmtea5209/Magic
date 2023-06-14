using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBigFireBall : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent FireBall;
    public Transform Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        FireBall.SetDestination(Player.position);
    }


    
}
