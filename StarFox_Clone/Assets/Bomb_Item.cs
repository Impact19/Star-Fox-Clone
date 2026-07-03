using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Item : ICollectible
{
    private Ship_Bombs shipBombs;

    private void Start()
    {
        base.Start();
        shipBombs = player.GetComponent<Ship_Bombs>(); 
    }

    protected override void increaseAmount(GameObject player)
    {
        player.GetComponent<Ship_Bombs>().increaseBomb(colAmount); 
    }
}
