using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    private Asteroid1 asteroid1;
    public float health = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Asteroid1 asteroid1 = collision.gameObject.GetComponent<Asteroid1>();

            health -= asteroid1.damage;
        }
    }

}
