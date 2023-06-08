using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon: MonoBehaviour
{
    public GameObject specialEffect;
    float Destory_time = 0.5f;
    float timer = 0;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += timer + Time.deltaTime;
        

        if (timer >= Destory_time )
        {
            Instantiate(specialEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
