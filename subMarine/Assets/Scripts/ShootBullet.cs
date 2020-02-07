using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Rigidbody2D projectile;
    public float speed = 7f;
    public float setTime = 2f;
    public float distance = 1f;

    private Rigidbody2D projectileInstance;
    private float currentTime;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = -2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
            if ((Time.time - currentTime) > setTime)
            {
                Vector3 spawnPos = transform.position + transform.up * distance;

                projectileInstance = Instantiate(projectile, spawnPos, transform.rotation) as Rigidbody2D;

                BulletMovement.speed = speed;

                currentTime = Time.time;
            }
    }
}
