using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    //Snake Manager
    [SerializeField] SnakeManager snakeManager;
    [Space(3)]

    //List of enemy objects
    [SerializeField] List<GameObject> enemies = new List<GameObject>();
    [Space(3)]

    //Player to have enemies spawned around
    [SerializeField] List<GameObject> player;

    //Spawn time for enemies
    [Space(3)]
    [SerializeField] float spawn_wait;
    float countdown = 0;

    //The spawn radius for enemies
    [Space(3)]
    [SerializeField] float spawnRadius;

    private void Start()
    {
        player = snakeManager.snakebody;
    }


    // Update is called once per frame
    void Update()
    {
        // timer to spawn the next enemy Object
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            spawnEnemy();
            countdown = spawn_wait;
        }
    }

    void spawnEnemy()
    {
        //Increases the size of the radius so that an enemy does not spawn on the train
        float tmpRadius = spawnRadius + (1.5f * player.Count);

        //Spawns an enemy off of a radius of every train car in order to increase the difficulty as the train size increases
        for (int i = 0; i < player.Count; i++)
        {
            
            float angle = Random.value * Mathf.PI * 2;
            float x = Mathf.Cos(angle) * tmpRadius;
            float y = Mathf.Sin(angle) * tmpRadius;
            Vector2 spawnPos = new Vector2(player[i].transform.position.x + x, player[i].transform.position.y + y);
            int index = Random.Range(0, enemies.Count);

            GameObject newEnem = Instantiate(enemies[index], spawnPos, transform.rotation);
            enemyAI enemyAi = newEnem.GetComponent<enemyAI>();
            enemyAi.target = player[i];
            enemyAi.playerH = snakeManager.gameObject.GetComponent<playerHealth>();
        }
        
    }

}
