using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon Data")]
public class Weapon : ScriptableObject
{
    [Header("Weapon Type")]
    public bool melee;
    public bool gun;

    [Header("Weapon Stats")]
    public float damage;
    public float attackSpeed;
    public float batteryCost;
    public float maxHeat;
    public float cooldownTime;
    public float critChance;
    public float critDamage;
    public bool isAuto;

    [Header("Bullet Stats")]
    public float bulletSpeed;
    public float bulletLifetime;
}
