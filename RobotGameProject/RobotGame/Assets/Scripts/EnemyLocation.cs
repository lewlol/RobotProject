using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocation : MonoBehaviour
{
    public float minXSpawnPoint;
    public float maxXSpawnPoint;

    public float minZSpawnPoint;
    public float maxZSpawnPoint;

    public int enemyCount;
    public List<GameObject> enemyList;

    public GameObject[] enemies;
    GameObject deadEnemy;
    private void Start()
    {
        CustomEventSystem.customEventSystem.OnTriggerEnemyLocation += SpawnEnemies;
        CustomEventSystem.customEventSystem.OnEnemyInLocationDied += RemoveEnemy;
    }

    public void SpawnEnemies()
    {
        Debug.Log("Triggered Location");

        for (int i = 0; i < enemyCount; i++)
        {
            int e = Random.Range(0, enemies.Length);
            Vector3 spawnPoint = new Vector3(Random.Range(minXSpawnPoint, maxXSpawnPoint), 1.5f, Random.Range(minZSpawnPoint, maxZSpawnPoint));
            GameObject enemy = Instantiate(enemies[e], spawnPoint, Quaternion.identity);
            enemyList.Add(enemy);
        } 
    }

    public void RemoveEnemy()
    {
        enemyList.Remove(deadEnemy);
    }
}
