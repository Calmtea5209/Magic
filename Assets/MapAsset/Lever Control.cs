using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    static public bool[] isPulled = new bool[4];
    static public bool mouseOnLever = false;
    public int number = 0;

    void OnMouseEnter()
    {
        if (!isPulled[number] && Vector3.Distance(gameObject.transform.position, PlayerMovement.PlayerPosision) <= 3)
            gameObject.GetComponent<Outline>().enabled = true;
        mouseOnLever = true;
    }

    void OnMouseExit()
    {
        gameObject.GetComponent<Outline>().enabled = false;
        mouseOnLever = false;
    }

    void OnMouseDown()
    {
        if (number == 3 && !isPulled[3] && Vector3.Distance(gameObject.transform.position, PlayerMovement.PlayerPosision) <= 3)
        {
            if (isPulled[0] && isPulled[1] && isPulled[2])
            {
                GameObject.Find("Player").GetComponent<Shooter>().playSoundEffect(8);
                gameObject.GetComponent<Animation>().Play();
                isPulled[number] = true;
            }
        }

        else if (!isPulled[number] && Vector3.Distance(gameObject.transform.position, PlayerMovement.PlayerPosision) <= 3)
        {
            gameObject.GetComponent<Animation>().Play();
            isPulled[number] = true;

            if (isPulled[0] && isPulled[1] && isPulled[2])
            {
                GameObject.Find("lever_end").GetComponent<Outline>().OutlineColor = Color.white;
            }
        }
    }
}
