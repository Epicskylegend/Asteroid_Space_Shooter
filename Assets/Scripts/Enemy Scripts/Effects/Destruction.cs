using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Destruction: baseDestruction
{
   
    public static void explosionEffect(Vector2 spawnPosition, GameObject explosionPrefab)
    {
        GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
        Destroy(explosion, 1);
    }
}
