using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    public Rigidbody2D projectile;
    public Transform Launcher;
    public float speed = 2f;

    private float distance = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 spawnPos = Launcher.transform.position + Launcher.transform.up * distance;

            Rigidbody2D projectileInstance;
            projectileInstance = Instantiate(projectile, spawnPos, Launcher.rotation) as Rigidbody2D;

            BulletMovement.speed = speed;
        }
    }
}
