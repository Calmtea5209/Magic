using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtcullisOpen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LeverControl.pulled[3] == true && transform.position.y <= -0.9)
        {
            transform.Translate(0, 0.001f, 0);
        }
    }
}
