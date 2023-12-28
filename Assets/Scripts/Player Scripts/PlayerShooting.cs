using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : PlasmaGunBullet
{

    //PlasmaGunBullet plasmaBullet = new PlasmaGunBullet();

    public List<Bullet> bulletPrefabs;
    int currWeapon = 0;
    float fireRate = 1 / 5f;
    float lastFireTime = 0f;


    void Update()
    {
        Shoot();
        cycleWeapon();
        
    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        { 
            lastFireTime += Time.time;
            Debug.Log("yes " + lastFireTime + " yes");
            if (lastFireTime >= fireRate)
                Debug.Log("Fire rate is: " + fireRate);
            {
                PlasmaGunBullet.fireShot(firePoint, bulletPrefabs[currWeapon].bulletPrefab, bulletPrefabs[currWeapon].bulletSpeed, 5);
                lastFireTime = 0;

                Console.WriteLine(currWeapon);
            }
        }
        else if (currWeapon == 1 && Input.GetMouseButtonDown(0))
        {
            Console.WriteLine("Yes");
            Console.WriteLine(currWeapon);
        }
    }

    void cycleWeapon()
    {
        if (Input.GetMouseButtonDown(2) && currWeapon == 0)
        {
            currWeapon += 1;
        }
        else if (Input.GetMouseButtonDown(2) && currWeapon == 1)
        {
            currWeapon -= 1;
        }
    }
}
