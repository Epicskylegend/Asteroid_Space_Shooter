using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteroid1 : Enemy
{
  
    public Transform spawnPoint;
    public Rigidbody2D rb;
    
   



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
        isAlive();
    }

    void AsteroidDamage()
    {
        damage = 5;
    }
    void AsteroidSpeed()
    {
        speed = 5;
    }
    void AsteroidTrackingSpeed()
    {
       
        trackingSpeed = 10f;
    }
      
    void AsteroidTrackingTime()
    {
        trackingTime = 0;
    }

    void AsteroidHealth()
    {
        health = 10;
    }
    void AsteroidRotationSpeed()
    {
        rotationSpeed = UnityEngine.Random.Range(45, 100);
    }


    void isAlive()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public static void spawnAsteroid(Transform spawnPoint, GameObject asteroidPrefab, float speed, float rotationSpeed)
    {
        GameObject asteroid1 = Instantiate(asteroidPrefab, spawnPoint.position, Quaternion.identity);
        Collider2D asteroidCollider = asteroid1.GetComponent<Collider2D>();
        Rigidbody2D asteroidRigidbody = asteroid1.GetComponent<Rigidbody2D>();
        asteroidRigidbody.velocity = asteroid1.transform.right * speed;
        asteroidRigidbody.angularVelocity = rotationSpeed;

        //Ignore collisions with player boundaries
        Collider2D asteroid1Collider = asteroid1.GetComponent<Collider2D>();
        Collider2D rightBoundary = GameObject.FindGameObjectWithTag("Right Boundary").GetComponent<Collider2D>();
        Collider2D leftBoundary = GameObject.FindGameObjectWithTag("Left Boundary").GetComponent<Collider2D>();
        Collider2D topBoundary = GameObject.FindGameObjectWithTag("Top Boundary").GetComponent<Collider2D>();
        Collider2D bottomBoundary = GameObject.FindGameObjectWithTag("Bottom Boundary").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(asteroidCollider, rightBoundary);
        Physics2D.IgnoreCollision(asteroidCollider, topBoundary);
        Physics2D.IgnoreCollision(asteroidCollider, leftBoundary);
        Physics2D.IgnoreCollision(asteroidCollider, bottomBoundary);

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
       
    }
  
    
    void playerTracking ()
    {
        trackingTime += Time.deltaTime;
        if (trackingTime <= 3)
        {
            GameObject target = GameObject.FindGameObjectWithTag("Player");
            
            Vector2 distance = target.transform.position - transform.position;
           
            Vector2 direction = distance.normalized;

            rb.velocity = trackingSpeed * direction;
        }

    }
   
       
    
}
