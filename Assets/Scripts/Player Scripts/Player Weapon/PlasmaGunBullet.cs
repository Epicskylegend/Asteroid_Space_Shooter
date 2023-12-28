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
   




    // Update is called once per frame
    void Update()
    {
      
        bulletTravelSpeed();
        damagePerShot();
        bulletDuration();

    }

    // Weapon atributes
   
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
               // Debug.Log("Fire rate is " + fireRate);
          
                GameObject plasmaBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Rigidbody2D bulletRigidbody = plasmaBullet.GetComponent<Rigidbody2D>();
                bulletRigidbody.velocity = plasmaBullet.transform.right * bulletSpeed;

               //lastFireTime = 0;
                destroyBullet(plasmaBullet, 2);
    }

        
    

     


    public static void destroyBullet(GameObject plasmaBullet, float duration)
    {
        Destroy(plasmaBullet, duration);
    }
    
        
}
