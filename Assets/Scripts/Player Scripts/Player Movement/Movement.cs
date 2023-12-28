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
        
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) && transform.position.y < 8.961)
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveUpSpeed);

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -18.78)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveLeftSpeed);

        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && transform.position.y > -8.961)
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveDownSpeed);

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) && transform.position.x < 18.78)
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveRightSpeed);

        }

    }
}
