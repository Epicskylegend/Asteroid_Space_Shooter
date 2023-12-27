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
    float lastFireTime;




    // Update is called once per frame
    void Update()
    {
        rateOfFire();
        bulletTravelSpeed();
        damagePerShot();
        //timeInBetweenShots();
        //fireShot();
        bulletDuration();


    }

    // Weapon atributes
    void rateOfFire()
    {
        fireRate = 5f;
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
        duration = 1f;
    }
    public void timeInBetweenShots()
    {
        if(Input.GetMouseButtonDown(0))
        {

            timer += Time.deltaTime;
            Debug.Log("Timer: " + Time.deltaTime);

            if (timer >= fireRate)
            {

                //StartCoroutine(fireBullet());
                timer = 0f;
            }
           
        }
        else
        {
            timer = 0f;
        }
      

    }

     public static void fireShot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed)
     {
        if (Input.GetMouseButtonDown(0))
             //&& Time.time >= lastFireTime + (1 / fireRate
        {   
            
                GameObject plasmaBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRigidbody = plasmaBullet.GetComponent<Rigidbody2D>();

                bulletRigidbody.velocity = plasmaBullet.transform.right * bulletSpeed;

                //lastFireTime = Time.time;

                
        }
     } 
    
        
}
