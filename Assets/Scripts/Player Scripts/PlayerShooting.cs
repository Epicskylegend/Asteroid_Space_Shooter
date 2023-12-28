using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : PlasmaGunBullet
{

    //PlasmaGunBullet plasmaBullet = new PlasmaGunBullet();

    public List<Bullet> bulletPrefabs;
    int currWeapon = 0;
    float fireRate = 1 / 10f;
    float lastFireTime = 0f;


    void Update()
    {
        Shoot();
        cycleWeapon();
        
    }

    void Shoot()
    {
      
        if (Input.GetMouseButton(0))
        {
            lastFireTime += Time.deltaTime;
            Debug.Log("Last fire time: " + lastFireTime);
            if (lastFireTime >= fireRate)

            {
                PlasmaGunBullet.fireShot(firePoint, bulletPrefabs[currWeapon].bulletPrefab, bulletPrefabs[currWeapon].bulletSpeed);
                //Debug.Log("Last fire time before reset: " + lastFireTime);
                //lastFireTime -= Time.time;
                //Debug.Log("Last fire time: " + lastFireTime);

                Console.WriteLine(currWeapon);
                lastFireTime = 0;
            }
        }
            
        
      
            else if (currWeapon == 1 && Input.GetMouseButtonDown(0))
            {
            Console.WriteLine("Yes");
            Console.WriteLine(currWeapon);
            }
            else
            {
                lastFireTime = 0;
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
