using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public Transform player;
    public float Xoffset, Yoffset, spawnSpace, deathZone;
    public GameObject enemyPrefab;
    public int maxEnemy, enemyCount;


    private EnemyController[] enemyList;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < maxEnemy)
        {
            float x, y;
            x = Random.Range(player.position.x - Xoffset - spawnSpace, player.position.x + Xoffset + spawnSpace);
            y = Random.Range(player.position.y - Yoffset - spawnSpace, player.position.y + Yoffset + spawnSpace);
            if (!(x < (player.position.x + Xoffset) && x > player.position.x - Xoffset) || !(y < player.position.y + Yoffset && y > player.position.y - Yoffset))
            {

                Instantiate(enemyPrefab, new Vector3(x, y, 0), transform.rotation);
                enemyCount++;

            }

        }

        enemyList = FindObjectsOfType<EnemyController>();
        Debug.Log(enemyList.Length);

        foreach (var enemy in enemyList)
        {

            if (enemy.transform.position.x < player.position.x - Xoffset - spawnSpace - deathZone || enemy.transform.position.x > player.position.x + Xoffset + spawnSpace + deathZone ||
                enemy.transform.position.y < player.position.y - Yoffset - spawnSpace - deathZone || enemy.transform.position.y > player.position.y + Yoffset + spawnSpace + deathZone)
            {
                Destroy(enemy.gameObject);
                enemyCount--;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset, player.position.y + Yoffset), new Vector2(player.position.x + Xoffset, player.position.y - Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset, player.position.y - Yoffset), new Vector2(player.position.x - Xoffset, player.position.y - Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset, player.position.y - Yoffset), new Vector2(player.position.x - Xoffset, player.position.y + Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset, player.position.y + Yoffset), new Vector2(player.position.x + Xoffset, player.position.y + Yoffset));

        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y + Yoffset + spawnSpace), new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y - Yoffset - spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y - Yoffset - spawnSpace), new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y - Yoffset - spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y - Yoffset - spawnSpace), new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y + Yoffset + spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y + Yoffset + spawnSpace), new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y + Yoffset + spawnSpace));

        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace + deathZone, player.position.y + Yoffset + spawnSpace + deathZone),
            new Vector2(player.position.x + Xoffset + spawnSpace + deathZone, player.position.y - Yoffset - spawnSpace - deathZone));
        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace + deathZone, player.position.y - Yoffset - spawnSpace - deathZone),
            new Vector2(player.position.x - Xoffset - spawnSpace - deathZone, player.position.y - Yoffset - spawnSpace - deathZone));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace - deathZone, player.position.y - Yoffset - spawnSpace - deathZone),
            new Vector2(player.position.x - Xoffset - spawnSpace - deathZone, player.position.y + Yoffset + spawnSpace + deathZone));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace - deathZone, player.position.y + Yoffset + spawnSpace + deathZone),
            new Vector2(player.position.x + Xoffset + spawnSpace + deathZone, player.position.y + Yoffset + spawnSpace + deathZone));
    }
}
