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

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "PlayerAttackDark")//�������a
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackWater")//�������a
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackLight")//�������a
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackFlora")//�������a
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackFire")//�������a
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "PlayerAttackDirt")//�������a
        {
            Destroy(gameObject);
        }
    }
}
