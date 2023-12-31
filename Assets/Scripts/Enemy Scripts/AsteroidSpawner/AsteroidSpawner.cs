using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Asteroid1
{
    //[SerializeField]
    public List<Enemy> asteroidPrefabs;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("launchAsteroid", 1, 1);
       
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void launchAsteroid()
    {
        float randomSpawn = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnPoint.position.x, randomSpawn);
        Asteroid1.spawnAsteroid(spawnPosition, asteroidPrefabs[0].asteroidPrefab, asteroidPrefabs[0].speed, asteroidPrefabs[0].rotationSpeed);

    }
}
