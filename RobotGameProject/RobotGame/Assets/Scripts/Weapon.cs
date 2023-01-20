using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject
{
    [Header("Weapon Type")]
    public bool melee;
    public bool gun;

    [Header("Weapon Stats")]
    public float damage;
    public float attackSpeed;
    public float knockback;
}
