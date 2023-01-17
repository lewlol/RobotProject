using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats eStats;
    [SerializeField] float health;

    private void Awake()
    {
        health = eStats.maxHealth;
    }
    public void TakeDamage(float damage, float critChance, float critDamage)
    {
        int CC = Random.Range(0, 100);
        if(CC <= critChance)//Critical Strike Check
        {
            float cDamage = (critDamage / 100) * damage;
            float finalDamage = damage + cDamage;
            health -= finalDamage;

            Debug.Log("Critical Hit!" + finalDamage);
        }else
        {
            health -= damage;
            Debug.Log(damage);
        }

        if(health <= 0)
        {
            Debug.Log("Enemy Died");
        }
    }
}
