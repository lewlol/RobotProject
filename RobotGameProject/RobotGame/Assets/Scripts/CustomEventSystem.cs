using System;
using UnityEngine;

public class CustomEventSystem : MonoBehaviour
{
    public static CustomEventSystem customEventSystem;
    public static GameObject player;
    private void Awake()
    {
        customEventSystem = this;
        player = GameObject.Find("Player");
    }

    public event Action OnHealthChange;
    [HideInInspector] public float h; [HideInInspector] public float mh;
    public void HealthChange(float health, float maxHealth)
    {
        h = health;
        mh = maxHealth;
        if (OnHealthChange != null)
            OnHealthChange();
    }

    public event Action OnBatteryChange;
    [HideInInspector] public float b; [HideInInspector] public float mb;
    public void BatteryChange(float battery, float maxBattery)
    {
        b = battery;
        mb = maxBattery;
        if(OnBatteryChange != null)
            OnBatteryChange();
    }

    public event Action OnTriggerEnemyLocation;
    public void TriggerEnemyLocation()
    {
        if(OnTriggerEnemyLocation != null)
        {
            OnTriggerEnemyLocation();
        }
    }
}
