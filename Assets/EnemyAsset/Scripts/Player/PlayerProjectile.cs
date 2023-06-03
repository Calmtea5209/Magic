using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    
    public float speed;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (timer >= 2f)
        {

            Destroy(gameObject);
        }
    }


    
}
