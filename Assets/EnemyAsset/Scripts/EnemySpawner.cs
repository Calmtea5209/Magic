using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;

    private float timer = 0;
    public float spawnRate = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > spawnRate)
        {
            Instantiate(enemy[Random.Range(0,6)], transform.position, transform.rotation); 
            timer = 0;
        }

        if(MainMapClear.isClear_m[8])
        {
            
        }
    }
}
