using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattery : MonoBehaviour
{
    PlayerStats stats;
    public float batteryLife;

    private void Start()
    {
        stats = GetComponent<PlayerStats>();

        batteryLife = stats.maxBattery;
    }

    void RemoveBattery()
    {
        if(batteryLife <= 0)
        {
            PlayerMovement pm = GetComponent<PlayerMovement>();
            pm.canMove = false;
        }
    }

    public void AddBattery(float amount)
    {
        batteryLife += amount;
        if (batteryLife >= stats.maxBattery)
        {
            batteryLife = stats.maxBattery;
        }
    }
}
