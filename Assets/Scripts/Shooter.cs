using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    public Camera cam;
    public GameObject[] projectiles;
    public GameObject currentProjectile;
    public Transform firePoint;
    public AudioSource audioSource;
    public MPbar mpBar;
    public float projectileSpeed = 30;
    public float fireRate = 4;
    public float arcRange = 1;
    public float consumeMP = 4;
    private float timetoFire;
    private Vector3 destination;



    void Update()
    {
        if(Predict.result < projectiles.GetLength(0))
        {
            currentProjectile = projectiles[Predict.result];
        }
        audioSource = GetComponent<AudioSource>();
        if(Input.GetButton("Fire1") && Time.time >=timetoFire)
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
        audioSource.Play();

        if(Physics.Raycast(ray, out hit))
        {
            destination = hit.point;
        }
        else
        {
            destination = ray.GetPoint(1000);
        }
        InstantiateProjectile(firePoint);
    }

    void InstantiateProjectile(Transform firePoint)
    {
        var projectileObj = Instantiate(currentProjectile,firePoint.position, Quaternion.identity) as GameObject;
        projectileObj.GetComponent<Rigidbody>().velocity = (destination - firePoint.position).normalized * projectileSpeed;
        iTween.PunchPosition(projectileObj, new Vector3(Random.Range(arcRange, arcRange), Random.Range(arcRange, arcRange), 0), Random.Range(0.2f, 0.5f));
        Destroy(projectileObj,6);
    }
}
