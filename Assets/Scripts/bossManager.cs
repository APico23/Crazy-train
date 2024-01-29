using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossManager : MonoBehaviour
{
    float timeElapsed;
    int bossIndex;
    [SerializeField] List<GameObject> bossList;


    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        bossIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        bossSpawnCheck();
    }

    void bossSpawnCheck()
    {
        if (timeElapsed >= 300)
        {
            gameObject.GetComponent<spawnEnemies>().bossSpawn(bossList[bossIndex]);
            bossIndex++;
            timeElapsed = 0;
        }
    }

}
