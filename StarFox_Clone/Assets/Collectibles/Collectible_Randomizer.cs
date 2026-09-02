using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Randomizer : MonoBehaviour
{
     
    public static ICollectible[] collectibles;
    public ICollectible bomb, health, laser;

    public void Awake()
    {
        collectibles = new ICollectible[3]; 
        collectibles[0] = health;
        collectibles[1] = bomb;
        collectibles[2] = laser; 
    }

    public static ICollectible randomCollectible() {
        float rand = Random.Range(0f,totalWeight()); 
        for (int i = 0; i < collectibles.Length; i++) {
            if (rand < collectibles[i].spawnChance)
            {
               
                return collectibles[i];
            }
            rand -= collectibles[i].spawnChance;
        }
        return null;
    }

    public static float totalWeight() {
        float total = 0; 
        for (int i = 0; i < collectibles.Length; i++) {
            total += collectibles[i].spawnChance;  

        }
        return total; 
    }
}
