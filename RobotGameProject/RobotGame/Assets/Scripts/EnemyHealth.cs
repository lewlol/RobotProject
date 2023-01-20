using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public EnemyStats eStats;
    [SerializeField] float health;
    [SerializeField] private GameObject damageText;

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
            DamageText(finalDamage);
        }else
        {
            health -= damage;
            DamageText(damage);
        }

        if(health <= 0)
        {
            Debug.Log("Enemy Died");
        }
    }

    public void DamageText(float damage)
    {
        //Damage Text
        GameObject newDT = Instantiate(damageText, transform.position + new Vector3(0, 2, 0), transform.LookAt(cam.transform));
        TextMesh tm = newDT.GetComponent<TextMesh>();
        tm.text = damage.ToString();
    }
}
