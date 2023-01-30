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
            DamageText(finalDamage, Color.yellow);
        }else
        {
            health -= damage;
            DamageText(damage, Color.red);
        }

        if(health <= 0)
        {
            StartCoroutine(EnemyDeath());
        } 
    }

    public void DamageText(float damage, Color textColor)
    {
        //Random Position Modifier
        float x = Random.Range(-1, 1);
        float z = Random.Range(-1, 1);
        float y = Random.Range(1.5f, 2.5f);
        Vector3 offset = new Vector3(x, y, z);

        //Damage Text
        GameObject newDT = Instantiate(damageText, transform.position + offset, Quaternion.identity);
        newDT.transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        TextMesh tm = newDT.GetComponent<TextMesh>();
        tm.color = textColor;
        tm.text = damage.ToString();
        StartCoroutine(DeleteDamageText(newDT));
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            BulletScript bs = other.GetComponent<BulletScript>();
            TakeDamage(bs.weaponData.damage, bs.weaponData.critChance, bs.weaponData.critDamage);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float damage = eStats.damage;
            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    IEnumerator DeleteDamageText(GameObject dt)
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(dt);
    }
    IEnumerator EnemyDeath()
    {
        BoxCollider bx = GetComponent<BoxCollider>();
        MeshRenderer mr = GetComponent<MeshRenderer>();


        bx.enabled = false;
        mr.enabled = false;

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
