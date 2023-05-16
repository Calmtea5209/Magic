using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMap : MonoBehaviour
{

    void Start()
    {

    }

    void OnTriggerEnter(Collider collision)
    {
        foreach (Transform tran in collision.gameObject.transform.parent)
        {
            if ((tran.position - collision.transform.position).magnitude < 8)
                tran.gameObject.layer = 10;
        }
    }

}
