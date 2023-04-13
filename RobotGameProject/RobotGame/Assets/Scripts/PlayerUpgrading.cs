using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrading : MonoBehaviour
{
    public GameObject player;
    public void HeadUpgrade()
    {
        player.GetComponent<PlayerStats>().maxBattery += 10;
        Debug.Log("Battery Upgraded!");
    }

    public void ChestUpgrade()
    {
        player.GetComponent<PlayerStats>().maxHealth += 5;
        Debug.Log("Max Health Upgraded!");
    }

    public void ArmsUpgrade()
    {
        player.GetComponent<PlayerStats>().strength += 2;
        Debug.Log("Strength Upgraded!");
    }

    public void LegsUpgrade()
    {
        player.GetComponent<PlayerStats>().speed += 1;
        Debug.Log("Speed Upgraded!");
    }
}
