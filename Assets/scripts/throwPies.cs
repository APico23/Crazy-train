using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwPies : MonoBehaviour
{
    [SerializeField] findEnemy rangeCheck;
    [SerializeField] float spawnWait;
    private float countdown = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            rangeCheck.isSearching = true;
            countdown = spawnWait;
        }
    }
}
