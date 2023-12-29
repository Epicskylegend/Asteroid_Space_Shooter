using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Asteroid1
{
    //[SerializeField]
    public List<Enemy> asteroidPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("launchAsteroid", 1, 2);
       
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void launchAsteroid()
    {
        Asteroid1.spawnAsteroid(spawnPoint, asteroidPrefabs[0].asteroidPrefab, asteroidPrefabs[0].speed, asteroidPrefabs[0].rotationSpeed);
    }
}
