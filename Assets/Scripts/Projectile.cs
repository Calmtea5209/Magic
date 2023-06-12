using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   
    public GameObject impactVFX;
    private bool collided;
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag != "Bullet" && other.gameObject.tag != "Player" && !collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX,other.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);

            Destroy(gameObject);
        }
    }
}
