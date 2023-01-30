using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float health;
    public PlayerStats stats;

    private void Start()
    {
        Health();
    }
    public void Health()
    {
        health = stats.maxHealth;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            //Death
        }
    }
}
