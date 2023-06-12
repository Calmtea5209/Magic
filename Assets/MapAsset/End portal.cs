using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endportal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject[] portal;

    // Update is called once per frame
    void Update()
    {
       if (BossHealth.BossIsDead)
       {
            // gameObject.transform.SetPositionAndRotation(BossHealth.BossDeadPoint, gameObject.transform.rotation);
            foreach (GameObject obj in portal)
            {
                obj.SetActive(true);
            }
        }
    }
}
