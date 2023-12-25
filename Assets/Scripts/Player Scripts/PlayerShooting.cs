using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerShooting : MonoBehaviour
{

    public List<Bullet> bulletPrefabs;
    int currWeapon = 0;


    void Update()
    {
        Shoot();
        cycleWeapon();
        
    }

    void Shoot()
    {
        if(currWeapon == 0 && Input.GetMouseButtonDown(0))
        {
            //Console.WriteLine(weapons[currWeapon]);
            bulletPrefabs[currWeapon].fireShot();
            Console.WriteLine(currWeapon);
        }
        else if(currWeapon == 1 && Input.GetMouseButtonDown(1))
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
