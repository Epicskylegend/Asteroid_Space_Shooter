using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveLeftSpeed = 5f;
    float moveRightSpeed = 4.5f;
    float moveUpSpeed = 4.5f;
    float moveDownSpeed = 5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
        PlayerMovement();     
    }

    
    void PlayerMovement()
    {
        
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && !onBoundary("Top Boundary"))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveUpSpeed);

        }

        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && !onBoundary("Left Boundary"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveLeftSpeed);

        }

        if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && !onBoundary("Bottom Boundary"))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveDownSpeed);

        }
        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && !onBoundary("Right Boundary"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveRightSpeed);

        }

    }

    bool onBoundary(string tag)
    {
        Collider2D collider = GetComponent<Collider2D>();
        Collider2D[] colliders = Physics2D.OverlapBoxAll(collider.bounds.center, collider.bounds.size, 0f);
        foreach(Collider2D col in colliders)
        {
            if(col.gameObject.CompareTag(tag))
            {
                return true;
            }
        }
        return false;
    }
}
