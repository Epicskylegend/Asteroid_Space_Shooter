using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isCollidingWithEnemy = false;
    private Timer colorTimer = new Timer(0.2f);
   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        colorTimer.OnTimerDone += resetColor;

    }

    void Update()
    {
        colorTimer.Tick();
    }

 

    private void FixedUpdate()
    {
        if (!isCollidingWithEnemy)
        {
            resetColor();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            spriteRenderer.color = Color.red;
            isCollidingWithEnemy = true;

            colorTimer.ResetTimer();

        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithEnemy = false;
            resetColor();
        }
    }

    private void resetColor()
    {
        spriteRenderer.color = originalColor;

    }

}
