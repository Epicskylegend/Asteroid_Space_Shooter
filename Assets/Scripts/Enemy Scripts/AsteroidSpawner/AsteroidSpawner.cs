using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : Asteroid1
{
    public List<Enemy> asteroidPrefabs;
    public float minY;
    public float maxY;

    public float initialAsteroidSpawnInterval = 3.0f; // Initial spawn interval
    public float asteroidSpawnIntervalDecrease = 0.002f; // Rate at which spawn interval decreases
    private float lastAsteroidSpawnTime;

    void Start()
    {
        lastAsteroidSpawnTime = Time.time + initialAsteroidSpawnInterval;
        
    }

    void LaunchAsteroid()
    {
        float randomSpawn = Random.Range(minY, maxY);
        Vector2 spawnPosition = new Vector2(spawnPoint.position.x, randomSpawn);
        Asteroid1.spawnAsteroid(spawnPosition, asteroidPrefabs[0].asteroidPrefab, asteroidPrefabs[0].speed, asteroidPrefabs[0].rotationSpeed);
    }

    void Update()
    {
        LaunchAsteroidIntervals();
    }

    void LaunchAsteroidIntervals()
    {
        if (Time.time >= lastAsteroidSpawnTime)
        {
            LaunchAsteroid();
            lastAsteroidSpawnTime += initialAsteroidSpawnInterval; // Add initial interval first

            // Decrease spawn interval over time
            initialAsteroidSpawnInterval -= asteroidSpawnIntervalDecrease;

            // Ensure the spawn interval does not go below a certain threshold
            if (initialAsteroidSpawnInterval < 0.2f)
            {
                initialAsteroidSpawnInterval = 0.2f;
            }
        }
    }
}
