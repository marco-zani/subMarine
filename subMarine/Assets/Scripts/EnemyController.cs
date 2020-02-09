using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float life = 100f;

    private DestroySelf destroy;
    // Start is called before the first frame update
    void Start()
    {
        destroy = new DestroySelf();
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
            Destroy(gameObject);
    }
}
