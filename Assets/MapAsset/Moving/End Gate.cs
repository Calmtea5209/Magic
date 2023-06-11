using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGate : MonoBehaviour
{
    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (LeverControl.isPulled[3]&& transform.position.y < -0.9 && timer >= 0.01)
        {
            transform.Translate(0, 0.012f, 0);
            timer = 0f;
        }

        if (MainMapClear.isLocked_m[8] && LeverControl.isPulled[3])
        {
            transform.Translate(0, -4f, 0);
            LeverControl.isPulled[3] = false;
            GameObject.Find("Player").GetComponent<Shooter>().playSoundEffect(9);
        }
    }
}
