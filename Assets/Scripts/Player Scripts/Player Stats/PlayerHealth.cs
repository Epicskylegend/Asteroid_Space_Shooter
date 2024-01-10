using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Asteroid1 asteroid1;
    public float health = 100;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Asteroid1 asteroid1 = collision.gameObject.GetComponent<Asteroid1>();

            health -= asteroid1.damage;
        }
    }

}
