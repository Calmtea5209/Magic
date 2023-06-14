using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Shooter : MonoBehaviour
{

    public Camera cam;
    public GameObject[] projectiles;
    public GameObject currentProjectile;
    public Transform firePoint;
    public Sound[] sounds;
    public MPbar mpBar;
    public float projectileSpeed = 30;
    public float fireRate = 4;
    public float arcRange = 1;
    public float consumeMP = 4;
    private float timetoFire;
    private Vector3 destination;
    private int id = 0;


    void Start() {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = false;
            
        }    
    }


    void Update()
    {
        if(Predict.result < projectiles.GetLength(0))
        {
            id = Predict.result;
            currentProjectile = projectiles[id];
        }
        if(Input.GetButton("Fire1") && Time.time >=timetoFire && !LeverControl.mouseOnLever)
        {
            if(consumeMP <= MPbar.currentMP)
            {
                timetoFire = Time.time + 1/fireRate;
                mpBar.UseMP(consumeMP);
                ShootProjectile();
            }
        }
    }
    void ShootProjectile()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile(firePoint); 
        playSoundEffect(id);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(currentProjectile,firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj, new Vector3(UnityEngine.Random.Range(arcRange, arcRange), UnityEngine.Random.Range(arcRange, arcRange), 0), UnityEngine.Random.Range(0.2f, 0.5f));
        Destroy(projectileObj,6);
    }

    
    public void playSoundEffect(int id) 
    {
        Sound soundObj = Array.Find(sounds, sound => sound.id == id);       

        soundObj.source.Play();                                                    

    }
}
