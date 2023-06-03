using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallExplosionTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private float timer = 0;
    private float destroyTime = 1f;
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
