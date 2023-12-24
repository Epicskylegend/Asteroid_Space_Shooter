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
        if(Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveUpSpeed);

        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveLeftSpeed);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector2.up * Time.deltaTime * Input.GetAxis("Vertical") * moveDownSpeed);

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * Time.deltaTime * Input.GetAxis("Horizontal") * moveRightSpeed);

        }

    }
}
