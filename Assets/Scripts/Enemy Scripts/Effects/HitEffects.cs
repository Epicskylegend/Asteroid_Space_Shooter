using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isCollidingWithBullet = false;
    private Timer colorTimer = new Timer(0.1f);
   
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        colorTimer.OnTimerDone += resetColor;

    }

    // Update is called once per frame
    void Update()
    {
        colorTimer.Tick();
    }

    private void FixedUpdate()
    {
        if(!isCollidingWithBullet)
        {
            resetColor();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("PlasmaBullet"))
        {
            spriteRenderer.color = Color.red;
            isCollidingWithBullet = true;

            colorTimer.ResetTimer();
            
        }
       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("PlasmaBullet"))
        {
            isCollidingWithBullet = false;
            resetColor();
        }
    }

    private void resetColor()
    {
        spriteRenderer.color = originalColor;
       
    }

   
}
