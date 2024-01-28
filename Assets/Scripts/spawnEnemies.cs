using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    //List of enemy objects
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [Space(3)]

    //Player to have enemies spawned around
    [SerializeField] GameObject player;

    //Spawn time for enemies
    [Space(3)]
    [SerializeField] float spawn_wait;
    float countdown = 0;

    //The spawn radius for enemies
    [Space(3)]
    [SerializeField] float spawnRadius;


    // Update is called once per frame
    void Update()
    {
        // timer to spawn the next rock Object
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            spawnEnemy();
            countdown = spawn_wait;
        }
    }

    void spawnEnemy()
    {
        float angle = Random.value * Mathf.PI * 2;
        float x = Mathf.Cos(angle) * spawnRadius;
        float y = Mathf.Sin(angle) * spawnRadius;
        Vector2 spawnPos = new Vector2(player.transform.position.x + x, player.transform.position.y + y);
        int index = Random.Range(0, enemies.Count);

        Instantiate(enemies[index], spawnPos, transform.rotation);
    }

}
