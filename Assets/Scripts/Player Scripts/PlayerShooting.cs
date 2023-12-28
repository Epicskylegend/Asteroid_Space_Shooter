using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : PlasmaGunBullet
{

    public List<Bullet> bulletPrefabs;
    int currWeapon = 0;
    float fireRate = 0.2f;
    float lastFireTime = 0f;

    void Update()
    {
        lastFireTime += Time.deltaTime;
        Shoot();
        cycleWeapon();
        
    }

    void Shoot()
    {
      
        if (Input.GetMouseButton(0) && lastFireTime >= fireRate)
        {
            PlasmaGunBullet.fireShot(firePoint, bulletPrefabs[currWeapon].bulletPrefab, bulletPrefabs[currWeapon].bulletSpeed);
            lastFireTime = 0f;           
        }
       
                
      
        if (currWeapon == 1 && Input.GetMouseButtonDown(0))
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
