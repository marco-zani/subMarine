using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _horizontalInput = 0;
    public float maxSpeed = 0;
    public float rotationSpeed = 0;

    private float speed;

    Rigidbody2D rb2d;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetPlayerInput();
    }

    private void FixedUpdate()
    {
        RotatePlayer();
        MovePlayer();
    }


    private void GetPlayerInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if(Input.GetKey(KeyCode.W))
        {
            if (speed < maxSpeed)
                speed += 0.05f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (speed > maxSpeed * -0.5f)
                speed -= 0.05f;
        }
        else
        {
            if (speed < 0)
                speed += 0.02f;
            else
                speed -= 0.02f;
        }
    }

    private void RotatePlayer()
    {
        float rotation = -_horizontalInput * rotationSpeed;
        transform.Rotate(Vector3.forward * rotation);
    }

    private void MovePlayer()
    {
        rb2d.velocity = transform.up * speed;
    }
}