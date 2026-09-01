using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Randomizer : MonoBehaviour
{
    [SerializeField] private ICollectible[] collectible;

    public ICollectible randomCollectible() {
        float rand = Random.Range(0, 1); 
        for (int i = 0; i < collectible[i].spawnChance; i++) {
            if (rand < collectible[i].spawnChance) return collectible[i];
            rand -= collectible[i].spawnChance;
        }
        return null;
    }
}
