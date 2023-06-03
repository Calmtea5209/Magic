using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent enemy;
    public Transform Player;
    public float closestRangeToSpit = 10;
    private float timer = 0;
   
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        float Dist = Vector3.Distance(Player.position, transform.position);



        if (Dist > closestRangeToSpit)
        {
            enemy.SetDestination(Player.position);
        }
        else
        {
            enemy.SetDestination(transform.position);
            gameObject.transform.LookAt(Player.position);
         }
        

    }
}
