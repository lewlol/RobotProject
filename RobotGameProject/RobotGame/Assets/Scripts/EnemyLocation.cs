using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocation : MonoBehaviour
{
    public float minSpawnPoint;
    public float maxSpawnPoint;

    float enemyCount;

    public GameObject[] enemies;
    private void Start()
    {
        CustomEventSystem.customEventSystem.OnTriggerEnemyLocation += SpawnEnemies;
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            int e = Random.Range(0, enemies.Length);
            Vector3 spawnPoint = new Vector3(Random.Range(minSpawnPoint, maxSpawnPoint), 0, Random.Range(minSpawnPoint, maxSpawnPoint));
            GameObject enemy = Instantiate(enemies[e], spawnPoint, Quaternion.identity);
        }
    }
}
