using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlasmaGunBullet : Bullet
{
    [HideInInspector]
    public Transform firePoint;
   

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
        bulletSpeed = 30f;
    }

    void damagePerShot()
    {
        damage = 5;
    }   
    void bulletDuration()
    {
        duration = 5f;
    }


    public static void fireShot(Transform firePoint, GameObject bulletPrefab, float bulletSpeed)
    {
       
        Collider2D rightBoundary = GameObject.FindGameObjectWithTag("Right Boundary").GetComponent<Collider2D>();
              
        GameObject plasmaBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRigidbody = plasmaBullet.GetComponent<Rigidbody2D>();
        Collider2D bullet = plasmaBullet.GetComponent<Collider2D>();
        bulletRigidbody.velocity = plasmaBullet.transform.right * bulletSpeed;


        Physics2D.IgnoreCollision(bullet, rightBoundary);
        destroyBullet(plasmaBullet, 2);
    }



    public static void destroyBullet(GameObject plasmaBullet, float duration)
    {
        Destroy(plasmaBullet, duration);
       
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }


}
