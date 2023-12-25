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
        rateOfFire();
        bulletTravelSpeed();
        damagePerShot();
        timeInBetweenShots();
        fireShot();
        
    }


    void rateOfFire()
    {
        fireRate = 0.2f;
    }

    void bulletTravelSpeed()
    {
        bulletSpeed = 15f;
    }

    void damagePerShot()
    {
        damage = 5;
    }   

    public void timeInBetweenShots()
    {
        if(Input.GetMouseButtonDown(1))
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

     void fireShot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject plasmaBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D bulletRigidbody = plasmaBullet.GetComponent<Rigidbody2D>();

            bulletRigidbody.velocity = plasmaBullet.transform.right * bulletSpeed;

            //yield return new WaitForSeconds(1f);
            //Destroy(plasmaBullet);
        }
    }
    


   
}
