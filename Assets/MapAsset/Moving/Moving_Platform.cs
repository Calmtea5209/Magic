using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    bool isHidden = false;
    public float move = 0.005f;
    public float inEdge = 36f;
    public float outEdge = 33f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= outEdge)
            isHidden = true;
        if (transform.position.z <= inEdge)
            isHidden = false;

        if (!isHidden)
            transform.Translate(0, 0, move);
        else
            transform.Translate(0, 0, -move);
    }
}
