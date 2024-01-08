using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteroid1 : Enemy
{
    public CameraShake cameraShake;
    private HUD score; 
    public List<Destruction> explosionPrefabs;
    public Transform spawnPoint;
    public Rigidbody2D rb;
    public Vector2 asteroidPosition;





    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GetComponent<CameraShake>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<HUD>();

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
        damage = 10;
    }
    void AsteroidSpeed()
    {
        speed = 1;
    }
    void AsteroidTrackingSpeed()
    {
       
        trackingSpeed = 5f;
    }
      
    void AsteroidTrackingTime()
    {
        trackingTime = 0;
    }

    void AsteroidHealth()
    {
        health = 30;
    }
    void AsteroidRotationSpeed()
    {
        rotationSpeed = UnityEngine.Random.Range(45, 1000);
    }


    void isAlive()
    {
        if (health <= 0)
        {
            asteroidPosition = transform.position; // Get position
            Destruction.explosionEffect(asteroidPosition, explosionPrefabs[0].explosionPrefab); // Create explosion effect
            score.increaseScore();
            if (cameraShake != null)
            {
                cameraShake.Shake(500f, 1f);
            }
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }

    public static void spawnAsteroid(Vector2 spawnPosition,  GameObject asteroidPrefab, float speed, float rotationSpeed)
    {
        GameObject asteroid1 = Instantiate(asteroidPrefab, spawnPosition, Quaternion.identity);
        Collider2D asteroidCollider = asteroid1.GetComponent<Collider2D>();
        Rigidbody2D asteroidRigidbody = asteroid1.GetComponent<Rigidbody2D>();
        asteroidRigidbody.velocity = asteroid1.transform.right * speed;
        asteroidRigidbody.angularVelocity = rotationSpeed;

        
        Collider2D rightBoundaryCollider = GameObject.FindGameObjectWithTag("Right Boundary").GetComponent<Collider2D>();

        if (rightBoundaryCollider != null)
        {
            Physics2D.IgnoreCollision(asteroidCollider, rightBoundaryCollider);
        }

        //Ignore collisions with player boundaries
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
        if (collision.gameObject.CompareTag("Player"))
        {
            asteroidPosition = transform.position; 
            Destruction.explosionEffect(asteroidPosition, explosionPrefabs[0].explosionPrefab);
            Destroy(this.gameObject);

        }

        if (collision.gameObject.CompareTag("Boundary"))
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
