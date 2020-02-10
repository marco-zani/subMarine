using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public static float speed;
    public float damage = 50f;

    Rigidbody2D rb2d;
    private float startingTime = 0;
    public GameObject explosion;

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

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.name != "Player")
        {
            if (hitInfo.tag == "Enemy")
            {
                EnemyController enemy = hitInfo.GetComponent<EnemyController>();
                Debug.Log(enemy);

                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    Instantiate(explosion, transform.position, Quaternion.identity);
                }
            }
            Destroy(gameObject);
        }
    }

}
