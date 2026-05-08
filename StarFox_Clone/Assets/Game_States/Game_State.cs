using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game_State : MonoBehaviour
{
    public abstract void playState();

    public abstract void changeState(Game_State gameState); 
}
