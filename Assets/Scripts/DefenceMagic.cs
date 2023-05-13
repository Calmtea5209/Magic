using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceMagic : MonoBehaviour
{
    public GameObject[] MagicCircles;
    public GameObject currentMagicCircle;
    public Transform PlayerBottom;
    private GameObject defenceObj;
    public MPbar mpBar;

    public bool isDefence = false;
    public float consumeMP = 10;
    private float timetoRecoverMP;
    public float RecoverRate = 100;


    // Update is called once per frame
    void Update()
    {
        if(Predict.result < MagicCircles.GetLength(0))
        {
            currentMagicCircle = MagicCircles[Predict.result];
        }
        if(!isDefence && Input.GetMouseButton(1))
        {   
            isDefence = true;
            defenceObj = Instantiate(currentMagicCircle, PlayerBottom.position, Quaternion.identity);
        }
        if (isDefence)
        {
            defenceObj.transform.position = PlayerBottom.position;
            if(consumeMP <= MPbar.currentMP)
            {
                if(Time.time >=timetoRecoverMP)
                {
                    timetoRecoverMP = Time.time + 1/RecoverRate;
                    mpBar.UseMP(consumeMP);
                }
            }
            else
            {
                isDefence = false;
                Destroy(defenceObj);
            }
        }
        if(isDefence && Input.GetMouseButtonUp(1))
        {
            isDefence = false;
            Destroy(defenceObj);
        }
    }

}
