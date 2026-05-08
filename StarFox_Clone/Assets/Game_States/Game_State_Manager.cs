using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_State_Manager : MonoBehaviour
{
    public Game_State currentGameState;
    public PauseGS pauseGameState; 
    public PlayGS playGameState;
    public DeathGS deathGameState;

    private void Start()
    {
        pauseGameState = GetComponent<PauseGS>();
        playGameState = GetComponent<PlayGS>();
        deathGameState = GetComponent<DeathGS>(); 

        currentGameState = playGameState; 
    }

    private void Update()
    {
        currentGameState.playState(); 
    }
}
