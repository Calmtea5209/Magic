using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSmokeDestroy : MonoBehaviour
{
    private float timer = 0;
    private float destroyTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= destroyTime)
        {
            Destroy(gameObject);
        }
    }
}
