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
        destroyAsteroidOffMap();
        
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
            
            Debug.Log("Asteroid Health: " + health);
        }
        if (health <= 0)
        {
           Destroy(this.gameObject);
        }
    }
    void destroyAsteroidOffMap()
    {
        if(transform.position.y >= -10.961 || transform.position.y <= 10.961 || transform.position.x >= 20.78 || transform.position.x <= -20.78)
        {
            //Destroy(gameObject);
        }


                

        
    }
   
       
    
}
