using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrystalSpawner : MonoBehaviour
{
    private float SpawnTimer = 0;
    private float SpawnTime = 10;
    private int numberToSpawn = 3;
    public GameObject CrystalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = SpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer += Time.deltaTime;

        if(GameObject.FindWithTag("BossCrystal") != null)//There're crystals.
        {
            SpawnTimer = 0;
        }
        else//There's no crystal.
        {
            
            if (SpawnTimer >= SpawnTime)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Vector3 randomSpawnPosition = new Vector3(Random.Range(-70f, 71f), 1.5f, Random.Range(-70f, 71f));
                    Instantiate(CrystalPrefab, transform.position + randomSpawnPosition, Quaternion.identity);
                }
            }
        }
    }
}
