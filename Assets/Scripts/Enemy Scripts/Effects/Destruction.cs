using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Destruction: baseDestruction
{
    [SerializeField]
    public Transform spawnPoint;
  

    void Start()
    {

    }

    void Update()
    {

    }

    public static void explosionEffect(Transform spawnPoint, GameObject explosionPrefab)
    {
        GameObject explosion = Instantiate(explosionPrefab, spawnPoint);
        Destroy(explosion, 1);
    }
}
