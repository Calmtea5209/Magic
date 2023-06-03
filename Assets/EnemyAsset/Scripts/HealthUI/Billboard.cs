using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    // Update is called once per frame
    void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").transform;
    }
    void LateUpdate()
    {
        transform.LookAt(cam.position);
    }
}
