using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    float timer = 0f;
    bool isHidden = false;
    public float rate;
    public float inEdge;
    public float outEdge;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (transform.position.z >= outEdge)
            isHidden = true;
        if (transform.position.z <= inEdge)
            isHidden = false;

        if (timer >= (11-rate) * 0.001)
        {
            if (!isHidden)
                transform.Translate(0, 0, 0.02f);
            else
                transform.Translate(0, 0, -0.02f);

            timer = 0f;
        }
    }
}
