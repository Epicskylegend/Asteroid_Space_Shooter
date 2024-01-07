using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{


    public float damage;
    public float speed;
    public float trackingSpeed;
    public float trackingTime;
    public float health;
    public float rotationSpeed;
    public GameObject asteroidPrefab;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
