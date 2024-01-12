using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Asteroid1 : Enemy
{
    public CameraShake cameraShake;
    private ScoreHUD score;
    public GameObject increaseScorePrefab;

    public List<Destruction> explosionPrefabs;
 

    public Transform spawnPoint;
    public Rigidbody2D rb;
    public Vector2 asteroidPosition;
    public float deathScore;




    // Start is called before the first frame update
    void Start()
    {
        cameraShake = GetComponent<CameraShake>();
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreHUD>();

        AsteroidDamage();
        AsteroidHealth();
        AsteroidRotationSpeed();
        AsteroidTrackingTime();
        AsteroidSpeed();
        AsteroidTrackingSpeed();
    }

    // Update is called once per frame
    void Update()
    {    
        //playerTracking();
        isAlive();
       
       

    }

    void AsteroidDamage()
    {
        damage = 10;
    }
    void AsteroidSpeed()
    {
        speed -= 0.08f * Time.time;
    }
    void AsteroidTrackingSpeed()
    {
       
        trackingSpeed += 0.08f * Time.time;
    }
      
    void AsteroidTrackingTime()
    {
        trackingTime = 0;
    }

    void AsteroidHealth()
    {
        health = Mathf.Round(0.1f * Time.time);
    }
    void AsteroidRotationSpeed()
    {
        rotationSpeed = UnityEngine.Random.Range(45, 1000);
    }


   void isAlive()
    {
        if (health <= 0)
        {
           
            IncreaseScore scoreIndicator = increaseScoreIndicator();   
            deathScore = Mathf.Round(5 * Time.time);
            scoreIndicator.deathScore = deathScore;

            asteroidPosition = transform.position; // Get position
            Destruction.explosionEffect(asteroidPosition, explosionPrefabs[0].explosionPrefab); // Create explosion effect
            score.increaseScore(deathScore);
           
            Destroy(this.gameObject);




            if (cameraShake != null)
            {
                cameraShake.Shake(500f, 1f);
            }
           
        }
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
        if(!collision.gameObject.CompareTag("asteroidFollowLimit"))
        {
            playerTracking();
        }
       
    }


    void playerTracking()
    {
        trackingTime += Time.deltaTime;
        
        
        GameObject target = GameObject.FindGameObjectWithTag("Player");

        Vector2 distance = target.transform.position - transform.position;

        Vector2 direction = distance.normalized;

        rb.velocity = trackingSpeed * direction;
        

    }
    private IncreaseScore increaseScoreIndicator ()
    {
        GameObject HUD = GameObject.FindGameObjectWithTag("HUD");
        GameObject increaseScoreObject = Instantiate(increaseScorePrefab, transform.position, Quaternion.identity, HUD.transform);
        return increaseScoreObject.GetComponent<IncreaseScore>();
    }

   

    
}
