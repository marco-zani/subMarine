using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_spawner : MonoBehaviour
{
    public Transform player;
    public float Xoffset, Yoffset, spawnSpace;
    public GameObject enemyPrefab;

    public int enemyCount = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCount < 5)
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
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset, player.position.y + Yoffset), new Vector2(player.position.x + Xoffset, player.position.y - Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset, player.position.y - Yoffset), new Vector2(player.position.x - Xoffset, player.position.y - Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset, player.position.y - Yoffset), new Vector2(player.position.x - Xoffset, player.position.y + Yoffset));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset, player.position.y + Yoffset), new Vector2(player.position.x + Xoffset, player.position.y + Yoffset));

        Gizmos.color = Color.red;

        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y + Yoffset + spawnSpace), new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y - Yoffset - spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y - Yoffset - spawnSpace), new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y - Yoffset - spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y - Yoffset - spawnSpace), new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y + Yoffset + spawnSpace));
        Gizmos.DrawLine(new Vector2(player.position.x - Xoffset - spawnSpace, player.position.y + Yoffset + spawnSpace), new Vector2(player.position.x + Xoffset + spawnSpace, player.position.y + Yoffset + spawnSpace));


    }
}
