using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{

    void Start()
    {

    }

    bool isOnAlter(Vector3 player)
    {
        Vector3 H1 = new Vector3(23f, 1.11f, 49f);
        Vector3 H2 = new Vector3(-32f, 1.11f, 34f);
        Vector3 H3 = new Vector3(36f, -3.89f, 8f);
        Vector3 H4 = new Vector3(12f, 1.1f, 94f);

        bool h = false;
        h ^= Vector3.Distance(H1, player) <= 1f;
        h ^= Vector3.Distance(H2, player) <= 1f;
        h ^= Vector3.Distance(H3, player) <= 1f;
        h ^= Vector3.Distance(H4, player) <= 1f;

        return h;
    }

    void Update()
    {
        if (isOnAlter(PlayerMovement.PlayerPosision))
        {
            Debug.Log("healing");

            /* healing code*/
        }
    }

}