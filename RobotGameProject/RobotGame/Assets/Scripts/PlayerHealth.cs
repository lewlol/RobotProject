using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        CustomEventSystem.customEventSystem.HealthChange(health, stats.maxHealth);
        if(health <= 0)
        {
            StartCoroutine(PlayerDied());
        }
    }

    IEnumerator PlayerDied()
    {
        BoxCollider bx = GetComponent<BoxCollider>();
        MeshRenderer mr = GetComponentInChildren<MeshRenderer>();
        Rigidbody rb = GetComponent<Rigidbody>();

        bx.enabled = false;
        mr.enabled = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;

        yield return new WaitForSeconds(5);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
