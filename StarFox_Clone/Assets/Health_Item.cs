using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Item : ICollectible
{
     private Ship_Health shipHealth;
    

    private void Start()
    {
        base.Start();

        shipHealth = player.GetComponent<Ship_Health>(); 

    }

    protected override void increaseAmount(GameObject player)
    {
        player.GetComponent<Ship_Health>().gainHealth(colAmount); 
    }

}
