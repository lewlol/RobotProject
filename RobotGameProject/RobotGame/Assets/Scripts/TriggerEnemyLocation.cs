using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEnemyLocation : MonoBehaviour
{
    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {     
            CustomEventSystem.customEventSystem.TriggerEnemyLocation();
        }
    }
}
