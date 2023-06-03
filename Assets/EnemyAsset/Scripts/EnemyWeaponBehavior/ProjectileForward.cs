using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ProjectileForward : MonoBehaviour
{
    public GameObject specialEffect;//特效
    public float speed;
    public float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if(timer >= 2f)
        {
            Instantiate(specialEffect, transform.position, transform.rotation);
       
            Destroy(gameObject);
        }
    }


    void OnTriggerEnter(Collider  other)
    {
        if (other.gameObject.tag == "Player")//打中玩家
        {
            Instantiate(specialEffect, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
        


        
        

        
    }
}
