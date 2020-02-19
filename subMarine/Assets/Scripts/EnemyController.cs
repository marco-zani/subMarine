using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float maxLife = 100f;
    public float currentLife;


    private Enemy_spawner spawner;
    private HUD_Script HUD;

    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
        spawner = FindObjectOfType<Enemy_spawner>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        currentLife -= damage;
        if (currentLife <= 0)
        {
            Destroy(gameObject);
            spawner.enemyCount--;
        }
    }
}
