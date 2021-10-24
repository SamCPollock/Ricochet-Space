using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_EnemySpawner : MonoBehaviour
{
    [Header("Alien")]
    public GameObject enemyPrefab;
    public float enemySpawnCooldown;

    [Header("Rocket")]
    public GameObject rocketPrefab;
    public float rocketSpawnCooldown;

    private float timeUntilEnemySpawn;
    private float timeUntilRocketSpawn;


    // Start is called before the first frame update
    void Start()
    {
        timeUntilRocketSpawn = Time.time + (rocketSpawnCooldown / 2);
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
        if (Time.time > timeUntilRocketSpawn)
        {
            SpawnRocket();
        }
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        timeUntilEnemySpawn = Time.time + enemySpawnCooldown;
    }

    void SpawnRocket()
    {
        GameObject rocket = Instantiate(rocketPrefab, new Vector3(-3, 2, 0), Quaternion.identity);
        timeUntilRocketSpawn = Time.time + rocketSpawnCooldown;
    }

}
