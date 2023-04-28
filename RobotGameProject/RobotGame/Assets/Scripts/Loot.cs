using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Loot")]
public class Loot : ScriptableObject
{
    public Mesh lootMesh;
    public Material lootMaterial;
    public string lootName;
    public float dropChance;
    public LootType lootType;

    public Loot(string lootName, int dropChance)
    {
        this.lootName = lootName;
        this.dropChance = dropChance;
    }
}
