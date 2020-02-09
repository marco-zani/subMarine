using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{

    private float life = 10;
    private Enemy_spawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        spawner = FindObjectOfType<Enemy_spawner>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        life -= damage;
        Debug.Log(life);
        if (life <= 0)
        {
            Destroy(gameObject);
            spawner.enemyCount--;
        }
    }
}
