using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Data")]
public class EnemyStats : ScriptableObject
{
    [Header("Movement")]
    public float speed; //Movement Speed

    [Header("Combat")]
    public float maxHealth; //Maximum Health
    public float damage; //Current Damage 

}
