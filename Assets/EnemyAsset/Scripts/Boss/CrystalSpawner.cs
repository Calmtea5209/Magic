using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CrystalSpawner : MonoBehaviour
{
    private float SpawnTimer = 0;
    public float SpawnTime = 100;
    public GameObject CrystalPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = SpawnTime;
        Instantiate(CrystalPrefab, transform.position, transform.rotation);
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
                Instantiate(CrystalPrefab, transform.position, transform.rotation);
            }
        }
    }
}
