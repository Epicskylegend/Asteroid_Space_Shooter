using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlasmaGunBullet : Bullet
{

    public GameObject bulletPrefab;
    public Transform firePoint;
    float timer;
    private static float lastFireTime = 0f;





    // Update is called once per frame
    void Update()
    {
        rateOfFire();
        bulletTravelSpeed();
        damagePerShot();
        bulletDuration();

    }

    // Weapon atributes
    public void rateOfFire()
    {
        fireRate = 1 / 5;
    }

    void bulletTravelSpeed()
    {
        bulletSpeed = 15f;
    }

    void damagePerShot()
    {
        damage = 5;
    }   
    void bulletDuration()
    {
        duration = 5f;
    }


    public static void fireShot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed, float fireRate)
    {

        if (Input.GetMouseButtonDown(0))
        {
            lastFireTime += Time.deltaTime;
            Debug.Log("" + lastFireTime + "");
            if (lastFireTime >= fireRate)
            {
                GameObject plasmaBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRigidbody = plasmaBullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.velocity = plasmaBullet.transform.right * bulletSpeed;

                lastFireTime = 0f;
                destroyBullet(plasmaBullet, 2);
            }

        }
    }

     


    public static void destroyBullet(GameObject plasmaBullet, float duration)
    {
        Destroy(plasmaBullet, duration);
    }
    
        
}
