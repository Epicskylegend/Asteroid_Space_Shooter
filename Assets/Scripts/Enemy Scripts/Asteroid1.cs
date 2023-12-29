using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Asteroid1 : Enemy
{
    public GameObject asteroidPrefab;
    public Transform spawnPoint;

    
    // Start is called before the first frame update
    void Start()
    {
        AsteroidDamage();
        AsteroidSpeed();
        AsteroidHealth();
        AsteroidRotationSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AsteroidDamage()
    {
        damage = 5;
    }
    void AsteroidSpeed()
    {
        speed = -5;
    }

    void AsteroidHealth()
    {
        health = 10;
    }
    void AsteroidRotationSpeed()
    {
        rotationSpeed = 5;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public static void spawnAsteroid(Transform spawnPoint, GameObject asteroidPrefab, float speed)
    {
        GameObject asteroid1 = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D asteroidRigidbody = asteroid1.GetComponent<Rigidbody2D>();
        asteroidRigidbody.velocity = asteroid1.transform.right * speed;
    }
}
