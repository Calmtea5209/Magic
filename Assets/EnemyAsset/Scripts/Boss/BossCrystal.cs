using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCrystal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerAttackDark")//打中玩家
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackWater")//打中玩家
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackLight")//打中玩家
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackFlora")//打中玩家
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackFire")//打中玩家
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackDirt")//打中玩家
        {
            Destroy(gameObject);
        }
    }
}
