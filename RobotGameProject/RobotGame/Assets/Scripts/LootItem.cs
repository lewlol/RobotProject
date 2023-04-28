using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{
    public LootType lootType;

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
        if (lootType == LootType.RawMetal)
        {
            pi.rawMetal++;
        }
        if(lootType == LootType.RefinedMetal)
        {
            pi.refinedMetal++;
        }
        if(lootType == LootType.Copper)
        {
            pi.copper++;
        }

        pi.SetTexts();
    }
}
