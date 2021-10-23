using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float enemySpawnCooldown;

    private float timeUntilEnemySpawn; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesSpawning();
    }


    void EnemiesSpawning()
    {
        if (Time.time > timeUntilEnemySpawn)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        timeUntilEnemySpawn = Time.time + enemySpawnCooldown;
    }

}
