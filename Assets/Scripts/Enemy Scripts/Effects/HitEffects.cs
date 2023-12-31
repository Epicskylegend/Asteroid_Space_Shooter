using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffects : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private bool isCollidingWithBullet = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        //resetColor();
        Debug.Log("Original Color: " + originalColor);
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
