using System.Collections;
using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyStats : ScriptableObject
{
    [Header("Movement")]
    public float speed; //Movement Speed

    [Header("Combat")]
    public float maxHealth; //Maximum Health
    public float damage; //Current Damage 

    public float chaseRadius; //AI Chase Player Radius
    public float attackRadius; //Ai Attack Player Radius

    public float attackDelay; //Time between Attacks
    public float attackDistance; //How far a bullet or melee attack goes

}
