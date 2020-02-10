using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BulletMovement : MonoBehaviour
{
    public static float speed;
    public float damage = 50f;

    Rigidbody2D rb2d;
    private float startingTime = 0;
    public GameObject explosion;
    public GameObject enemyData;


    private GameObject popUp;
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
                
                popUp = Instantiate(enemyData) as GameObject;
                popUp.GetComponentInChildren<Text>().text = hitInfo.name + "   Lv: x";

                Debug.Log(popUp.GetComponentInChildren<Text>().text);

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
