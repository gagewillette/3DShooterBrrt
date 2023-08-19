using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpanwer : MonoBehaviour
{
    //instantiate spawner data scriptable object
    [SerializeField] 
    public SpawnerData data;

    //enemy prefab
    public GameObject enemyFab;
    
    //spawner data
    private float timeSinceLastSpawn;

    private bool CanSpawn() => timeSinceLastSpawn > 1 / (data.spawnRate / 60);
    
    public void Update()
    {
        if (CanSpawn())
        {
            Instantiate(enemyFab, transform.position, transform.rotation);
            timeSinceLastSpawn = 0;
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;
    }

}
