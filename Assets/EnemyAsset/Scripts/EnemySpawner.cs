using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public GameObject boss;

    private float timer = 0;
    public float spawnRate = 60;
    GameObject[] del;
    int idx = 0;
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
            GameObject tmp;
            tmp = Instantiate(enemy[Random.Range(0,6)], transform.position, transform.rotation); 
            if (tmp)
            {
                del[idx++] = tmp;
            }
            timer = 0;
        }

        if(MainMapClear.isClear_m[8])
        {
            foreach (GameObject obj in del)
            {
                if(obj)
                {
                    Destroy(obj);
                }
            }
        }
    }
}
