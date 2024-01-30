using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossStats : MonoBehaviour
{
    public spawnEnemies enemy;
    [SerializeField] protected GameObject tent;

    private void OnDestroy()
    {
        enemy.bossDeath(gameObject.transform, tent);
    }

}
