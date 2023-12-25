using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerShooting : MonoBehaviour
{
    PlasmaGunBullet plasmaBullet = new PlasmaGunBullet();

    public List<Bullet> bulletPrefabs;
    int currWeapon = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
        cycleWeapon();
        
    }

    void Shoot()
    {
        if(currWeapon == 0 && Input.GetMouseButtonDown(1))
        {
            //Console.WriteLine(weapons[currWeapon]);
            plasmaBullet.fireShot();
        }
        else if(currWeapon == 1 && Input.GetMouseButtonDown(1))
        {
            Console.WriteLine("Yes");
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
