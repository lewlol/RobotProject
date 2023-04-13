using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoblinAI : MonoBehaviour
{
    public EnemyStats eStats;

    public NavMeshAgent agent;
    Transform player;
    bool canAttack;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(distance < eStats.chaseRadius && distance > eStats.attackRadius) //Chase Player
        {
            ChasePlayer();
        }

        if(distance < eStats.attackRadius) //Attacking
        {
            if (canAttack)
                AttackPlayer();
        }
    }

    public void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    public void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(player.position);
        StartCoroutine(AttackRaycasting());
        StartCoroutine(AttackDelay()); 
    }

    IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(eStats.attackDelay);
        canAttack = true;
    }

    IEnumerator AttackRaycasting()
    {
        yield return new WaitForSeconds(0.5f);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, eStats.attackRadius))
        {
            if(hit.transform.gameObject.tag == "Player")
            {
                PlayerHealth ph = hit.transform.GetComponent<PlayerHealth>();
                ph.TakeDamage(eStats.damage);
            }
        }
    }
}
