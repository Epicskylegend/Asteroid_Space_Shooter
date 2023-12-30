using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteroid1 : Enemy
{
  
    public Transform spawnPoint;
    
   



    // Start is called before the first frame update
    void Start()
    {
        AsteroidDamage();
        AsteroidSpeed();
        AsteroidHealth();
        AsteroidRotationSpeed();
        AsteroidTrackingSpeed();
        AsteroidTrackingTime();
    }

    // Update is called once per frame
    void Update()
    {
        
        playerTracking();

    }

    void AsteroidDamage()
    {
        damage = 5;
    }
    void AsteroidSpeed()
    {
        speed = -5;
    }
    void AsteroidTrackingSpeed()
    {
        if(Time.time <= 2)
        {
            trackingSpeed = 10;
        }
        else
        {
            trackingSpeed = 0;
        }
       
    }
    void AsteroidTrackingTime()
    {
        trackingTime = 2;
    }

    void AsteroidHealth()
    {
        health = 10;
    }
    void AsteroidRotationSpeed()
    {
        rotationSpeed = UnityEngine.Random.Range(45, 100);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public static void spawnAsteroid(Transform spawnPoint, GameObject asteroidPrefab, float speed, float rotationSpeed)
    {
      

        GameObject asteroid1 = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
        Rigidbody2D asteroidRigidbody = asteroid1.GetComponent<Rigidbody2D>();
        asteroidRigidbody.velocity = asteroid1.transform.right * speed;
        asteroidRigidbody.angularVelocity = rotationSpeed;


      
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlasmaBullet"))
        {
            PlasmaGunBullet plasmaBullet = collision.gameObject.GetComponent<PlasmaGunBullet>();
            health -= plasmaBullet.damage;
        }
        if(collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }
        if (health <= 0)
        {
           Destroy(this.gameObject);
        }
    }
  
    
    void playerTracking ()
    {
        trackingSpeed += Time.deltaTime;
        if (trackingSpeed <= 5)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, trackingSpeed * Time.deltaTime);
        }

    }
   
       
    
}
