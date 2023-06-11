using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour
{
    float timer = 0f;
    bool isEnter = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (LeverControl.pulled[3] == true && transform.position.y < -0.9 && timer >= 0.01 && !MainMapClear.isLocked_m[8])
        {
            transform.Translate(0, 0.04f, 0);
            timer = 0f;
        }

        if (MainMapClear.isLocked_m[8])
        {
            transform.Translate(0, -4f, 0);
        }
    }
}
