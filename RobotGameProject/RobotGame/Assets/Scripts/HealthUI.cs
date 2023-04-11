using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;
    public Slider batterySlider;

    private void Start()
    {
        CustomEventSystem.customEventSystem.OnHealthChange += HealthUIUpdate;
        CustomEventSystem.customEventSystem.OnBatteryChange += BatteryUIUpdate;
    }
    public void HealthUIUpdate()
    {
        healthSlider.value = CustomEventSystem.customEventSystem.h;
        healthSlider.maxValue = CustomEventSystem.customEventSystem.mh;
    }
    public void BatteryUIUpdate()
    {
        batterySlider.value = CustomEventSystem.customEventSystem.b;
        batterySlider.maxValue = CustomEventSystem.customEventSystem.mb;
    }
}
