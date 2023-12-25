using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaGunBullet : Bullet
{

    public GameObject bulletPrefab;
    public Transform firePoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rateOfFire();
        bulletTravelSpeed();
        damagePerShot();
        fireShot();
        
    }


    void rateOfFire()
    {
        fireRate = 0.2f;
    }

    void bulletTravelSpeed()
    {
        bulletSpeed = 1f;
    }

    void damagePerShot()
    {
        damage = 5;
    }

    public void fireShot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        if(Input.GetMouseButtonDown(0))
        {

        }
           
    }
}
