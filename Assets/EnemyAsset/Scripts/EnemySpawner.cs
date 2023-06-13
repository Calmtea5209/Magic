using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;

    private float timer = 0;
    public float spawnRate = 60;
    private List<GameObject> spawnedEnemies = new List<GameObject>();

    int status = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate && status != 2)
        {
            GameObject newEnemy = Instantiate(enemy[Random.Range(0, 6)], transform.position, transform.rotation);
            spawnedEnemies.Add(newEnemy);
            timer = 0;
        }

        if (GameObject.Find("Boss") && status == 0)
        {
            status = 1;
        }
        else if(!GameObject.Find("Boss") && status == 1){
            status = 2;
            Invoke("DestroyAllEnemies",1f);
        }
    }

    void DestroyAllEnemies()
    {
        for (int i=0;i<spawnedEnemies.Count;i++)
        {
            GameObject enemyObject = spawnedEnemies[i];
            if (enemyObject != null)
            {
                Destroy(enemyObject);
            }
        }
    }
}
