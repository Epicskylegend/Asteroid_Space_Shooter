using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Destruction: baseDestruction
{
    [SerializeField]
    //public Transform spawnPoint;
  

    void Start()
    {

    }

    void Update()
    {

    }

    public static void explosionEffect(Vector2 spawnPosition, GameObject explosionPrefab)
    {
        GameObject explosion = Instantiate(explosionPrefab, spawnPosition, Quaternion.identity);
        Destroy(explosion, 1);
    }
}
