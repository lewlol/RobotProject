using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Movement")]
    public float speed; //Movement Speed
    public float maxBattery; //Maximum Battery

    [Header("Combat")]
    public float maxHealth; //Maximum Health
    public float damage; //Current Damage 
    public float critChance; //Chance for a Critical Hit
    public float critDamage; //Extra Damage Percent on top for Critical Hit

    [Header("Misc")]
    public int intelligence; //Robot Intelligence
}
