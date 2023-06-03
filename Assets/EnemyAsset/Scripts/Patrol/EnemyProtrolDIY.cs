using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyProtrolDIY : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform[] points;
    int dest = 0;
    float distance;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(points[dest].position);
        distance = Vector3.Distance(transform.position, points[dest].position);

        if(distance < 2f)
        {
            dest = (dest + 1) % points.Length;
        }
    }
}
