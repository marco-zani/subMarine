using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public static float speed;

    Rigidbody2D rb2d;
    private float startingTime = 0;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb2d.velocity = transform.up * speed;

        if (startingTime == 0)
            startingTime = Time.time;
        else
        {
            if (Time.time - startingTime > 10)
                Destroy(gameObject);
        }
    }
}
