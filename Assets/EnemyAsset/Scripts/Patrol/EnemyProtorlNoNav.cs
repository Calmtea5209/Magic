using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProtorlNoNav : MonoBehaviour
{
    public Transform[] points;
    int dest = 0;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != points[dest].position) 
        {
            transform.position = Vector3.MoveTowards(transform.position, points[dest].position, speed * Time.deltaTime);
        }
        else
        {
            dest = (dest + 1) % points.Length;
        }
    }
}
