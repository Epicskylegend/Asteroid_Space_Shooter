using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerShooting : PlasmaGunBullet
{
    //PlasmaGunSounds plasmaGunSounds = new PlasmaGunSounds();
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
            //plasmaGunSounds.playSound();
            lastFireTime = 0f;
        }
        else if (!Input.GetMouseButton(0))
        {
            lastFireTime = 0f;
        }



        if (currWeapon == 1 && Input.GetMouseButtonDown(0))
        {


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