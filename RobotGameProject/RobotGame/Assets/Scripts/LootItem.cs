using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public int lootType;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerInventory pi = collision.gameObject.GetComponent<PlayerInventory>();
            AddResource(pi);
            Destroy(gameObject);
            
        }
    }

    public void AddResource(PlayerInventory pi)
    {
        if (lootType == 1)
        {
            pi.rawMetal++;
            return;
        }
        if(lootType == 2)
        {
            pi.refinedMetal++;
            return;
        }
        if(lootType == 3)
        {
            pi.copper++;
            return;
        }
    }
}
