using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    static public bool[] pulled = new bool[4];
    public int number = 0;

    void OnMouseEnter()
    {
        if (!pulled[number] && Vector3.Distance(gameObject.transform.position, pm.PlayerPosision) <= 3)
            gameObject.GetComponent<Outline>().enabled = true;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
    }

    void OnMouseDown()
    {
        if (number == 3 && !pulled[3] && Vector3.Distance(gameObject.transform.position, pm.PlayerPosision) <= 3)
        {
            if (pulled[0] && pulled[1] && pulled[2])
            {
                gameObject.GetComponent<Animation>().Play();
                pulled[number] = true;
            }
        }

        else if (!pulled[number] && Vector3.Distance(gameObject.transform.position, pm.PlayerPosision) <= 3)
        {
            gameObject.GetComponent<Animation>().Play();
            pulled[number] = true;

            if (pulled[0] && pulled[1] && pulled[2])
            {
                GameObject.Find("lever_end").GetComponent<Outline>().OutlineColor = Color.white;
            }
        }
    }
}
